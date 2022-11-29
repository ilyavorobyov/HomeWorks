using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp16
{
    internal class Program
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

            for (int i = 0; i < nameLenght; i++)
            {
                Console.Write(symbol);
                if(nameLenght - i == 1)
                {
                    Console.WriteLine($"\n{symbol} {name} {symbol}");
                    for (int j = 0; j < nameLenght; j++)
                    {
                        Console.Write(symbol);
                    }
                    Console.ReadKey();
                }
            }
        }
    }
}