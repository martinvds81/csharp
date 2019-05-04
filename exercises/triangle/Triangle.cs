using System;
using System.Collections.Generic;
using System.Linq;

public static class Triangle
{
    public static bool IsScalene(double side1, double side2, double side3)
    {
        var sides = Sides(side1, side2, side3);
        return IsValidTriangle(sides) && sides.GroupBy(g => g).Count() == 3;
    }

    public static bool IsIsosceles(double side1, double side2, double side3)
    {
        var sides = Sides(side1, side2, side3);
        return IsValidTriangle(sides) && sides.GroupBy(g => g).Count() <= 2;
    }

    public static bool IsEquilateral(double side1, double side2, double side3)
    {
        var sides = Sides(side1, side2, side3);
        return IsValidTriangle(sides) && sides.GroupBy(g => g).Count() == 1;
    }

    public static bool IsValidTriangle(List<double> sides) =>
        sides[0] + sides[1] > sides[2] &&
        sides[2] + sides[0] > sides[1] &&
        sides[1] + sides[2] > sides[0];

    public static List<double> Sides(double side1, double side2, double side3) => new List<double>() { side1, side2, side3 };
}
