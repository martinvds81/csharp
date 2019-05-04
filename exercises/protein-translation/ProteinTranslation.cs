using System;
using System.Collections.Generic;
using System.Linq;

public static class ProteinTranslation
{
    private static IDictionary<string, string[]> ProteinList = new Dictionary<string, string[]>()
    {
        ["Methionine"] = new string[] { "AUG" },
        ["Phenylalanine"] = new string[] { "UUU", "UUC" },
        ["Leucine"] = new string[] { "UUA", "UUG" },
        ["Serine"] = new string[] { "UCU", "UCC", "UCA", "UCG" },
        ["Tyrosine"] = new string[] { "UAU", "UAC" },
        ["Cysteine"] = new string[] { "UGU", "UGC" },
        ["Tryptophan"] = new string[] { "UGG" }
    };

    private static string[] Stop = new string[] { "UAA", "UAG", "UGA" };

    public static string[] Proteins(string strand)
    {
        // Get valid codons
        var codons = Enumerable.Range(0, strand.Length / 3).Select(s => strand.Substring(s * 3, 3)).TakeWhile(s => !Stop.Contains(s));

        var proteins = ProteinList.SelectMany(s => s.Value.Select(t => new { protein = s.Key, codon = t }));

        return (from c in codons
                join p in proteins on c equals p.codon
                select p.protein).ToArray();
    }
}