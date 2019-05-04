using System;

public static class Darts
{
    public static int Score(double x, double y)
    {
        var distance = Math.Sqrt(x * x + y * y);
        return distance <= 1 ? 10 : distance <= 5 ? 5 : distance <= 10 ? 1 : 0;
    }
}
