using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp17
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string password = "Qwerty1";
            string secretMessage = "Ты ввел пароль правильно! Молодец!";
            string enteredPassword;
            int inputCounter = 3;
            int visibleInputCounter;

            for (int i = 0; i < inputCounter; --inputCounter)
            {
                Console.Write($"Введите пароль: ");
                enteredPassword = Console.ReadLine();

                if (enteredPassword == password)
                {
                    Console.WriteLine("Секретное послание:");
                    Console.WriteLine(secretMessage);
                    break;
                }
                else
                {
                    visibleInputCounter = inputCounter - 1;
                    if (inputCounter <= 0)
                    {
                        Console.WriteLine("Попытки кончились! Попробуй позже");
                        break;
                    }
                    Console.WriteLine("Пароль неправильный, осталось " + visibleInputCounter + " попыток");
                }
            }
        }
    }
}
