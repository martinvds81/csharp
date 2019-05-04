using System;
using System.Linq;

public static class Series
{
    public static string[] Slices(string numbers, int sliceLength)
    {
        if(sliceLength > numbers.Length || sliceLength <= 0)
        {
            throw new ArgumentException(nameof(sliceLength));
        }

        return Enumerable.Range(0, numbers.Length)
            .Where(z => z + sliceLength <= numbers.Length)
            .Select(y => numbers.Substring(y, sliceLength))
            .ToArray();
    }
}