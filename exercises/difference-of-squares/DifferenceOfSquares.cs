using System;
using System.Linq;

public static class DifferenceOfSquares
{
    public static int CalculateSquareOfSum(int n)
    {
        return n * n * (n + 1) * (n + 1) / 4;

    }

    public static int CalculateSumOfSquares(int n)
    {
        return n * (n + 1) * (2 * n + 1) / 6;
    }

    public static int CalculateDifferenceOfSquares(int max)
    {
        return CalculateSquareOfSum(max) - CalculateSumOfSquares(max);
    }
}