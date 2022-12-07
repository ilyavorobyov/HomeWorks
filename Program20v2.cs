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
            int size = 10;
            int minValue = 1;
            int maxValue = 500;
            int[,] array = new int[size, size];
            int number;
            int maxNumber = int.MinValue;
            int newValue = 0;
            Random random = new Random();

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    number = random.Next(minValue, maxValue);
                    array[i, j] = number;
                    Console.Write(array[i, j] + " ");

                    if (array[i, j] > maxNumber)
                    {
                        maxNumber = array[i, j];
                    }
                }
                
                Console.WriteLine();
            }

            Console.WriteLine("Наибльший элемент матрицы это число - " + maxNumber);

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (array[i, j] == maxNumber)
                    {
                        array[i, j] = newValue;
                    }

                    Console.Write(array[i, j] + " ");
                }
                
                Console.WriteLine();
            }
        }
    }
}
