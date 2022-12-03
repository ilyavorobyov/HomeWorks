using System;
using System.Collections.Generic;
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
            int nameLenght;
            string lastLine;

            Console.Write("Введите имя: ");
            name = Console.ReadLine();
            Console.Write("Введите символ: ");
            symbol = Convert.ToChar(Console.ReadLine());
            nameLenght = name.Length;
            lastLine = new string(symbol, nameLenght);

            for (int i = 0; i < nameLenght; i++)
            {
                if (nameLenght - i == 1)
                {
                    Console.WriteLine(lastLine);
                    Console.WriteLine($"{symbol} {name} {symbol}");
                    Console.WriteLine(lastLine);
                    Console.ReadKey();
                }
            }
        }
    }
}