using System;
using System.Collections.Generic;
using System.Linq;

public class GradeSchool
{
    private readonly Dictionary<int, SortedSet<string>> roster = new Dictionary<int, SortedSet<string>>();

    public void Add(string student, int grade)
    {
        if (!roster.ContainsKey(grade))
        {
            roster.Add(grade, new SortedSet<string>());
        }

        roster[grade].Add(student);
    }

    public IEnumerable<string> Roster() => roster.OrderBy(r => r.Key).Select(r => r.Value).SelectMany(n => n);

    public IEnumerable<string> Grade(int grade) => !roster.ContainsKey(grade) ? Array.Empty<string>() : roster[grade].Select(r => r);
}