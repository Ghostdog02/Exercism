using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Xunit;

namespace ParsingLogFiles
{
    public class LogParser
    {
        public bool IsValidLine(string text) => Regex.IsMatch(text, @"^\[(ERR|TRC|DBG|INF|WRN|FTL)\]");

        public string[] SplitLogLine(string text) => Regex.Split(text, @"<[\^*=-]*>");

        public int CountQuotedPasswords(string lines) => Regex.Matches(lines, ".*\".*(passWord).*\".*", RegexOptions.IgnoreCase).Count;

        public string RemoveEndOfLineText(string line) => Regex.Replace(line, "(end-of-line)\\d*", "");

        public string[] ListLinesWithPasswords(string[] lines)
        {
            string[] listedLines = new string[lines.Length];
            for (int i = 0; i < lines.Length; i++)
            {
                if (Regex.Matches(lines[i], "(password)\\w*", RegexOptions.IgnoreCase).Count != 1)
                {
                    var match = Regex.Match(lines[i], "(password)\\w*", RegexOptions.IgnoreCase).NextMatch().ToString();
                    IsEqual(match, listedLines[i], lines[i]);
                    listedLines[i] = IsEqual(match, listedLines[i], lines[i]);

                }

                else
                {
                    var match = Regex.Match(lines[i], "(password)\\w*", RegexOptions.IgnoreCase).ToString();
                    listedLines[i] = IsEqual(match, listedLines[i], lines[i]);
                }

            }

            return listedLines;
        }

        public string IsEqual(string match, string listedLines, string lines)
        {

            if (Regex.Equals($"{match.ToLower()}", "password"))
            {
                return listedLines = $"--------: {lines}";
            }

            else
            {
                return listedLines = $"{match}: {lines}";
            }
        }
    }

    public static class Program
    {
        static void Main()
        {
            var lp = new LogParser();
            string[] lines = { "[INF] passWordaa", "passWord mysecret", "[INF] password KeyToTheCastle for nobody", "[INF] password password123 for everybody" };
            string[] expected = { "passWordaa: [INF] passWordaa", "--------: passWord mysecret", "--------: [INF] password KeyToTheCastle for nobody", "password123: [INF] password password123 for everybody" };
            Assert.Equal(expected, lp.ListLinesWithPasswords(lines));
        }
    }
}
