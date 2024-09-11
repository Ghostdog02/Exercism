using System;
using System.Linq;
using System.Collections.Generic;
namespace Bob
{
    public static class Bob
    {
        public static string Response(string statement)
        {
            statement = statement.Trim();
            if (string.IsNullOrWhiteSpace(statement)) // Silence
            {
                return "Fine. Be that way!";
            }

            else if (statement.EndsWith('?'))
            {
                if (statement.All(char.IsUpper))
                {
                    return "Calm down, I know what I'm doing!";
                }

                else
                {
                    return "Sure.";
                }

            }

            else if (statement.Where(char.IsLetter).All(char.IsUpper))
            {
                return "Whoa, chill out!";
            }

           
            else
            {
                return "Whatever.";
            }

        }

        static void Main()
        {
            Bob.Response("1, 2, 3");
        }
    }
}
