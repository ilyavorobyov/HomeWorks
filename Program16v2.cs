using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp21
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int minNumber = 0;
            int maxNumber = 100;
            int degree = 2;
            int exponentiableNumber = 2;
            int numberForExponentiation = 2;
            Random random = new Random();
            int number = random.Next(minNumber, maxNumber);

            while ((exponentiableNumber *= numberForExponentiation) <= number)
            {
                degree++;
            }

            Console.WriteLine("Случайное число " + number);
            Console.WriteLine("Нужная степень двойки " + degree);
            Console.WriteLine("Число в найденной степени " + exponentiableNumber);
        }
    }
}
