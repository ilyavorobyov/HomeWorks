using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp13
{
    internal class Program10
    {
        static void Main(string[] args)
        {
            int number = 5;
            int step = 7;
            int maxValue = 96;

            for (int i = 0; i < maxValue; i += step)
            {
                Console.WriteLine(number);
                number += step;
            }
        }
    }
}
