using System;
using System.Text;

public static class BeerSong
{
    /// <summary>
    /// Fast and simple for + stringbuilder
    /// </summary>
    /// <param name="startBottles"></param>
    /// <param name="takeDown"></param>
    /// <returns></returns>
    public static string Recite(int startBottles, int takeDown = 10)
    {
        var builder = new StringBuilder();

        for (var j = takeDown - 1; j >= 0; j--)
        {
            switch (startBottles)
            {
                case 0:
                    {
                        builder.Append(
                            "No more bottles of beer on the wall, no more bottles of beer.\n" +
                            "Go to the store and buy some more, 99 bottles of beer on the wall.");
                        break;
                    }
                case 1:
                    {
                        builder.Append(
                            "1 bottle of beer on the wall, 1 bottle of beer.\n" +
                            "Take it down and pass it around, no more bottles of beer on the wall.");
                        --startBottles;
                        break;
                    }
                default:
                    {
                        builder.Append(
                            $"{startBottles} bottles of beer on the wall, {startBottles} bottles of beer.\n" +
                            $"Take one down and pass it around, {--startBottles} {startBottles.PluralBottle()} of beer on the wall.");
                        break;
                    }
            }
            if (j > 0)
            {
                builder.Append("\n\n");
            }
        }

        return builder.ToString();
    }

    public static string PluralBottle(this int bottles) => (bottles) > 1 ? "bottles" : "bottle";
}