using System;

public static class ReverseString
{
    public static string Reverse(string input)
    {
        // Handle empty string
        if(string.IsNullOrWhiteSpace(input))
        {
            return input;
        }

        var chars = input.ToCharArray();
        var charsReversed = new char[chars.Length];

        for (int i = input.Length - 1; i >= 0; i--)
        {
            charsReversed[(input.Length - 1) - i] = chars[i];
        }

        return string.Join("", charsReversed);
    }
}