using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class SimpleCipher
{
    private readonly string key;
    private const string alphabet = "abcdefghijklmnopqrstuvwxyz";
    private List<string> alphabetSet = new List<string>();

    public SimpleCipher() : this(RandomString(100))
    {
    }

    public SimpleCipher(string key)
    {
        this.key = key;

        this.alphabetSet = alphabet.ToCharArray().Select(a => a.ToString()).ToList();
    }

    public string Key => key;

    public string Encode(string plaintext)
    {
        var builder = new StringBuilder();
        var keyIndex = 0;

        for (int i = 0; i < plaintext.Length; i++)
        {
            // Retrieve current index in alphabet
            var currIndex = alphabetSet.IndexOf(plaintext[i].ToString());

            // Retrieve current index of key in alphabet
            var newIndex = alphabet.IndexOf(this.key[keyIndex]);

            // If new index is out of bounds
            if (currIndex + newIndex <= alphabetSet.Count - 1)
            {
                builder.Append(alphabet[currIndex + newIndex]);
            }
            else
            {
                builder.Append(alphabet[currIndex + newIndex - alphabetSet.Count]);
            }

            if (keyIndex < this.key.Length - 1)
            {
                keyIndex++;
            }
            else
            {
                keyIndex = 0;
            }
        }

        return builder.ToString();
    }

    public string Decode(string ciphertext)
    {
        var builder = new StringBuilder();
        var keyIndex = 0;

        for (int i = 0; i < ciphertext.Length; i++)
        {
            // Retrieve current index in alphabet
            var currIndex = alphabetSet.IndexOf(ciphertext[i].ToString());

            // Retrieve current index of key in alphabet
            var newIndex = alphabet.IndexOf(this.key[keyIndex]);

            // If new index is out of bounds
            if (currIndex - newIndex < 0)
            {
                builder.Append(alphabet[(alphabetSet.Count) + (currIndex - newIndex)]);
            }
            else
            {
                builder.Append(alphabet[currIndex - newIndex]);
            }

            if (keyIndex < this.key.Length - 1)
            {
                keyIndex++;
            }
            else
            {
                keyIndex = 0;
            }
        }

        return builder.ToString();
    }

    public static string RandomString(int length)
    {
        var randomizer = new Random();

        return new string(Enumerable.Repeat(alphabet, length).Select(s => s[randomizer.Next(s.Length)]).ToArray());
    }
}