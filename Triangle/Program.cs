using System;

namespace Triangle
{
    class Program
    {
        public static class Triangle
        {
            public static bool IsScalene(double a, double b, double c) =>
                IsTriangle(a, b, c) && (a != b && b != c && c != a);


            public static bool IsIsosceles(double a, double b, double c) =>
                IsTriangle(a, b, c) && (a == b || b == c || c == a);


            public static bool IsEquilateral(double a, double b, double c) =>
                 IsTriangle(a, b, c) && (a == b && b == c && c == a);

            public static bool IsTriangle(double a, double b, double c) => 
                a + b >= c && c + b >= a && a + c >= b && (a, b, c) != (0, 0, 0);

            static void Main()
            {
                IsEquilateral(0, 0, 0);
            }
        }


    }
}
