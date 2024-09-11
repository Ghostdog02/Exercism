using System;

namespace CarsAsemble
{
    public class AssemblyLine
    {
        public static double SuccessRate(int speed)
        {
            double ratio = 0;
            if (speed == 0)
            {
                return ratio;
            }

            else if (speed >= 1 && speed <= 4)
            {
                ratio = 1;
                return ratio;
            }

            else if (speed >= 5 && speed <= 8)
            {
                ratio = 0.9;
                return ratio;

            }

            else if (speed == 9)
            {
                ratio = 0.8;
                return ratio;
            }

            else
            {
                ratio = 0.77;
                return ratio;
            }
        }

        public static double ProductionRatePerHour(int speed)
        {
            
            return speed * 221 * SuccessRate(speed);

        }

        public static int WorkingItemsPerMinute(int speed)
        {
            Console.WriteLine(((int)(ProductionRatePerHour(speed))) / 60);
            return ((int)(ProductionRatePerHour(speed))) / 60;
        }

        public static void Main()
        {
            WorkingItemsPerMinute(6);
        }
    }
}
