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
            Random rand = new Random(); 
            int number = rand.Next(0,101);
            int sum = 0;
            int multipleNumber1 = 3;
            int multipleNumber2 = 5;

            for(int i =0; i < number; i++)
            {
                if(i % multipleNumber1 == 0 || i % multipleNumber2 == 0)
                {
                    sum += i;
                }
            }
            Console.WriteLine("Сумма всех положительный чисел меньше числа " + number + " которые кратны " + multipleNumber1 + " и " + multipleNumber2 + " равна: " + sum);


           
        }
    }
}
