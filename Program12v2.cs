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
            const string ChangeWindowNameCommand = "SetName";
            const string RedTextCommand = "RedText";
            const string WhiteTextCommand = "WhiteText";
            const string WriteTwoWordCommand = "WriteTwo";
            const string ShowPasswordCommand = "ShowPass";
            const string GetSecretWordCommand = "GetSec";
            const string CloseProgramCommand = "Esc";

            string password = "Secret";
            string secretWord = "Enot";
            bool isOpen = true;
            string userInput;
            string windowName;
            string firstWord;
            string secondWord;
            string passwordToAcces;

            while (isOpen)
            {
                Console.Clear();
                Console.WriteLine("Доступные команды:\n" + ChangeWindowNameCommand + " изменение имени консоли\n" + RedTextCommand + " сделать текст красным\n"
                    + WhiteTextCommand + " Сделать текст белым\n" + WriteTwoWordCommand + " Ввести два слова и они будут выведены\n" + ShowPasswordCommand + " Увидеть пароль для вывода секретного слова:\n" + GetSecretWordCommand + " получить секретное слово (потребуется пароль)\n" + CloseProgramCommand + " закрыть программу");

                userInput = Console.ReadLine();
                switch (userInput)
                {
                    case ChangeWindowNameCommand:
                        Console.Write("Введите слово, которое должно быть в имени окна: ");
                        windowName = Console.ReadLine();
                        Console.Title = windowName;
                        break;
                    case RedTextCommand:
                        Console.ForegroundColor = ConsoleColor.Red;
                        break;
                    case WhiteTextCommand:
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                    case WriteTwoWordCommand:
                        Console.Write("Введите первое слово: ");
                        firstWord = Console.ReadLine();
                        Console.Write("Введите второе слово: ");
                        secondWord = Console.ReadLine();
                        Console.WriteLine("первое слово: " + firstWord + ", второе слово: " + secondWord);
                        Console.ReadKey();
                        break;
                    case ShowPasswordCommand:
                        Console.Write("Паролем является слово: " + password);
                        Console.ReadKey();
                        break;
                    case GetSecretWordCommand:
                        Console.Write("Введите пароль: ");
                        passwordToAcces = Console.ReadLine();

                        if (passwordToAcces == password)
                        {
                            Console.Write("Секретное слово - " + secretWord);
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.Write("Пароль не правильный!");
                            Console.ReadKey();
                        }
                        break;
                    case CloseProgramCommand:
                        isOpen = false;
                        Console.Clear();
                        break;
                }
            }
        }
    }
}