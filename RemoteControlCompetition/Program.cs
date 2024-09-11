using System;
using System.Collections.Generic;

namespace RemoteControlCompetition
{
    public interface IComparable<T>
    {
        int CompareTo(T other);
    }

    public interface IRemoteControlCar
    {
        public int DistanceTravelled { get; set; }
        public int NumberOfVictories { get; set; }
        public void Drive();

    }

    public class ProductionRemoteControlCar : IRemoteControlCar, IComparable
    {
        public int CompareTo(object incomingobject)
        {
            ProductionRemoteControlCar remoteControlCar = (ProductionRemoteControlCar)incomingobject;
            return this.NumberOfVictories.CompareTo(remoteControlCar.NumberOfVictories);
        }
        public int DistanceTravelled { get; set; }
        public int NumberOfVictories { get; set; }

        public void Drive()
        {
            DistanceTravelled += 10;
        }
    }

    public class ExperimentalRemoteControlCar : IRemoteControlCar
    {
        public int CompareTo(object incomingobject)
        {
            ExperimentalRemoteControlCar remoteControlCar = (ExperimentalRemoteControlCar)incomingobject;
            return this.NumberOfVictories.CompareTo(remoteControlCar.NumberOfVictories);

        }
        public int DistanceTravelled { get; set; }
        public int NumberOfVictories { get; set; }

        public void Drive()
        {
            DistanceTravelled += 20;
        }
    }

    public static class TestTrack
    {
        public static void Race(IRemoteControlCar car)
        {
            car.Drive();

        }

        public static List<ProductionRemoteControlCar> GetRankedCars(ProductionRemoteControlCar prc1,
            ProductionRemoteControlCar prc2)
        {
            List<ProductionRemoteControlCar> productions = new List<ProductionRemoteControlCar> { prc1, prc2 };
            productions.Sort();
            return productions;
        }
    }

    public static class Program
    {
        static void Main()
        {
            var productionCar = new ProductionRemoteControlCar();
            var experimentalCar = new ExperimentalRemoteControlCar();
            TestTrack.Race((IRemoteControlCar)productionCar);
            TestTrack.Race((IRemoteControlCar)productionCar);
            TestTrack.Race((IRemoteControlCar)experimentalCar);
            TestTrack.Race((IRemoteControlCar)experimentalCar);
            bool isEqual = (20 == experimentalCar.DistanceTravelled - productionCar.DistanceTravelled);
            Console.WriteLine(isEqual);
        }
    }

}
