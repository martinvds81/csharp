using System.Collections.Generic;
using System.Text.RegularExpressions;

public static class RnaTranscription
{
    public static string ToRna(string nucleotide)
    {
        var replacements = new Dictionary<string, string>()
        {
           {"G","C"},
           {"C","G"},
           {"T","A"},
           {"A","U"},
        };

        var pattern = string.Join("|", replacements.Keys);
        var regex = new Regex(pattern);
        return regex.Replace(nucleotide, m => replacements[m.Value]);
    }
}