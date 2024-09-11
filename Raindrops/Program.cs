using System;
using System.Collections.Generic;
using System.Text;

namespace Raindrops
{
    public static class Raindrops
    {
        public static string Convert(int number)
        {
            var result = new StringBuilder();
            var raindrops = new Dictionary<int, string>()
            {
                [3] = "Pling",
                [5] = "Plang",
                [7] = "Plong"
            };

            for (int i = 1; i <= number; i++)
            {
                if (raindrops.ContainsKey(i) && (number % i == 0))
                {
                    result.Append(raindrops[i]);
                }
            }

            return result.Length == 0 ? $"{number}" : result.ToString();
        }

        static void Main()
        {
            Convert(3);
        }
    }
}
