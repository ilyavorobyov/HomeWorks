using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp15
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int MinNumber = 0;
            const int MaxNumber = 100;

            Random random = new Random();
            int degree = 2;
            int exponentiableNumber = 2;
            int number = random.Next(MinNumber, MaxNumber);
            int finalNumber;

            while (Math.Pow(exponentiableNumber, degree) <= number)
            {
                degree++;
            }
            finalNumber = Convert.ToInt32(Math.Pow(exponentiableNumber, degree));
            Console.WriteLine("Случайное число - " + number);
            Console.WriteLine("Нужная степень двойки - " + degree);
            Console.WriteLine("число два в найденной степени - " + finalNumber);
        }
    }
}
