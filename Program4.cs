using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp12
{
    internal class Program4
    {
        static void Main(string[] args)
        {
            int pictures = 52;
            int rowCapacity = 3;

            Console.WriteLine("Полностью заполненных рядов картинок: "  + (pictures / rowCapacity) + ", а картинок без ряда осталось: " + (pictures % rowCapacity));
        }
    }
}



