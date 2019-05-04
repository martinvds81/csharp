using System;
using System.Linq;

public static class Hamming
{
    public static int Distance(string firstStrand, string secondStrand)
    {
        if (!strandsAreComparable(firstStrand, secondStrand))
        {
            throw new ArgumentException("Strands are not comparable!");
        }

        return Enumerable.Range(0, firstStrand.Length).Count(s => firstStrand[s] != secondStrand[s]);
    }

    static bool strandsAreComparable(string firstStrand, string secondStrand) => firstStrand.Length == secondStrand.Length;
}