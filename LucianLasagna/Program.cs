using System;

namespace LucianLasagna
{
    public class Lasagna
    {
        public int ExpectedMinutesInOven()
        {
            return 40;
        }

        public int RemainingMinutesInOven(int passedMinutes)
        {

            return ExpectedMinutesInOven() - passedMinutes;
        }

        public int PreparationTimeInMinutes(int layers)
        {
            return layers * 2;
        }

        public int ElapsedTimeInMinutes(int layers, int passedMinutes)
        {
            return PreparationTimeInMinutes(layers) + passedMinutes;
        }
    }

    public class Program
    {
        public static void Main()
        {
            var lasagna = new Lasagna();
            lasagna.RemainingMinutesInOven(30);
            lasagna.ElapsedTimeInMinutes(5, 30);
        }
    }
}

