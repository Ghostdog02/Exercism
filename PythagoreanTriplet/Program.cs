using System;
using System.Collections.Generic;
using System.Linq;

public static class PythagoreanTriplet
{
    public static IEnumerable<(int a, int b, int c)> TripletsWithSum(int sum)
    {
        var triplets = new List<(int a, int b, int c)>();

        for (int a = 1; a < sum / 3; a++)
        {
            for (int b = a + 1; b < sum / 2; b++)
            {
                var c = sum - a - b;
                if (a * a + b * b == c * c)
                {
                    triplets.Add((a, b, c));
                }
            }
        }

        return triplets;
    }

    static void Main()
    {
        var Time = DateTime.Now;
        var triplets = TripletsWithSum(100000);
        Console.WriteLine((DateTime.Now - Time).TotalMilliseconds);
        // Print or process the triplets as needed
        // foreach (var triplet in triplets)
        // {
        //     Console.WriteLine($"({triplet.a}, {triplet.b}, {triplet.c})");
        // }
    }
}
