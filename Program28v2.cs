using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

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
            string errorMessage = "Ввели неизвестную команду!";
            string exitMessage = "Выход из программы совершен.";
            string userInput;

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
                    CloseProgram(ref isActive, exitMessage);
                }
                else if (userInput == sumCommand)
                {
                    CalculateSum(inputNumbers);
                }
                else
                {
                    Console.WriteLine(errorMessage);
                }
            }
        }

        static void CloseProgram(ref bool isActive, string exitMessage)
        {
            isActive = false;
            Console.WriteLine(exitMessage);
        }

        static void CalculateSum(List<int> inputNumbers)
        {
            int sumNumbersInList = inputNumbers.Sum();
            Console.WriteLine("сумма чисел массива = " + sumNumbersInList);
        }
    }
}