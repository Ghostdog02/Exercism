using System;
using System.Globalization;

namespace HighSchoolSweethearts
{
    public static class HighSchoolSweethearts
    {
        public static string DisplaySingleLine(string studentA, string studentB)
        {
            return $"{studentA,29} ♡ {studentB,-29}";
        }

        public static string DisplayBanner(string studentA, string studentB)
        {
            string heart = $@"******       ******
   **      **   **      **
 **         ** **         **
**            *            **
**                         **
** {studentA,10} +  {studentB,-10}**
 **                       **
   **                   **
     **               **
       **           **
         **       **
           **   **
             ***
              *";
            return heart;
        }

        public static string DisplayGermanExchangeStudents(string studentA, string studentB, DateTime start, float hours)
        {
            var hoursFormatted = hours.ToString("##,#.##", new CultureInfo("de-DE"));
            //var hoursFormatted = hours.ToString(new CultureInfo("de-DE"));
            string output = $"{studentA} and {studentB} have been dating since {start:dd.MM.yyyy} - that's {hoursFormatted} hours";
                //dateOnly.ToString(new CultureInfo("de-DE")));
            return output;
        }
    }
}

