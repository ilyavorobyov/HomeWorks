using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp13
{
    internal class Program9
    {
        static void Main(string[] args)
        {
            int countRepeats = 14;
            int number = 5;

            for(int i =0; i< countRepeats; i++)
            {
                Console.WriteLine(number);
                number += 7;
            }
        }
    }
}
