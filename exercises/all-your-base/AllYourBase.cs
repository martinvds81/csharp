using System;
using System.Collections.Generic;
using System.Linq;
public static class AllYourBase
{
    public static int[] Rebase(int inputBase, int[] inputDigits, int outputBase)
    {
        if (!inputBase.IsValidBase())
        {
            throw new ArgumentException(nameof(inputBase));
        }

        if (!outputBase.IsValidBase())
        {
            throw new ArgumentException(nameof(outputBase));
        }

        if(!inputDigits.Any())
        {
            return new int[] { 0 };
        }

        if (!inputDigits.AreValidDigits(inputBase))
        {
            throw new ArgumentException(nameof(inputBase));
        }

        var digits = inputDigits.Length;
        var count = digits;
        double total = 0;

        for (int i = 0; i < count; i++)
        {
            var digit = inputDigits[i];

            var result = digit * Math.Pow(inputBase, digits - 1);

            digits--;
            total += result;
        }

        if(total == 0)
        {
            return new int[] { 0 };
        }

        var remainder = (int)total;
        var list = new List<int>();
        while (remainder > 0)
        {
            list.Add(remainder % outputBase);
            remainder = remainder / outputBase;
        }

        list.Reverse();

        return list.ToArray();

    }

    private static bool IsValidBase(this int inputBase) => inputBase > 1;

    private static bool AreValidDigits(this int[] digits, int inputBase) => digits.Any() && digits.Min() >= 0 && digits.Max() < inputBase;
}