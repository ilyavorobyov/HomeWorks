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
            int[,] array = { { 5, 1, 2, 2 }, { 3, 4, 5, 5 }, { 2, 6, 3, 3 } };
            int summLine = 0;
            int columnMultiplication = 1;

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (i == 1)
                    {
                        summLine += array[i, j];
                    }
                    if (j == 0)
                    {
                        columnMultiplication *= array[i, j];
                    }
                    Console.Write(array[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine(summLine + " - это сумма второй строки, " + columnMultiplication + " - это произведение первого столбца");
        }
    }
}