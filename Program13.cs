using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp13
{
    internal class Program13
    {
        static void Main(string[] args)
        {
            string name;
            char symbol;
            int nameLenght;

            Console.Write("Введите имя: ");
            name = Console.ReadLine();
            Console.Write("Введите символ: ");
            symbol = Convert.ToChar(Console.ReadLine());
            nameLenght = name.Length;

            for(int i = 0; i< nameLenght; i++)
            {
                Console.Write(symbol);
            }
            Console.WriteLine("\n" + symbol + name + symbol);
            for (int i = 0; i < nameLenght; i++)
            {
                Console.Write(symbol);
            }
            Console.ReadKey();
        }
    }
}