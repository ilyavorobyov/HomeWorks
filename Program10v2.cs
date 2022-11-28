using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp13
{
    internal class Program10
    {
        static void Main(string[] args)
        {
            int minNumber = 0;
            int maxNumber = 101;
            Random random = new Random(); 
            int number = random.Next(minNumber, maxNumber);
            int sum = 0;
            int firstDivider = 3;
            int secondDivider = 5;

            for(int i =0; i < number; i++)
            {

                if(i % firstDivider == 0 || i % secondDivider == 0)
                {
                    sum += i;
                }
            }
            Console.WriteLine("Сумма всех положительный чисел меньше числа " + number + " которые кратны " + firstDivider + " и " + secondDivider + " равна: " + sum);
        }
    }
}
