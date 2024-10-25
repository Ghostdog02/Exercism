using System;

namespace RangeBetweenTwoMonths
{
    public class Program
    {
        static void Main()
        {
            Console.Write($"Enter first month from the range 1 to 12: ");
            int firstMonth = int.Parse(Console.ReadLine());
            Console.Write($"Enter second month from the range 1 to 12: ");
            int secondMonth = int.Parse(Console.ReadLine());
            SayRange(firstMonth, secondMonth);
        }

        static void SayRange(int firstMonth, int secondMonth)
        {
            int range = secondMonth - firstMonth;

            if (range < 0)
            {
                range += 12;
            }

            Console.WriteLine($"There is a {range} months period from {GetMonth(firstMonth)} to {GetMonth(secondMonth)}.");
        }

        static string GetMonth(int month)
        {
            string monthName;

            switch (month)
            {
                case 1:
                    monthName = "January";
                    break;
                case 2:
                    monthName = "February";
                    break;
                case 3:
                    monthName = "March";
                    break;
                case 4:
                    monthName = "April";
                    break;
                case 5:
                    monthName = "May";
                    break;
                case 6:
                    monthName = "June";
                    break;
                case 7:
                    monthName = "July";
                    break;
                case 8:
                    monthName = "August";
                    break;
                case 9:
                    monthName = "September";
                    break;
                case 10:
                    monthName = "October";
                    break;
                case 11:
                    monthName = "November";
                    break;
                case 12:
                    monthName = "December";
                    break;
                default:
                    Console.WriteLine($"Invalid month!");
                    return null;
            }

            return monthName;
        }
    }
}
