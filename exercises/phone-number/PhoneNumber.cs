using System;
using System.Text.RegularExpressions;

public class PhoneNumber
{
    public static string Clean(string phoneNumber)
    {
        // First remove all non digits
        phoneNumber = Regex.Replace(phoneNumber, @"[^\d]", "");

        // Validate the cleandup phone number
        var match = Regex.Match(phoneNumber, "(^1?)(?<valid>[2-9]{3}[2-9]{1}[0-9]{3}[0-9]{3})$");
        if(!match.Success)
        {
            throw new ArgumentException("Invalid number");
        }

        return match.Groups["valid"].Value;
    }
}