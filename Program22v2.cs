using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp18
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = ReadNumber();
            Console.WriteLine("Итоговое число: " + number);
        }
        static int ReadNumber()
        {
            int inputInt = 0;
            bool isTryParse = true;

            while (isTryParse)
            {
                Console.Write("Введите число: ");
                string userInput = Console.ReadLine();
                bool isNumber = int.TryParse(userInput, out inputInt);

                if (isNumber == true)
                {
                    Console.WriteLine($"Преобразование прошло успешно. Число: {inputInt}");
                    isTryParse = false;
                }
                else
                {
                    Console.WriteLine("Преобразование завершилось неудачно");
                }
            }
            return inputInt;
        }
    }
}