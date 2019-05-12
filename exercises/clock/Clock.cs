using System;

public class Clock : IEquatable<Clock>
{
    private TimeSpan _currentTime;

    public Clock(int hours, int minutes)
    {
        while (minutes < 0)
        {
            minutes = minutes + 60;
            hours--;
        }

        while (hours < 0)
        {
            hours = hours + 24;
        }

        _currentTime = new TimeSpan(hours, minutes, 0);
    }

    public int Hours => _currentTime.Hours;
    public int Minutes => _currentTime.Minutes;

    public Clock Add(int minutesToAdd)
    {
        var changeTime = new TimeSpan(0, minutesToAdd, 0);

        var newTime = _currentTime + changeTime;

        return new Clock(newTime.Hours, newTime.Minutes);
    }

    public Clock Subtract(int minutesToSubtract)
    {
        var changeTime = new TimeSpan(0, minutesToSubtract, 0);

        var newTime = _currentTime - changeTime;

        return new Clock(newTime.Hours, newTime.Minutes);
    }
    public bool Equals(Clock other) => Hours == other.Hours && Minutes == other.Minutes;

    public override string ToString() => new DateTime(_currentTime.Ticks).ToString("HH:mm");
}