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
            int minNumber = 1;
            int maxNumber = 28;
            int minNumberOfThrees = 100;
            int maxNumberOfThrees = 999;

            Random random = new Random();
            int counterOfNumbers = 0;
            int number = random.Next(minNumber, maxNumber);

            for (int i = 0; i < maxNumberOfThrees; i += number)
            {
                if (i >= minNumberOfThrees)
                {
                    counterOfNumbers++;
                }
            }
            Console.WriteLine("Количество чисел, которые больше " + minNumberOfThrees + " и меньше " + maxNumberOfThrees + 
                " и которые кратны числу: " + number + " : " + counterOfNumbers);
        }
    }
}