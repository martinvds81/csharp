using System;
using System.Linq;

public static class Pangram
{
    public static bool IsPangram(string input)
    {
        var charsGrouped = from l in input.ToLowerInvariant().ToCharArray()
                           where char.IsLetter(l)
                           group l by l into grp
                           select grp.Count();

        return charsGrouped.Count() == 26;
    }
}