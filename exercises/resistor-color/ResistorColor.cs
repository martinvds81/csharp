using System;
using System.Collections.Generic;
using System.Linq;

public static class ResistorColor
{
    private static readonly IDictionary<string, int> ResistorColors = new Dictionary<string, int>()
    {
        { "black", 0 },
        { "brown", 1 },
        { "red",  2 },
        { "orange", 3 },
        { "yellow", 4 },
        { "green", 5 },
        { "blue", 6 },
        { "violet", 7 },
        { "grey", 8 },
        { "white", 9 }
    };

    public static int ColorCode(string color)
    {
        if (ResistorColors.TryGetValue(color.ToLower(), out var resistorColor))
        {
            return resistorColor;
        }
        else
        {
            throw new ArgumentException("color is not defined");
        }
    }

    public static string[] Colors() => ResistorColors.Keys.ToArray();
}