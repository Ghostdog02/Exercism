using System;

namespace TimMarketing
{
    static class Badge
    {
        public static void Main()
        {

        }

        public static string Print(int? id, string name, string? department)
        {
            if (department != null)
            {
                if (!id.HasValue)
                {
                    return $"{name} - {department.ToUpper()}";
                }

                else
                {
                    return $"[{id}] - {name} - {department.ToUpper()}";
                }
            }

            else
            {
                if (!id.HasValue)
                {
                    return $"{name} - OWNER";
                }

                else
                {
                    return $"[{id}] - {name} - OWNER";
                }
               
            }
            
            
        }
    }
}
