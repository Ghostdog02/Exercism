//using System;
//using System.Collections.Generic;
//using System.Linq;

//namespace Pangram
//{
//    public static class Pangram
//    {
//        public static bool IsPangram(string input)
//        {
//            input = input.ToLower();
//            var alphabet = new Dictionary<char, bool>()
//            {
//                {'a', false },
//                {'b', false },
//                {'c', false },
//                {'d', false },
//                {'e', false },
//                {'f', false },
//                {'g', false },
//                {'h', false },
//                {'i', false },
//                {'j', false },
//                {'k', false },
//                {'l', false },
//                {'m', false },
//                {'n', false },
//                {'o', false },
//                {'p', false },
//                {'q', false },
//                {'r', false },
//                {'s', false },
//                {'t', false },
//                {'u', false },
//                {'v', false },
//                {'w', false },
//                {'x', false },
//                {'y', false },
//                {'z', false }
//            };

//            if (input != null)
//            {
//                //for (char i = 'a'; i < 'z'; i++)
//                //{
//                //    int index = 0;
//                //    if (char.IsLetter(input[index]) && alphabet.ContainsKey(input[index]))
//                //    {

//                //    }

//                //}

//                foreach (var element in input)
//                {
//                    if (char.IsLetter(element))
//                    {
//                        alphabet[element] = true;
//                    }
//                }
//            }

//            else
//            {
//                throw new ArgumentNullException();
//            }
//            var isAnagram = alphabet.All(a => a.Value);
//            return isAnagram;
//        }

//        static void Main()
//        {
//            IsPangram("Remove this Skip property to run this test");
//        }
//    }
//}

using System;
using System.Collections.Generic;
using System.Linq;

namespace Pangram
{
    public static class Pangram
    {
        // Generate the alphabet from a-z
        private static HashSet<char> alphabet = new HashSet<char>(Enumerable.Range('a', 26).Select(c => (char)c));

        public static bool IsPangram(string input)
        {
            if (input == null)
                throw new ArgumentNullException();

            input = input.ToLower();

            foreach (var element in input)
            {
                if (char.IsLetter(element))
                {
                    alphabet.Remove(element);
                    if (alphabet.Count == 0)
                        return true;
                }
            }

            return false;
        }

        public static bool IsPangramOneLiner(string input)
        {
            const string Letters = "abcdefghijklmnopqrstuvwxyz";
            var lowerCaseInput = input.ToLower();
            return Letters.All(letter => lowerCaseInput.Contains(letter));
        }

        static void Main()
        {
            var startTime = DateTime.Now.Ticks;

            for (int i = 0; i < 1000000; i++)
            {
                IsPangram("Remove this Skip property to run this test");
            }

            var endTime = DateTime.Now.Ticks;

            var firstTimeDiff = endTime - startTime;
            Console.WriteLine($"First attempt: {firstTimeDiff}");

            startTime = DateTime.Now.Ticks;

            for (int i = 0; i < 1000000; i++)
            {
                IsPangramOneLiner("Remove this Skip property to run this test");
            }

            endTime = DateTime.Now.Ticks;

            var secondTimeDiff = endTime - startTime;

            Console.WriteLine($"Second attempt with one line: {secondTimeDiff}");

            //Console.WriteLine($"");
        }
    }
}

