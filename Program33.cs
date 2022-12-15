using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp24
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int minValue = 1;
            int maxValue = 5;
            int sizeArray = 30;
            int[] array = new int[sizeArray];
            int arrayChange = 1;
            int counter = 1;
            int numberRepetitions = 0;
            int repeatNumber = 0;

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(minValue, maxValue);
                Console.Write(array[i] + " ");
            }

            for (int i = 1; i < array.Length; i++)
            {
                if (array[i - arrayChange] == array[i])
                {
                    counter++;
                }
                else
                {
                    counter = 1;
                }

                if (numberRepetitions <= counter)
                {
                    numberRepetitions = counter;
                    repeatNumber = array[i];
                }
            }

            Console.WriteLine($"\nЧисло {repeatNumber} повторяется {numberRepetitions} раз подряд");
        }
    }
}