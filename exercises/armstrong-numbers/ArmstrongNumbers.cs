using System;
using System.Collections.Generic;
using System.Linq;

public static class ArmstrongNumbers
{
    public static bool IsArmstrongNumber(int number)
    {
        var digits = number.GetDigits().Reverse().ToList();
        var power = digits.Count();

        return Enumerable.Range(0, power).Sum(x => Math.Pow(digits[x], power)) == number;
    }

    public static IEnumerable<int> GetDigits(this int number)
    {
        while (number > 0)
        {
            var digit = number % 10;
            number /= 10;
            yield return digit;
        }
    }
}