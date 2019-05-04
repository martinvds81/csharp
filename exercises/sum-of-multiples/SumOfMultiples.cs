using System;
using System.Collections.Generic;
using System.Linq;

public static class SumOfMultiples
{
    public static int Sum(IEnumerable<int> multiples, int max)
    {
        var sumTotal = new HashSet<ulong>();

        var x = 1_999_999_999UL + 1_999_999_999UL;

        foreach (int multiple in multiples.Where(m => m <= max && m > 0))
        {
            ulong total = 0;

            while (total + (ulong)multiple < (ulong)max)
            {
                total += (ulong)multiple;
                sumTotal.Add(total);
            }
        }

        return (int)sumTotal.DefaultIfEmpty().Aggregate((a, b) => a + b);
    }
}