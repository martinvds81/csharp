using System.Collections.Generic;
using System.Text;

public static class RomanNumeralExtension
{
    private static List<KeyValuePair<int, string>> numbers = new List<KeyValuePair<int, string>>()
    {
        new KeyValuePair<int, string>(1000, "M"),
        new KeyValuePair<int, string>(900,"CM"),
        new KeyValuePair<int, string>(500, "D"),
        new KeyValuePair<int, string>(400, "CD"),
        new KeyValuePair<int, string>(100, "C"),
        new KeyValuePair<int, string>(90, "XC"),
        new KeyValuePair<int, string>(50, "L"),
        new KeyValuePair<int, string>(40,"XL"),
        new KeyValuePair<int, string>(10, "X"),
        new KeyValuePair<int, string>(9, "IX"),
        new KeyValuePair<int, string>(5, "V"),
        new KeyValuePair<int, string>(4, "IV"),
        new KeyValuePair<int, string>(1, "I"),
    };

    public static string ToRoman(this int value)
    {
        var builder = new StringBuilder();
        for (int i = 0; i < numbers.Count; i++)
        {
            while (value >= numbers[i].Key)
            {
                value -= numbers[i].Key;
                builder.Append(numbers[i].Value);
            }
        }
        return builder.ToString();
    }
}