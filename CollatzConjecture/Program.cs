using System;
using System.Numerics;

namespace CollatzConjecture
{
    public static class CollatzConjecture
    {
        public static BigInteger Steps(BigInteger number)
        {
            if (number == 0 || number < 0)
            {
                throw new ArgumentException();
            }
            BigInteger count = 0;

            while (number != 1)
            {
                if (number % 2 == 0)
                {
                    number /= 2;
                    Console.WriteLine($"num is {number}");
                    count++;
                }

                else
                {
                    number = (number * 3) + 1;
                    Console.WriteLine($"num is {number}");
                    count++;
                }
            }
            Console.WriteLine($"count = {count}");
            return count;
            
        }

        static void Main()
        {
            BigInteger n = BigInteger.Parse(Console.ReadLine());
            Steps(n);
        }
    }
}
