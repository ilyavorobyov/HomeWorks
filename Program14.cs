using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp14
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string Password = "Qwerty1";
            const string SecretMessage = "Ты ввел пароль правильно! Молодец!";

            string enteredPassword;
            int inputCounter = 3;

            while (true)
            {
                Console.Write("Введите пароль: ");
                enteredPassword = Console.ReadLine();

                if (enteredPassword == Password)
                {
                    Console.WriteLine("Секретное послание:");
                    Console.WriteLine(SecretMessage);
                    break;
                }
                else
                {
                    inputCounter--;
                    if (inputCounter <= 0)
                    {
                        Console.WriteLine("Попытки кончились! Попробуй позже");
                        break;
                    }
                    Console.WriteLine("Пароль неправильный, осталось " + inputCounter + " попыток");
                }
            }
        }
    }
}