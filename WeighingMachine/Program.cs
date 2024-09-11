using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeighingMachineApp
{
    class Program
    {
        static void Main()
        {
            var wm = new WeighingMachine(precision: 3);
            wm.Weight = 60.567;
            Console.WriteLine(wm.Weight);
        }
    }
}
