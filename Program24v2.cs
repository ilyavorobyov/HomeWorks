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
            Dictionary<string, string> countries = new Dictionary<string, string>();

            AddWords(countries);
            FindDefinitionByWord(countries);
        }
        static void AddWords(Dictionary<string, string> countries)
        {
            countries.Add("Россия", "Москва");
            countries.Add("Украина", "Киев");
            countries.Add("Беларусь", "Минск");
            countries.Add("США", "Вашингтон");
            countries.Add("Канада", "Оттава");
            countries.Add("Франция", "Париж");
            countries.Add("Китай", "Пекин");
        }

        static void FindDefinitionByWord(Dictionary<string, string> countries)
        {
            bool isActive = true;
            string exitWord = "Выход";
            string userInput;

            while (isActive)
            {
                Console.Write("Для выхода из программы введите слово Выход\nВведите название страны, столицу которой вы хотите узнать: ");
                userInput = Console.ReadLine();

                if (countries.ContainsKey(userInput))
                {
                    Console.WriteLine(countries[userInput]);
                }
                else if (userInput == exitWord)
                {
                    isActive = false;
                    Console.WriteLine("Выход из программы совершен.");
                }
                else
                {
                    Console.WriteLine("Такая страна словарю не известна");
                }
            }
        }
    }
}