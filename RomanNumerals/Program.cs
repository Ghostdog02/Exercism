//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;

//namespace RomanNumerals
//{
//    public static class RomanNumeralExtension
//    {
//        public static string ToRoman(this int value)
//        {
//            var stringBuilder = new StringBuilder();
//            //int countDigits = 0;
//            //int divideDigits = value;
//            //while (divideDigits > 0)
//            //{
//            //    divideDigits = divideDigits / 10;
//            //    countDigits++;
//            //}

//            var romanNumbers = new Dictionary<int, string>()
//            {
//                [1] = "I",
//                [5] = "V",
//                [10] = "X",
//                [50] = "L",
//                [100] = "C",
//                [500] = "D",
//                [1000] = "M"

//            };

//            var digitsOfValue = new List<double>();

//            //for (int i = 0; i < countDigits--; i++)
//            //{
//            //    var digit = value.ToString().Split("");
//            //    //if (countDigits != 1)
//            //    //{
//            //    //    digitsOfValue.Add((double)digit * Math.Pow(10, countDigits));
//            //    //}

//            //    //else
//            //    //{
//            //    //    digitsOfValue.Add((double)digit);
//            //    //}
//            //}

//            int countDigits = GetDigits(value).Reverse().Count();
//            foreach (var digit in GetDigits(value).Reverse())
//            {
//                if (digit != 0)
//                {
//                    if (countDigits != 1)
//                    {
//                        digitsOfValue.Add((double)digit * Math.Pow(10, countDigits - 1));
//                        countDigits--;
//                    }

//                    else
//                    {
//                        digitsOfValue.Add((double)digit);
//                    }
//                }

//                else
//                {
//                    countDigits--;
//                }


//            }

//            foreach (var number in digitsOfValue)
//            {
//                //first element is the nearest number
//                var orderedRomanNumbers = romanNumbers.OrderBy(e => Math.Abs(e.Key - number)).ToList();
//                //return the nearest number to number from dictionary
//                var bestMatch = orderedRomanNumbers.FirstOrDefault();


//                var difference = number - bestMatch.Key;
//                if (difference < 0)
//                {

//                    //find difference in dictionary
//                    var myValue = romanNumbers.FirstOrDefault(x => x.Key == Math.Abs(difference)).Value;
//                    //if difference is not found dictionary find the nearest to it
//                    if (myValue == null)
//                    {
//                        //find the count of digits
//                        if (Math.Floor(Math.Log10(bestMatch.Key) + 1) != Math.Floor(Math.Log10(difference) + 1) && difference == -2)
//                        {
//                            //var newBestMatch = romanNumbers.OrderBy(e => Math.Abs(e.Key - number));
//                            var index = Math.Max(0, orderedRomanNumbers.IndexOf(bestMatch) + 1);
//                            stringBuilder.Append(orderedRomanNumbers[index].Value);
//                            var newDifference = number - orderedRomanNumbers[index].Key;
//                            var newBestMatch = romanNumbers.OrderBy(e => Math.Abs(e.Key - newDifference));
//                            for (int count = 0; count < newDifference; count++)
//                            {
//                                stringBuilder.Append(newBestMatch.FirstOrDefault().Value);
//                            }
//                        }

//                        else
//                        {
//                            bestMatch = romanNumbers.OrderBy(e => Math.Abs(e.Key - difference)).FirstOrDefault();
//                            difference -= bestMatch.Key;
//                            myValue = romanNumbers.FirstOrDefault(x => x.Key == difference).Value;
//                            stringBuilder.Append(myValue);
//                            stringBuilder.Append(bestMatch.Value);
//                        }

//                    }

//                    else
//                    {
//                        stringBuilder.Append(myValue);
//                        stringBuilder.Append(bestMatch.Value);
//                    }

//                }

//                else if (difference > 0)
//                {
//                    stringBuilder.Append(bestMatch.Value);
//                    //find difference in dictionary
//                    var myValue = romanNumbers.FirstOrDefault(x => x.Key == difference).Value;
//                    //if difference is not found dictionary find the nearest to it
//                    //while (myValue == null)
//                    //{
//                    //    bestMatch = romanNumbers.OrderBy(e => Math.Abs(e.Key - difference)).FirstOrDefault();
//                    //    stringbuilder.Append(bestMatch.Value);
//                    //    difference -= bestMatch.Key;
//                    //    myValue = romanNumbers.FirstOrDefault(x => x.Key == difference).Value;
//                    //    stringbuilder.Append(myValue);

//                    //}
//                    //if difference is not found dictionary find the nearest to it
//                    if (myValue == null)
//                    {
//                        bestMatch = romanNumbers.OrderBy(e => Math.Abs(e.Key - difference)).FirstOrDefault();
//                        stringBuilder.Append(bestMatch.Value);
//                        difference -= bestMatch.Key;
//                        myValue = romanNumbers.FirstOrDefault(x => x.Key == difference).Value;
//                        stringBuilder.Append(myValue);
//                    }

//                    else
//                    {
//                        stringBuilder.Append(myValue);
//                    }

//                }

//                else
//                {
//                    stringBuilder.Append(bestMatch.Value);
//                }


//            }
//            return stringBuilder.ToString();

//        }

//        public static IEnumerable<int> GetDigits(int value)
//        {
//            while (value > 0)
//            {
//                var digit = value % 10;
//                value /= 10;
//                yield return digit;
//            }
//        }

//        static void Main()
//        {
//            402.ToRoman();
//        }
//    }
//}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RomanNumerals
{
    public static class RomanNumeralExtension
    {
        private static readonly Dictionary<int, string> RomanNumbers = new Dictionary<int, string>()
        {
            {1, "I"},
            {4, "IV"},
            {5, "V"},
            {9, "IX"},
            {10, "X"},
            {40, "XL"},
            {50, "L"},
            {90, "XC"},
            {100, "C"},
            {400, "CD"},
            {500, "D"},
            {900, "CM"},
            {1000, "M"}
        };

        public static string ToRoman(this int value)
        {
            if (value < 1 || value > 3999)
            {
                throw new ArgumentOutOfRangeException("value", "Value must be between 1 and 3999.");
            }

            var stringBuilder = new StringBuilder();

            foreach (var number in RomanNumbers.Keys.OrderByDescending(x => x))
            {
                while (value >= number)
                {
                    stringBuilder.Append(RomanNumbers[number]);
                    value -= number;
                }
            }

            return stringBuilder.ToString();
        }

        static void Main()
        {
            Console.WriteLine(402.ToRoman());
        }
    }
}


