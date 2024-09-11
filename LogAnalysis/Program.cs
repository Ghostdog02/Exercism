using System;

namespace LogAnalysis
{
    public static class LogAnalysis
    {
        static string SubstringAfter(this string log, string delimiter)
        {
            return log.Substring(log.IndexOf(delimiter) + 2);

        }

        static string SubstringBetween(this string log, string delimiter1, string delimiter2)
        {
            int dilimiterIndex = log.IndexOf(delimiter2);
            int substringLenght = dilimiterIndex - 1;
            return log.Substring(dilimiterIndex, substringLenght);
        }

        static string Message(string log)
        {
            return log.SubstringAfter(": ");
        }

        static string LogLevel(string log)
        {
            return log.SubstringBetween("[", "]");
        }

        static void Main()
        {
            var log = "[INFO]: File Deleted.";
            Console.WriteLine(log.SubstringAfter(": ")); // => returns "File Deleted."
            Console.WriteLine(log.SubstringBetween("[", "]")); 

        }

        // TODO: define the 'SubstringBetween()' extension method on the `string` type

        // TODO: define the 'Message()' extension method on the `string` type

        // TODO: define the 'LogLevel()' extension method on the `string` type
    }
}
