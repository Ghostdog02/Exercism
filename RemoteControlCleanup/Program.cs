using System;

namespace RemoteControlCleanup
{
    public class RemoteControlCar
    {
        public RemoteControlCar()
        {
            Telemetry = new TelemetryClass(this);
        }


        public string CurrentSponsor { get; private set; }

        private Speed currentSpeed;

        // TODO encapsulate the methods suffixed with "_Telemetry" in their own class
        // dropping the suffix from the method name


        public string GetSpeed()
        {
            return currentSpeed.ToString();
        }

        private void SetSponsor(string sponsorName)
        {
            CurrentSponsor = sponsorName;

        }

        private void SetSpeed(Speed speed)
        {
            currentSpeed = speed;
        }

        public interface ITelemetry
        {
            public void ShowSponsor(string sponsorName);

            public void SetSpeed(decimal amount, string unitsString);
        }

        public ITelemetry Telemetry { get; private set; }

        private class TelemetryClass : ITelemetry
        {
            RemoteControlCar _remoteControlCar;

            public TelemetryClass(RemoteControlCar remoteControlCar)
            {
                _remoteControlCar = remoteControlCar;
            }

            public void Calibrate()
            {

            }

            public bool SelfTest()
            {
                return true;
            }

            public void ShowSponsor(string sponsorName)
            {
                _remoteControlCar.SetSponsor(sponsorName);
            }

            public void SetSpeed(decimal amount, string unitsString)
            {
                SpeedUnits speedUnits = SpeedUnits.MetersPerSecond;
                if (unitsString == "cps")
                {
                    speedUnits = SpeedUnits.CentimetersPerSecond;
                }

                _remoteControlCar.SetSpeed(new Speed(amount, speedUnits));
            }
        }
    }

    internal enum SpeedUnits
    {
        MetersPerSecond,
        CentimetersPerSecond
    }

    internal struct Speed
    {
        public decimal Amount { get; }
        public SpeedUnits SpeedUnits { get; }

        public Speed(decimal amount, SpeedUnits speedUnits)
        {
            Amount = amount;
            SpeedUnits = speedUnits;
        }

        public override string ToString()
        {
            string unitsString = "meters per second";
            if (SpeedUnits == SpeedUnits.CentimetersPerSecond)
            {
                unitsString = "centimeters per second";
            }

            return Amount + " " + unitsString;
        }
    }
}
