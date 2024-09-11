using System;

namespace HyperinflationHitsHyperia
{
    public static class CentralBank
    {
        public static string DisplayDenomination(long @base, long multiplier)
        {
            try
            {
                string denomination = checked(@base * multiplier).ToString();
                return denomination;
            }
            catch (OverflowException)
            {

                return "*** Too Big ***";
            }



        }

        public static string DisplayGDP(float @base, float multiplier)
        {

            float gdp = @base * multiplier;

            if (double.IsInfinity(gdp))
            {
                return "*** Too Big ***";
            }

            else
            {
                return gdp.ToString();
            }
        }

        public static string DisplayChiefEconomistSalary(decimal salaryBase, decimal multiplier)
        {
            try
            {
                string denomination = checked(salaryBase * multiplier).ToString();
                return denomination;
            }
            catch (OverflowException)
            {

                return "*** Much Too Big ***";
            }
        }

        public static void Main()
        {
            Console.WriteLine(DisplayGDP(float.MaxValue / 2L, 10000f));
        }
    }
}
