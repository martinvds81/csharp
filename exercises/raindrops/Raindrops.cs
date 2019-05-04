using System;
using System.Linq;

public static class Raindrops
{
    enum Drops
    {
        Pling = 3,
        Plang = 5,
        Plong = 7
    }

    public static string Convert(int number)
    {
        var factors = Enumerable.Range(1, number).Where(x => number % x == 0 && IsValidFactor(x));

        if (!factors.Any())
        {
            return number.ToString();
        }

        return string.Join(string.Empty, factors.Select(f => Enum.GetName(typeof(Drops), f)));
    }

    static bool IsValidFactor(int factor) => factor == (int)Drops.Pling || factor == (int)Drops.Plang || factor == (int)Drops.Plong;
}