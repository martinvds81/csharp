using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

public static class Ledger
{
    private static readonly LedgerService _ledgerService = new LedgerService();
    private static readonly LedgerPrinter _ledgerPrinter = new LedgerPrinter();

    public static LedgerEntry CreateEntry(string date, string description, int change)
    {
        return new LedgerEntry(DateTime.Parse(date, CultureInfo.InvariantCulture), description, change / 100.0m);
    }

    public static string Format(string currency, string locale, LedgerEntry[] entries)
    {
        var formatted = new StringBuilder();

        var ledgerCulture = _ledgerService.GetCulture(locale, currency);

        var translations = _ledgerService.GetTranslations(locale);

        formatted.Append(_ledgerPrinter.PrintHeader(translations));

        if (entries.Any())
        {
            var entriesForOutput = entries.GetOrderedEntries();

            foreach (var entry in entriesForOutput)
            {
                formatted.AppendNewLine(_ledgerPrinter.PrintEntry(ledgerCulture, LedgerConstants.TruncateLength, LedgerConstants.TruncateSuffix, entry));
            }
        }

        return formatted.ToString();
    }
}

public static class LedgerConstants
{
    public const int TruncateLength = 25;
    public const string TruncateSuffix = "...";
}

public static class LedgerExtensions
{
    public static string Truncate(this string input, int maxLength, string suffix)
    {
        return input.Length > maxLength ? $"{input.Substring(0, maxLength - suffix.Length)}{suffix}" : input;
    }

    public static IEnumerable<LedgerEntry> GetOrderedEntries(this LedgerEntry[] entries) => entries
        .OrderBy(x => x.Date)
        .ThenBy(x => x.Description)
        .ThenBy(x => x.Change);

    public static string FormattedChange(this decimal change, IFormatProvider culture) => $"{change.ToString("C", culture)}{(change < 0.0M ? "" : " ")}";

    public static StringBuilder AppendNewLine(this StringBuilder stringBuilder, string value) => stringBuilder.Append($"\n{value}");

    public static string ToLedgerDate(this DateTime date, IFormatProvider culture) => date.ToString("d", culture);
}

public class LedgerEntry
{
    public LedgerEntry(DateTime date, string desc, decimal chg)
    {
        Date = date;
        Description = desc;
        Change = chg;
    }

    public DateTime Date { get; }
    public string Description { get; }
    public decimal Change { get; }
}

public class LedgerCulture
{
    public string Name { get; set; }
    public int CurrencyNegativePattern { get; set; }
    public string ShortDatePattern { get; set; }
    public LedgerTranslation Translations { get; set; }

    public LedgerCulture(string name, int currencyNegativePattern, string shortDatePattern)
    {
        Name = name;
        CurrencyNegativePattern = currencyNegativePattern;
        ShortDatePattern = shortDatePattern;
    }
}

public class LedgerTranslation
{
    public string Date { get; set; }
    public string Description { get; set; }
    public string Change { get; set; }
}

/// <summary>
/// Responsible for all culture and currency related functionality
/// </summary>
public class LedgerService
{
    /// <summary>
    /// Valid Currencies 
    /// </summary>
    private static readonly Dictionary<string, string> _validCurrencies = new Dictionary<string, string>()
    {
        ["EUR"] = "€",
        ["USD"] = "$"
    };

    /// <summary>
    /// Valid Cultures
    /// </summary>
    private static readonly List<LedgerCulture> _validCulures = new List<LedgerCulture>()
    {
        new LedgerCulture("en-US", 0, "MM/dd/yyyy")
        {
            Translations = new LedgerTranslation()
            {
                Date = "Date",
                Description = "Description",
                Change = "Change"
            }
        },
        new LedgerCulture("nl-NL", 12, "dd/MM/yyyy")
        {
            Translations = new LedgerTranslation()
            {
                Date = "Datum",
                Description = "Omschrijving",
                Change = "Verandering"
            }
        }
    };

    public LedgerTranslation GetTranslations(string name)
    {
        var ledgerCulture = _validCulures.FirstOrDefault(n => n.Name == name);
        if (ledgerCulture == null)
        {
            throw new ArgumentException("Invalid culture");
        }

        return ledgerCulture.Translations;
    }

    public CultureInfo GetCulture(string name, string currency)
    {
        var ledgerCulture = _validCulures.FirstOrDefault(n => n.Name == name);
        if (ledgerCulture == null)
        {
            throw new ArgumentException("Invalid culture");
        }

        if (!_validCurrencies.ContainsKey(currency))
        {
            throw new ArgumentException("Invalid currency");
        }

        return new CultureInfo(ledgerCulture.Name)
        {
            NumberFormat =
            {
                CurrencySymbol = _validCurrencies[currency],
                CurrencyNegativePattern = ledgerCulture.CurrencyNegativePattern
            },
            DateTimeFormat =
            {
                ShortDatePattern = ledgerCulture.ShortDatePattern
            }
        };
    }
}

/// <summary>
/// Responsible for printing
/// </summary>
public class LedgerPrinter
{
    public string PrintHeader(LedgerTranslation translation)
    {
        var cellDate = translation.Date;
        var cellDescription = translation.Description;
        var cellChange = translation.Change;

        return $"{cellDate.PadRight(11)}| {cellDescription.PadRight(26)}| {cellChange.PadRight(13)}";
    }

    public string PrintEntry(IFormatProvider culture, int truncateLenth, string truncateSuffix, LedgerEntry entry)
    {
        var date = entry.Date.ToLedgerDate(culture);
        var description = entry.Description.Truncate(truncateLenth, truncateSuffix);
        var change = entry.Change.FormattedChange(culture);

        return $"{date.PadRight(11)}| {description.PadRight(26)}| {change.PadLeft(13)}";
    }
}

