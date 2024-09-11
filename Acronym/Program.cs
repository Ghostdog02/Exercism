using System;
using System.Text;
using System.Linq;

namespace Acronym
{
    public static class Acronym
    {
        public static string Abbreviate(string phrase)
        {
            //StringBuilder abbreviation = new StringBuilder();
            //phrase = phrase.Replace(("_"), string.Empty);
            //string[] seperators = { " ", " - ", "-" };
            ////emails.Split(',').Select(email => email.Trim()).ToArray()
            //string[] words = phrase.Split(seperators, StringSplitOptions.None);
            //foreach (var word in words)
            //{
            //    if (word != "-" && word != "")
            //    {
            //        abbreviation.Append(word[0]);
            //    }

            //}

            //phrase.Split(seperators, StringSplitOptions.remove).Where();

            //return abbreviation.ToString().ToUpperInvariant();

            string[] seperators = new[] { " ", "-", "_" };
            var abbreviations =
                phrase.Split(seperators, StringSplitOptions.RemoveEmptyEntries)
                .Select(a => char.ToUpper(a.First()))
                .ToArray();
            return new string(abbreviations);
        }

        //public static string Abbreviate(string phrase)
        //    => new string(phrase.Split(new[] { " ", "-" }, StringSplitOptions.RemoveEmptyEntries).Select(a => char.ToUpper(a.First())).ToArray());

        public static void Main()
        {
            
            Console.WriteLine(Abbreviate("Something - I made up from thin air"));
        }
    }
}
