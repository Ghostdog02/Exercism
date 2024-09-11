using System;
using System.Collections.Generic;
using System.Linq;

namespace Isogram
{
    public static class Isogram
    {
        public static bool IsIsogram(string word)
        {
            var lowerLetters = word.ToLowerInvariant().Where(char.IsLetter);
            return lowerLetters.Distinct().Count() == lowerLetters.Count();
        }


    }
}


