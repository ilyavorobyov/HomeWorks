using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp18
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool isActive = true;
            bool isNumber;
            string exitCommand = "exit";
            string sumCommand = "sum";
            string userInput;
            int extensionArray = 1;
            int sumArray = 0;
            int number;
            int[] array = new int[1];

            while (isActive)
            {
                Console.WriteLine("Введите число, и программа запомнит это число\nВведите sum и вы получите сумму ранее введенных чисел\nВведите exit для выхода");
                userInput = Console.ReadLine();

                if (isNumber = int.TryParse(userInput, out number))
                {
                    int[] tempArray = new int[array.Length + extensionArray];
                    for (int i = 0; i < array.Length; i++)
                    {
                        tempArray[i] = array[i];
                    }
                    tempArray[tempArray.Length - extensionArray] = number;
                    array = tempArray;
                }
                else if (userInput == exitCommand)
                {
                    isActive = false;
                    Console.WriteLine("Выход из программы совершен.");
                    break;
                }
                else if (userInput == sumCommand)
                {
                    int tempSum = 0;

                    foreach (int item in array)
                    {
                        tempSum += item;
                        sumArray = tempSum;
                    }
                    Console.WriteLine("сумма чисел массива = " + sumArray);
                }
                else
                {
                    Console.WriteLine("Ввели не число!");
                }
            }
        }
    }
}