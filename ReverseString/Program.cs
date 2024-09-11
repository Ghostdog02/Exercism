using System;
using System.Text;

namespace ReverseString
{
    public static class ReverseString
    {
        public static string Reverse(string input)
        {
            StringBuilder stringBuilder = new StringBuilder();
            for (int index = input.Length - 1; index >= 0; index--)
            {
                stringBuilder.Append(input[index]);
            }
            return stringBuilder.ToString();
        }
    }
}
