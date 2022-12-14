using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp23
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int size = 10;
            int minValue = 5;
            int maxValue = 30;
            int arrayChange = 1;
            int[] array = new int[size];

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(minValue, maxValue);
            }

            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length - arrayChange; j++)
                {
                    int tempNumber;

                    if (array[j] > array[j + arrayChange])
                    {
                        tempNumber = array[j];
                        array[j] = array[j + arrayChange];
                        array[j + arrayChange] = tempNumber;
                    }
                }
            }

            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine(array[i]);
            }
        }
    }
}