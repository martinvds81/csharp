using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Robot
{
    private static HashSet<string> _nameHistory = new HashSet<string>();
    private readonly Random _random = new Random();

    public Robot()
    {
        Reset();
    }

    public string Name { get; private set; }

    public void Reset()
    {
        var robotName = GenerateRobotName();
        int max = 0;
        while (_nameHistory.Contains(robotName))
        {
            robotName = GenerateRobotName();

            max++;

            if (max >= 10000)
            {
                throw new ArgumentException("The robots are coming!");
            }
        }

        _nameHistory.Add(robotName);
        Name = robotName;
    }

    public string GenerateRobotName()
    {
        var builder = new StringBuilder();
        builder.Append(RandomString(2));
        builder.Append(RandomNumber());
        return builder.ToString();
    }

    public string RandomString(int length)
    {
        return new string(Enumerable.Repeat("ABCDEFGHIJKLMNOPQRSTUVWXYZ", length).Select(s => s[_random.Next(s.Length)]).ToArray());
    }

    public string RandomNumber()
    {
        return _random.Next(0, 999).ToString("000");
    }
}