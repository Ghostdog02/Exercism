//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;

//namespace Run_LengthEncoding
//{
//    public class RunLengthEncoding
//    {
//        public static string Encode(string input)
//        {
//            StringBuilder stringEncoded = new StringBuilder();
//            string oldLetter = string.Empty;
//            int count = 0;
//            for (int i = 0; i < input.Length; i++)
//            {
//                if (input[i].ToString() != oldLetter)
//                {
//                    if (i != 0)
//                        AppendLetters(oldLetter, count, stringEncoded);

//                    count = 1;
//                    oldLetter = input[i].ToString();
//                    if (i == input.Length - 1)
//                        stringEncoded.Append(oldLetter);

//                }

//                else
//                {
//                    count++;
//                    oldLetter = input[i].ToString();
//                    if (i == input.Length - 1)
//                        AppendLetters(oldLetter, count, stringEncoded);

//                }
//            }

//            return stringEncoded.ToString();
//        }

//        public static string Decode(string input)
//        {
//            StringBuilder stringBuilder = new StringBuilder();
//            if (input.All(char.IsLetter))
//            {
//                return input;
//            }

//            for (int i = 0; i < input.Length - 1; i++)
//            {

//                if (char.IsDigit(input[i]) && char.IsLetter(input[i + 1]))
//                {
//                    for (int j = 0; j < Int32.Parse(input[i].ToString()); j++)
//                    {
//                        stringBuilder.Append(input[i + 1]);
//                    }
//                    i++;
//                }

//                if (char.IsDigit(input[i]) && char.IsDigit(input[i + 1]) && char.IsLetter(input[i + 2]))
//                {
//                    int wholeNumber = Int32.Parse($"{input[i].ToString()}{input[i + 1].ToString()}");
//                    for (int j = 0; j < wholeNumber; j++)
//                    {
//                        stringBuilder.Append(input[i + 2]);
//                    }
//                    i += 2;
//                }

//                if (char.IsWhiteSpace(input[i]) || char.IsLetter(input[i]) && !char.IsDigit(input[i - 1]))
//                {
//                    stringBuilder.Append(input[i]);
//                }

//                if (char.IsDigit(input[i]) && char.IsWhiteSpace(input[i + 1]))
//                {
//                    stringBuilder.Append(input[i + 1]);
//                }


//            }

//            if (!char.IsDigit(input[input.Length - 2]) || char.IsWhiteSpace(input[input.Length - 1]))
//            {
//                stringBuilder.Append(input[input.Length - 1]);
//            }

//            return stringBuilder.ToString();
//        }

//        public static void AppendLetters(string oldLetter, int count, StringBuilder stringEncoded)
//        {
//            if (count > 1)
//            {
//                stringEncoded.Append(count);
//                stringEncoded.Append(oldLetter);
//            }

//            else
//            {
//                stringEncoded.Append(oldLetter);
//            }
//        }

//        static void Main()
//        {
//            Decode("12WB12W3B24WB");
//            Console.WriteLine(Decode("2 hs2q q2w2 "));
//        }
//    }
//}

using System.Text;

public static class RunLengthEncoding
{
    public static string Encode(string input)
    {
        StringBuilder encodedString = new StringBuilder();
        int count = 1;

        for (int i = 1; i <= input.Length; i++)
        {
            if (i == input.Length || input[i] != input[i - 1])
            {
                if (count > 1)
                {
                    encodedString.Append(count);
                }
                encodedString.Append(input[i - 1]);
                count = 1;
            }
            else
            {
                count++;
            }
        }

        return encodedString.ToString();
    }

    public static string Decode(string input)
    {
        StringBuilder decodedString = new StringBuilder();
        int count = 0;

        foreach (char c in input)
        {
            if (char.IsDigit(c))
            {
                count = count * 10 + (c - '0');
            }
            else
            {
                if (count == 0)
                {
                    count = 1;
                }
                decodedString.Append(c, count);
                count = 0;
            }
        }

        return decodedString.ToString();
    }
}
