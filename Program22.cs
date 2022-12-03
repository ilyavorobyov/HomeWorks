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
            bool isTryParse = true;
            int number;
            TypeNumber(ref isTryParse, out number);
        }

        static void TypeNumber(ref bool isTryParse, out int number)
        {
            number = 0;

            while (isTryParse)
            {
                Console.Write("Введите число: ");
                string userInput = Console.ReadLine();
                bool isNumber = int.TryParse(userInput, out number);

                if (isNumber == true)
                {
                    Console.WriteLine($"Преобразование прошло успешно. Число: {number}");
                    isTryParse = false;
                    break;
                }
                else
                {
                    Console.WriteLine("Преобразование завершилось неудачно");
                }
            }
        }
    }
}