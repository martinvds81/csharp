using System;
using System.Linq;

public static class Isogram
{
    public static bool IsIsogram(string word)
    {
        var charsGrouped = from l in word.ToLowerInvariant().ToCharArray()
                        where char.IsLetter(l)
                        group l by l into grp
                        select new
                        {
                            letter = grp.Key,
                            repeated = grp.Count()
                        };

        return charsGrouped.All(l => l.repeated == 1);
    }
}
