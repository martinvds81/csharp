using System;

public static class Grains
{
    /// <summary>
    /// Calculate the number of grains of wheat on a chessboard given that the number on each square doubles.
    /// </summary>
    /// <param name="n"></param>
    /// <returns></returns>
    public static ulong Square(int n)
    {
        // 1 = 1
        // 2 = 2
        // 3 = 4
        // 4 = 8
        // 5 = 16

        if(n <= 0)
        {
            throw new ArgumentOutOfRangeException("no negative numbers");
        }
        if (n > 64)
        {
            throw new ArgumentOutOfRangeException("number of squares is bigger then 64");
        }

        return (ulong)Math.Pow(2, n - 1);
    }

    public static ulong Total()
    {
        ulong total = 0UL;

        for (int i = 1; i < 65; i++)
        {
            total += Square(i);
        }

        return total;
    }
}