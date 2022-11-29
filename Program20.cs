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
            int size = 10;
            int[,] array = new int[size, size];
            int number;
            int maxNumber = 0;
            Random random = new Random();

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    number = random.Next(1, 500);
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
                        array[i, j] = 0;
                    }
                    Console.Write(array[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}