//using System;
//using System.Text;
//using Xunit;

//namespace RotationalCipher
//{
//    public static class RotationalCipher
//    {
//        enum AlphabetLowerCase
//        {
//            a = 1,
//            b,
//            c,
//            d,
//            e,
//            f,
//            g,
//            h,
//            i,
//            j,
//            k,
//            l,
//            m,
//            n,
//            o,
//            p,
//            q,
//            r,
//            s,
//            t,
//            u,
//            v,
//            w,
//            x,
//            y,
//            z
//        }

//        enum AlphabetUpperCase
//        {
//            A = 1,
//            B,
//            C,
//            D,
//            E,
//            F,
//            G,
//            H,
//            I,
//            J,
//            K,
//            L,
//            M,
//            N,
//            O,
//            P,
//            Q,
//            R,
//            S,
//            T,
//            U,
//            V,
//            W,
//            X,
//            Y,
//            Z
//        }

//        public static string Rotate(string text, int shiftKey)
//        {
//            var stringBuilder = new StringBuilder();
//            if (shiftKey == 0 || shiftKey == 26)
//            {
//                return text;
//            }

//            foreach (var letter in text)
//            {

//                if (Enum.IsDefined(typeof(AlphabetLowerCase), letter.ToString()))
//                {
//                    foreach (var letterEnum in Enum.GetNames(typeof(AlphabetLowerCase)))
//                    {
//                        if (letterEnum == letter.ToString())
//                        {
//                            int placeInAlphabet = (int)Enum.Parse(typeof(AlphabetLowerCase), letterEnum);
//                            if ((placeInAlphabet + shiftKey) > 26)
//                            {
//                                stringBuilder.Append((AlphabetLowerCase)((placeInAlphabet + shiftKey) - 26));
//                            }

//                            else
//                            {
//                                stringBuilder.Append((AlphabetLowerCase)(placeInAlphabet + shiftKey));
//                            }
//                        }
//                    }
//                }

//                else if (Enum.IsDefined(typeof(AlphabetUpperCase), letter.ToString()))
//                {
//                    foreach (var letterEnum in Enum.GetNames(typeof(AlphabetUpperCase)))
//                    {
//                        if (letterEnum == letter.ToString())
//                        {
//                            int placeInAlphabet = (int)Enum.Parse(typeof(AlphabetUpperCase), letterEnum);
//                            if ((placeInAlphabet + shiftKey) > 26)
//                            {
//                                stringBuilder.Append((AlphabetUpperCase)((placeInAlphabet + shiftKey) - 26));
//                            }

//                            else
//                            {
//                                stringBuilder.Append((AlphabetUpperCase)(placeInAlphabet + shiftKey));
//                            }
//                        }
//                    }
//                }

//                else
//                {
//                    stringBuilder.Append(letter);
//                }


//            }
//            return stringBuilder.ToString();
//        }

//        //public static void IsDefined(var alphabetLowerCase)
//        //{

//        //}


//    }
//}

using System;
using System.Collections.Generic;
using System.Text;

namespace RotationalCipher
{
    public static class RotationalCipher
    {
        public static string Rotate(string text, int shiftKey)
        {
            if (shiftKey == 0 || shiftKey == 26)
            {
                return text;
            }

            var rotatedChars = new List<char>();
            foreach (var letter in text)
            {
                if (char.IsLetter(letter))
                {
                    int baseAscii = char.IsLower(letter) ? 'a' : 'A';
                    int rotatedAscii = (letter - baseAscii + shiftKey) % 26 + baseAscii;
                    rotatedChars.Add((char)rotatedAscii);
                }
                else
                {
                    rotatedChars.Add(letter);
                }
            }

            return new string(rotatedChars.ToArray());
        }
    }
}
