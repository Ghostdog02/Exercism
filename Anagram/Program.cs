using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Anagram
{
    public class Anagram
    {
        List<string> anagrams = new List<string>();
        public string BaseWord = string.Empty;
        public Anagram(string baseWord)
        {
            BaseWord = baseWord;
        }

        public string[] FindAnagrams(string[] potentialMatches)
        {
            foreach (var match in potentialMatches)
            {
                //if (Word.ToLower() != match.ToLower() && CalculateTotalAsciValue(Word.ToLower()) == CalculateTotalAsciValue(match.ToLower()))
                //{
                //    anagrams.Add(match);
                //}
                byte[] asciBaseWord = Encoding.ASCII.GetBytes(BaseWord.ToLower());
                Array.Sort(asciBaseWord);
                byte[] asciMatch = Encoding.ASCII.GetBytes(match.ToLower());
                Array.Sort(asciMatch);

                if (BaseWord.ToLower() != match.ToLower() && Enumerable.SequenceEqual(asciBaseWord, asciMatch))
                {
                    anagrams.Add(match);
                }


            }
            return anagrams.ToArray();
        }

        public int CalculateTotalAsciValue(string word)
        {
            byte[] asciiBytes = Encoding.ASCII.GetBytes(word);
            int total = 0;
            Array.ForEach(asciiBytes, delegate (byte i) { total += i; });
            return total;
        }

        static void Main()
        {
            var candidates = new[]
            {
                "enlists",
                "google",
                "inlets",
                "banana"
            };

            Anagram anagram = new Anagram("listen");
            anagram.FindAnagrams(candidates);
        }
    }
}
