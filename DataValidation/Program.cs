using System;

namespace DataValidation
{
    public class Program
    {
        static void Main()
        {
            Console.WriteLine($"What time is it");
            Console.Write($"Hours: ");
            int hours = int.Parse(Console.ReadLine());
            Console.Write($"Minutes: ");
            int minutes = int.Parse(Console.ReadLine());

            if (CheckHours(hours) && CheckMinutes(minutes) == true)
            {
                Console.WriteLine($"The time is {hours}:{minutes} now.");
            }
        }

        static bool CheckHours(int hours)
        {
            if (hours >= 0 && hours <= 23 )
            {
                return true;
            }

            else
            {
                Console.WriteLine($"Invalid hours!");
                return false;
            }
        }

        static bool CheckMinutes(int minutes)
        {
            if (minutes >= 0 && minutes <= 59)
            {
                return true;
            }

            else
            {
                Console.WriteLine($"Invalid minutes!");
                return false;
            }
        }
    }
}
