﻿using System;
using Xunit;

namespace BuildingTelemetry
{
    public class RemoteControlCar
    {
        private int batteryPercentage = 100;
        private int distanceDrivenInMeters = 0;
        private string[] sponsors = new string[0];
        private int latestSerialNum = 0;

        public void Drive()
        {
            if (batteryPercentage > 0)
            {
                batteryPercentage -= 10;
                distanceDrivenInMeters += 2;
            }
        }

        public void SetSponsors(params string[] sponsors)
        {
            this.sponsors = new string[sponsors.Length];
            for (int index = 0; index < sponsors.Length; index++)
            {
                this.sponsors[index] = sponsors[index];
            }
        }

        public string DisplaySponsor(int sponsorNum)
        {
            return sponsors[sponsorNum];
        }

        public bool GetTelemetryData(ref int serialNum,
            out int batteryPercentage, out int distanceDrivenInMeters)
        {
            if (serialNum < latestSerialNum)
            {
                batteryPercentage = -1;
                distanceDrivenInMeters = -1;
                serialNum = Math.Max(serialNum, latestSerialNum);
                this.latestSerialNum = serialNum;
                return false;
            }

            else
            {
                batteryPercentage = this.batteryPercentage;
                distanceDrivenInMeters = this.distanceDrivenInMeters;
                this.latestSerialNum = serialNum;
                return true;

            }
        }

        public static RemoteControlCar Buy()
        {
            return new RemoteControlCar();
        }
    }

    public class TelemetryClient
    {
        private RemoteControlCar car;

        private int batteryPercentage = 0;
        private int distanceDrivenInMeters = 0;

        public TelemetryClient(RemoteControlCar car)
        {
            this.car = car;
        }

        public string GetBatteryUsagePerMeter(int serialNum)
        {
            if (car.GetTelemetryData(ref serialNum, out batteryPercentage, out distanceDrivenInMeters) && distanceDrivenInMeters != 0)
            {
                return $"usage-per-meter={(100 - batteryPercentage) / distanceDrivenInMeters}";
                
            }

            else
            {
                return "no data";
            }


        }
    }

    public class Program
    {
        static void Main()
        {
            var car = RemoteControlCar.Buy();
            car.Drive();
            car.Drive();
            var tc = new TelemetryClient(car);
            Assert.Equal("usage-per-meter=5", tc.GetBatteryUsagePerMeter(serialNum: 1));
        }
    }
}
