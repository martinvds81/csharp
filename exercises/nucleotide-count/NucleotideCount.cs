using System;
using System.Collections.Generic;
using System.Linq;

public static class NucleotideCount
{
    private const string validNucleotide = "ACGT";

    public static IDictionary<char, int> Count(string sequence)
    {
        if (!sequence.ToCharArray().All(validNucleotide.Contains))
        {
            throw new ArgumentException("Invalid nucleotides");
        }

        return (from s in string.Concat(sequence, validNucleotide).ToCharArray()
                group s by s into g
                orderby g.Key
                select new { key = g.Key, value = g.Count() - 1 }).ToDictionary(k => k.key, v => v.value);
    }
}