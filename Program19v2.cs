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
            int numberOfRows = 3;
            int numberOfСolumns = 4;
            int minValue = 1;
            int maxValue = 10;
            Random random = new Random();

            int[,] array = new int[numberOfRows, numberOfСolumns];
            int summLine = 0;
            int columnMultiplication = 1;

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    array[i, j] = random.Next(minValue, maxValue);
                    Console.Write(array[i, j] + " ");
                    if (i == 1)
                    {
                        summLine += array[i, j];
                    }
                    if (j == 0)
                    {
                        columnMultiplication *= array[i, j];
                    }
                }
                Console.WriteLine();
            }

            Console.WriteLine("сумма второй строки - " + summLine);
            Console.WriteLine("произведение первого столбца - " + columnMultiplication);
        }
    }
}