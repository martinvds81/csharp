using System;
using System.Collections.Generic;
using System.Linq;

public static class ScrabbleScore
{
    private static readonly Dictionary<int, char[]> _scoreList = new Dictionary<int, char[]>()
    {
        [1] = new char[] { 'A', 'E', 'I', 'O', 'U', 'L', 'N', 'R', 'S', 'T' },
        [2] = new char[] { 'D', 'G' },
        [3] = new char[] { 'B', 'C', 'M', 'P' },
        [4] = new char[] { 'F', 'H', 'V', 'W', 'Y' },
        [5] = new char[] { 'K' },
        [8] = new char[] { 'J', 'X' },
        [10] = new char[] { 'Q', 'Z' }
    };

    public static int Score(string input)
    {
        return input.ToUpperInvariant().ToCharArray().Select(c => GetScoreByCharacter(c)).Sum();
    }

    private static int GetScoreByCharacter(this char character) => _scoreList
        .SelectMany(l => l.Value.Select(s => new { letter = s, score = l.Key }))
        .FirstOrDefault(l => l.letter == character)
        .score;
}