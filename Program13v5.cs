using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp17
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string name;
            char symbol;
            int rowLenght;
            string middleRow;
            string outsideRow;

            Console.Write("Введите имя: ");
            name = Console.ReadLine();
            Console.Write("Введите символ: ");
            symbol = Convert.ToChar(Console.ReadLine());
            middleRow = symbol + name + symbol;
            rowLenght = middleRow.Length;
            outsideRow = new string(symbol, rowLenght);

            Console.WriteLine(outsideRow);
            Console.WriteLine(middleRow);
            Console.WriteLine(outsideRow);
            Console.ReadKey();
        }
    }
}