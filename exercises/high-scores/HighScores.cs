using System.Collections.Generic;
using System.Linq;

public class HighScores
{
    private List<int> _scoreList = new List<int>();

    public HighScores(List<int> list)
    {
        _scoreList = list;
    }

    public List<int> Scores()
    {
        return _scoreList;
    }

    public int Latest()
    {
        return _scoreList.Last();
    }

    public int PersonalBest()
    {
        return _scoreList.Max();
    }

    public List<int> PersonalTopThree()
    {
        var count = _scoreList.Count < 3 ? _scoreList.Count : 3;
        return _scoreList.OrderByDescending(l => l).Take(count).ToList();
    }
}