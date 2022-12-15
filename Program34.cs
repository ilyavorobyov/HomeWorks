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
            int inputUser;
            int[] array = { 1, 2, 3, 4, 5 };
            int tempNumber;
            int shiftValue;
            int arrayChange = 1;

            Console.Write("Массив чисел: ");

            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }

            Console.WriteLine("Насколько сдвинуть массив влево? Введите число: ");
            inputUser = Convert.ToInt32(Console.ReadLine());
            shiftValue = inputUser % array.Length;

            for (int i = 0; i < shiftValue; i++)
            {
                Console.Clear();
                Console.Write("Измененный массив: ");
                tempNumber = array[0];

                for (int j = 0; j < array.Length - arrayChange; j++)
                {
                    array[j] = array[j + arrayChange];

                    Console.Write(array[j] + " ");
                }

                array[array.Length - arrayChange] = tempNumber;
                Console.Write(array[array.Length - arrayChange]);
            }
        }
    }
}