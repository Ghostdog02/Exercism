using System;

namespace NeedForSpeed
{
    public class RemoteControlCar
    {
        public int speedInMetres;
        public int batteryDrain;
        public int metresDriven;
        public int battery = 100;

        public RemoteControlCar(int speedInMetres, int batteryDrainPercentage)
        {
            this.speedInMetres = speedInMetres;
            this.batteryDrain = batteryDrainPercentage;
        }

        public void Drive()
        {
            if (battery == 0 || battery < batteryDrain)
            {
                //Do nothing:
            }

            else
            {
                metresDriven += speedInMetres;
                battery -= batteryDrain;
            }

        }

        public int DistanceDriven()
        {
            return metresDriven;

        }

        public bool BatteryDrained()
        {
            if (battery == 0 || battery < batteryDrain)
            {
                return true;
            }

            else
            {
                return false;
            }

        }

        public static RemoteControlCar Nitro()
        {
            RemoteControlCar remoteControlCarNitro = new RemoteControlCar(50, 4);
            return remoteControlCarNitro;
        }

        public static void Main()
        {

        }
    }

    public class RaceTrack
    {
        private int distanceInMetres;
        // TODO: define the constructor for the 'RaceTrack' class
        public RaceTrack(int distanceInMetres)
        {
            this.distanceInMetres = distanceInMetres;
        }

        public bool TryFinishTrack(RemoteControlCar car)
        {
            int metresDriven = 0;
            while (metresDriven != distanceInMetres)
            {

                metresDriven += car.speedInMetres;
                car.battery -= car.batteryDrain;
                if (car.battery == 0 || car.battery < car.batteryDrain)
                {
                    break;
                }

            }

            if (metresDriven == distanceInMetres)
            {
                return true;
            }

            else
            {
                return false;
            }



        }

    }
}


