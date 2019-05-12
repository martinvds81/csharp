using System;
using System.Linq;
using System.Text.RegularExpressions;

public static class LargestSeriesProduct
{
    public static long GetLargestProduct(string digits, int span)
    {
        if (span == 0)
        {
            return 1;
        }

        if (string.IsNullOrEmpty(digits) || !Regex.IsMatch(digits, "^[0-9]*$"))
        {
            throw new ArgumentException(nameof(digits));
        }

        if (span < 1)
        {
            throw new ArgumentException(nameof(span));
        }

        if (digits.Length < span || span > digits.Length)
        {
            throw new ArgumentException("span is to large");
        }

        return Enumerable.Range(0, (digits.Length - (span - 1)))
                        .Select(d => digits.Substring(d, span))
                        .Select(d => d.ToCharArray().Select(p => Convert.ToInt32(p.ToString())).Aggregate((current, next) => current * next))
                        .Max();
    }
}