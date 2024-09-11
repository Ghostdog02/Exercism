using System;
using System.Globalization;

namespace BookingForBeauty
{
    public class Appointment
    {
        public static DateTime Schedule(string date)
        {
            return DateTime.Parse(date);

        }

        public static bool HasPassed(DateTime appoinment)
        {
            if (DateTime.Now > appoinment)
            {
                return true;
            }

            else
            {
                return false;
            }
        }

        public static bool IsAfternoonAppointment(DateTime appoinment)
        {
            if (appoinment.Hour >= 12 && appoinment.Hour < 18)
            {
                return true;
            }

            else
            {
                return false;
            }
        }

        public static string Description(DateTime appointment)
        {
            string appointmentParsed = appointment.ToString("G", CultureInfo.CreateSpecificCulture("en-us"));
            return $"You have an appointment on {appointmentParsed}.";

        }

        public static DateTime AnniversaryDate()
        {
            DateTime date = DateTime.Now;
            DateTime dateTime = new DateTime(date.Year, 9, 15, 0, 0, 0);
            return dateTime;
        }

        public static void Main()
        {
            Console.WriteLine(Schedule("July 25, 2019 13:45:00"));
        }
    }
}
