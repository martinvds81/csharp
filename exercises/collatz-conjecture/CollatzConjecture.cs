using System;

public static class CollatzConjecture
{
    public static int Steps(int number)
    {
        if(number <= 0)
        {
            throw new ArgumentException("No negative numbers");
        }

        int stepCounter = 0;

        while (number != 1)
        {
            number = number.IsEven() ? number / 2 : number * 3 + 1;

            stepCounter++;
        }

        return stepCounter;
    }

    static bool IsEven(this int number) => number % 2 == 0;
}