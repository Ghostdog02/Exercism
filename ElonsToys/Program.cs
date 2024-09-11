using System;
using Xunit;

namespace ElonsToys
{
    public class RemoteControlCar
    {
        private int distance = 0;
        // calculating how many times distance is bigger than 20
        private int batteryPercentage = 100;

        public static RemoteControlCar Buy()
        {
            var remoteCar = new RemoteControlCar();
            return remoteCar;
        }

        public string DistanceDisplay()
        {
            Console.WriteLine($"Driven {distance} meters");
            return $"Driven {distance} meters";
        }

        public string BatteryDisplay()
        {
            if (batteryPercentage == 0)
            {
                Console.WriteLine($"Battery empty");
                return $"Battery empty";
            }
            Console.WriteLine($"Battery at {batteryPercentage}%");
            return $"Battery at {batteryPercentage}%";
        }

        public void Drive()
        {
            if (batteryPercentage == 0)
            {
                return;
            }

            else
            {
                distance += 20;
                batteryPercentage--;
            }

            
        }


    }

    public class Program
    {
        public static void Main()
        {
            var car = new RemoteControlCar();
            car.Drive();
            var test = car.DistanceDisplay();
            Assert.Equal("Driven 20 meters", car.DistanceDisplay());
        }
    }

}
