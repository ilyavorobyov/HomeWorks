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
            const int MinNumber = 1;
            const int MaxNumber = 28;
            const int MinNumberOfThrees = 100;
            const int MaxNumberOfThrees = 999;

            Random random = new Random();
            int counterOfNumbers = 0;
            int number = random.Next(MinNumber, MaxNumber);

            for (int i = 0; i < MaxNumberOfThrees; i += number)
            {
                if (i >= MinNumberOfThrees)
                {
                    counterOfNumbers++;
                }
            }
            Console.WriteLine("Количество чисел, которые больше " + MinNumberOfThrees + " и меньше " + MaxNumberOfThrees + " и которые кратны числу: " + number + " : " + counterOfNumbers);
        }
    }
}
