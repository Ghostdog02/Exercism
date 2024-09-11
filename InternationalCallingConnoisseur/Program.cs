using System;
using System.Collections.Generic;
using System.Linq;

namespace InternationalCallingConnoisseur
{
    public static class DialingCodes
    {
        public static Dictionary<int, string> GetEmptyDictionary()
        {
            return new Dictionary<int, string>();
        }

        public static Dictionary<int, string> GetExistingDictionary()
        {
            var emptyDictionary = GetEmptyDictionary();
            emptyDictionary[1] = "United States of America";
            emptyDictionary[55] = "Brazil";
            emptyDictionary[91] = "India";
            return emptyDictionary;
        }

        public static Dictionary<int, string> AddCountryToEmptyDictionary(int countryCode, string countryName)
        {
            var emptyDictionary = GetEmptyDictionary();
            emptyDictionary[countryCode] = countryName;
            return emptyDictionary;
        }

        public static Dictionary<int, string> AddCountryToExistingDictionary(
            Dictionary<int, string> existingDictionary, int countryCode, string countryName)
        {
            existingDictionary[countryCode] = countryName;
            return existingDictionary;
        }

        public static string GetCountryNameFromDictionary(
            Dictionary<int, string> existingDictionary, int countryCode)
        {
            if (existingDictionary.ContainsKey(countryCode) == false)
            {
                return string.Empty;
            }
            else
            {
                return existingDictionary[countryCode];
            }

        }

        public static bool CheckCodeExists(Dictionary<int, string> existingDictionary, int countryCode)
        {
            return existingDictionary.ContainsKey(countryCode);

        }

        public static Dictionary<int, string> UpdateDictionary(
            Dictionary<int, string> existingDictionary, int countryCode, string countryName)
        {
            if (existingDictionary.ContainsKey(countryCode))
            {
                existingDictionary[countryCode] = countryName;
                return existingDictionary;
            }

            else
            {
                return existingDictionary;
            }
        }

        public static Dictionary<int, string> RemoveCountryFromDictionary(
            Dictionary<int, string> existingDictionary, int countryCode)
        {
            existingDictionary.Remove(countryCode);
            return existingDictionary;
        }

        public static string FindLongestCountryName(Dictionary<int, string> existingDictionary)
        {
            //var keys = existingDictionary.Keys;
            //var currentLongestCountryName = string.Empty;
            //for (int index = keys.First(); index < keys.Count - 1; index++)
            //{
            //    if (existingDictionary[index].Length > existingDictionary[index + 1].Length)
            //    {
            //        currentLongestCountryName = existingDictionary[index];
            //    }
            //}
            //return currentLongestCountryName;
            var keys = existingDictionary;
            
            var biggestLenght = string.Empty;
            for (int i = 0; i < existingDictionary.Count; i++)
            {
                if (existingDictionary.ContainsKey(i))
                {
                    if (existingDictionary[i].Length > biggestLenght.Length)
                    {
                        biggestLenght = existingDictionary[i];
                    }
                }
                
            }
            return biggestLenght;

        }

        public static void Main()
        {
            FindLongestCountryName(GetExistingDictionary());
        }
    }
}
