using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace TracksOnTracksOnTracks
{
    public static class Languages
    {
        public static void Main()
        {

        }

        public static List<string> NewList()
        {
            return new List<string>();
        }

        public static List<string> GetExistingLanguages()
        {
            var list = NewList();
            list.Add("C#");
            list.Add("Clojure");
            list.Add("Elm");
            return list;

        }

        public static List<string> AddLanguage(List<string> languages, string language)
        {
            languages.Add(language);
            return languages;
        }

        public static int CountLanguages(List<string> languages)
        {
            return languages.Count;
        }

        public static bool HasLanguage(List<string> languages, string language)
        {
            return languages.Contains(language);
        }

        public static List<string> ReverseList(List<string> languages)
        {
            languages.Reverse();
            return languages;
        }

        public static bool IsExciting(List<string> languages)
        {
            if (languages.Count != 0)
            {
                if (languages[0] == "C#" || (languages[1] == "C#" && (languages.Count == 2 || languages.Count == 3)))
                {
                    return true;
                }

                else
                {
                    return false;
                }
            }

            else
            {
                 return false;
            }
            
        }

        public static List<string> RemoveLanguage(List<string> languages, string language)
        {
            languages.Remove(language);
            return languages;
        }

        public static bool IsUnique(List<string> languages)
        {

            if (languages.Count != languages.Distinct().Count())
            {
                return false;
            }

            else
            {
                return true;
            }





        }
    }
}

