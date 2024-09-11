using System;
using System.Linq;

namespace BirdWatcher
{
    public class BirdCount
    {
        private int[] birdsPerDay;

        public BirdCount(int[] birdsPerDay)
        {
            this.birdsPerDay = birdsPerDay;
        }

        public static int[] LastWeek()
        {
            int[] lastWeekCounts = new int[] { 0, 2, 5, 3, 7, 8, 4 };
            return lastWeekCounts;
        }

        public int Today()
        {
            return birdsPerDay[6];
        }

        public void IncrementTodaysCount()
        {
            birdsPerDay[6] += 1;
        }

        public bool HasDayWithoutBirds()
        {
            return birdsPerDay.Any(a => a == 0);
        }

        public int CountForFirstDays(int firstDays)
        {
            int visitFromBirds = 0;
            for (int index = 0; index < firstDays; index++)
            {
                visitFromBirds += birdsPerDay[index];
            }
            return visitFromBirds;
        }

        public int BusyDays()
        {
            int count = 0;
            for (int index = 0; index < birdsPerDay.Length; index++)
            {
                if (birdsPerDay[index] >= 5)
                {
                    count++;
                }
            }
            return count;
        }



        public static void Main()
        {
            var counts = new int[] { 8, 8, 9, 2, 1, 6, 4 };
            var birdCount = new BirdCount(counts);
            
        }
    }
}
