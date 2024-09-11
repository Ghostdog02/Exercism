using System;
using System.Globalization;
using System.Runtime.InteropServices;

namespace BeautySalonGlobal
{
    public enum Location
    {
        NewYork,
        London,
        Paris
    }

    public enum AlertLevel
    {
        Early,
        Standard,
        Late
    }

    public static class Appointment
    {
        private static string GetZoneName(Location location)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                return location switch
                {
                    Location.NewYork => "America/New_York",
                    Location.London => "Europe/London",
                    Location.Paris => "Europe/Paris",
                    _ => string.Empty
                };
            }

            else
            {
                return location switch
                {
                    Location.NewYork => "Eastern Standard Time",
                    Location.London => "GMT Standard Time",
                    Location.Paris => "W. Europe Standard Time",
                    _ => string.Empty
                };
            }
        }

        static void Main()
        {
            //Console.WriteLine(Appointment.NormalizeDateTime("25/11/2019 13:45:00", Location.NewYork));

            var test = Appointment.Schedule("25/07/2019 08:45:00", Location.NewYork);
        }

        public static DateTime ShowLocalTime(DateTime dtUtc)
        {
            return dtUtc.ToLocalTime();
        }

        public static DateTime Schedule(string appointmentDateDescription, Location location)
        {

            DateTime dateTime = DateTime.Parse(appointmentDateDescription);
            string zoneName = GetZoneName(location);
            //return /*TimeZoneInfo.ConvertTimeBySystemTimeZoneId(dateTime, zoneName).ToUniversalTime();*/

            //var test =  TimeZoneInfo.ConvertTimeBySystemTimeZoneId(dateTime, zoneName);

            TimeZoneInfo timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById(zoneName);
            var realResult =  TimeZoneInfo.ConvertTimeToUtc(dateTime, timeZoneInfo);

            return realResult;
        }

        public static DateTime GetAlertTime(DateTime appointment, AlertLevel alertLevel)
        {
            if (alertLevel == AlertLevel.Early)
            {
                return appointment.Add(TimeSpan.FromDays(-1));
            }

            else if (alertLevel == AlertLevel.Late)
            {
                return appointment.Add(TimeSpan.FromMinutes(-30));
            }

            else
            {
                return appointment.Add(TimeSpan.FromMinutes(-105));
            }
        }

        public static bool HasDaylightSavingChanged(DateTime dt, Location location)
        {
            DateTime beginning = dt.AddDays(-7);
            string zoneName = GetZoneName(location);
            TimeZoneInfo zoneInfo = TimeZoneInfo.FindSystemTimeZoneById(zoneName);
            bool currentIsDaylight = zoneInfo.IsDaylightSavingTime(beginning);
            DateTime currentDate = beginning.AddDays(1);

            while (currentDate <= dt)
            {
                if (currentIsDaylight != zoneInfo.IsDaylightSavingTime(currentDate))
                {
                    return true;
                }

                currentDate = currentDate.AddDays(1);
            }

            return false;
        }

        //public static DateTime Next(this DateTime date, DayOfWeek dayOfWeek)
        //{
        //    return date.AddDays((dayOfWeek < date.DayOfWeek ? 7 : 0) + dayOfWeek - date.DayOfWeek);
        //}

        //public static DateTime GetNthWeekofMonth(DateTime date, int nthWeek, DayOfWeek dayOfWeek)
        //{
        //    return date.Next(dayOfWeek).AddDays((nthWeek - 1) * 7);
        //}

        public static CultureInfo GetCultureInfo(Location location)
        {
            return location switch
            {
                Location.NewYork => new CultureInfo("en-US", false), //MMM d, yyyy
                Location.London => new CultureInfo("en-GB", false), //dd-MMM-yyyy
                Location.Paris => new CultureInfo("fr-FR", false), //d MMM yyyy
                _ => new CultureInfo(0, false)
            };
        }

        public static DateTime NormalizeDateTime(string dtStr, Location location)
        {

            string zoneName = GetZoneName(location);

            try
            {
                DateTime appointmentDate = DateTime.Parse(dtStr, GetCultureInfo(location));

                return appointmentDate;
            }
            catch (FormatException)
            {

                return DateTime.MinValue;
            }




        }
    }
}
