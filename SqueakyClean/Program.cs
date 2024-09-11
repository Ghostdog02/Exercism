using System;
using System.Globalization;
using System.Text;

namespace SqueakyClean
{
    class Identifier
    {
        public static string Clean(string identifier)
        {
            string ctrl = "CTRL";
            StringBuilder stringBuilder = new StringBuilder();

            for (int index = 0; index < identifier.Length; index++)
            {
                if (identifier[index] == ' ')
                {
                    stringBuilder.Append('_');
                }
                else if (char.IsControl(identifier[index]))
                {
                    stringBuilder.Append(ctrl);
                }
                else if (identifier[index] == '-')
                {
                    if (index < identifier.Length - 1)
                    {
                        var nextElement = identifier[index + 1];
                        stringBuilder.Append(char.ToUpper(nextElement));
                        index++;
                    }
                }

                else if (char.IsLetter(identifier[index]) == false)
                {
                    //Do nothing:
                }

                else if (identifier[index] >= 'α' && identifier[index] <= 'ω')
                {
                    //Do nothing:
                }

                else
                {
                    stringBuilder.Append(identifier[index]);

                }

            }
            Console.WriteLine(stringBuilder);
            return stringBuilder.ToString();



        }

        public static void Main()
        {
            Clean("MyΟβιεγτFinder");
        }
    }
}
