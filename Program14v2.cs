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
            string password = "Qwerty1";
            string secretMessage = "Ты ввел пароль правильно! Молодец!";

            string enteredPassword;
            int inputCounter = 3;

            while (inputCounter>0)
            {
                for (int i =0; i<=inputCounter; i++)
                {
                    Console.Write("Введите пароль: ");
                    enteredPassword = Console.ReadLine();
                    if (enteredPassword == password)
                    {
                        Console.WriteLine("Секретное послание:");
                        Console.WriteLine(secretMessage);
                        inputCounter = 0;
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
}