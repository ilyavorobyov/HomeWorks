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
            Dictionary<string, string> words = new Dictionary<string, string>();

            AddWords(words);
            CheckWord(words);
        }

        static void AddWords(Dictionary<string, string> words)
        {
            words.Add("Россия", "Москва");
            words.Add("Украина", "Киев");
            words.Add("Беларусь", "Минск");
            words.Add("США", "Вашингтон");
            words.Add("Канада", "Оттава");
            words.Add("Франция", "Париж");
            words.Add("Китай", "Пекин");
        }

        static void CheckWord(Dictionary<string, string> words)
        {
            bool isActive = true;
            string exitWord = "Выход";
            string userInput;

            while (isActive)
            {
                Console.Write("Введите название страны, столицу которой вы хотите узнать: ");
                userInput = Console.ReadLine();

                if (userInput == exitWord)
                {
                    isActive = false;
                    Console.WriteLine("Выход из программы совершен.");
                    break;
                }

                if (words.ContainsKey(userInput))
                {
                    Console.WriteLine(words[userInput]);
                }
                else
                {
                    Console.WriteLine("Такая страна словарю не известна");
                }
            }
        }
    }
}