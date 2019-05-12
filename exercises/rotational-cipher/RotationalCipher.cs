using System;
using System.Text;

public static class RotationalCipher
{
    public static string Rotate(string text, int shiftKey)
    {
        if (string.IsNullOrEmpty(text))
        {
            throw new ArgumentException(nameof(text));
        }

        var builder = new StringBuilder();

        foreach (var character in text)
        {
            // If it's not a letter just add it
            if (!char.IsLetter(character))
            {
                builder.Append(character);
            }
            else
            {
                char d = char.IsUpper(character) ? 'A' : 'a';

                var newCharacter = character + shiftKey;

                if(newCharacter >= d + 26)
                {
                    newCharacter -= 26;
                }

                builder.Append((char)newCharacter);
            }
        }

        return builder.ToString();
    }
}