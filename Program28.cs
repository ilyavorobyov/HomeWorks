using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp22
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool isActive = true;
            bool isNumber;

            string exitCommand = "exit";
            string sumCommand = "sum";
            string errorMessage = "Ввели не число!";
            string exitMessage = "Выход из программы совершен.";
            string userInput;

            int sumNumbersInList = 0;
            int number;

            List<int> inputNumbers = new List<int>();

            while (isActive)
            {
                Console.WriteLine("Введите число, и программа запомнит это число\nВведите sum и вы получите сумму ранее введенных чисел\nВведите exit для выхода");
                userInput = Console.ReadLine();

                if (isNumber = int.TryParse(userInput, out number))
                {
                    inputNumbers.Add(number);
                }
                else if (userInput == exitCommand)
                {
                    isActive = false;
                    Console.WriteLine(exitMessage);
                }
                else if (userInput == sumCommand)
                {
                    int tempSum = 0;

                    foreach (int listElement in inputNumbers)
                    {
                        tempSum += listElement;
                        sumNumbersInList = tempSum;
                    }

                    Console.WriteLine("сумма чисел массива = " + sumNumbersInList);
                }
                else
                {
                    Console.WriteLine(errorMessage);
                }
            }
        }
    }
}

