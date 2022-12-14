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
            const string AddDossierCommand = "1";
            const string ShowAllDossierCommand = "2";
            const string DeleteDossierCommand = "3";
            const string SearchBySurnameCommand = "4";
            const string ExitCommand = "5";

            string[] fullNameArray = { };
            string[] workPositionArray = { };
            string spaceForShow = "-";
            string exitText = "Выполнение программы завершено";
            string errorText = "Неверная команда, попробуй снова";
            string messageTextInputName = "Введите ФИО: ";
            string messageTextInputPosition = "Введите должность: ";
            string messageTextDeleteDossier = "Введите номер досье, которое вы хотите удалить: ";
            bool isActive = true;
            int extensionArray = 1;
            int numberOfDeletedDossier = 0;
            string userInput;

            while (isActive)
            {
                Console.Clear();
                Console.WriteLine($"Вводи следующие комманды:\n{AddDossierCommand} - добавить новое досье\n{ShowAllDossierCommand} - показать все досье\n" +
                    $"{DeleteDossierCommand} - удалить досье по номеру\n{SearchBySurnameCommand} - найти сотрудника(ов) по фамилии\n{ExitCommand} - выход из программы");
                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case AddDossierCommand:
                        AddDossier(ref fullNameArray, extensionArray, messageTextInputName);
                        AddDossier(ref workPositionArray, extensionArray, messageTextInputPosition);
                        break;

                    case ShowAllDossierCommand:
                        ShowAllDossier(fullNameArray, workPositionArray, spaceForShow);
                        break;

                    case DeleteDossierCommand:
                        Console.Write(messageTextDeleteDossier);
                        numberOfDeletedDossier = Convert.ToInt32(Console.ReadLine());
                        DeleteDossier(ref fullNameArray, numberOfDeletedDossier, extensionArray);
                        DeleteDossier(ref workPositionArray, numberOfDeletedDossier, extensionArray);
                        break;

                    case SearchBySurnameCommand:
                        FindDossierBySurname(fullNameArray, extensionArray);
                        break;

                    case ExitCommand:
                        Console.WriteLine(exitText);
                        isActive = false;
                        Console.ReadKey();
                        break;

                    default:
                        Console.WriteLine(errorText);
                        break;
                }
            }
        }

        static void AddDossier(ref string[] array, int extensionArray, string messageText)
        {
            Console.Clear();
            Console.Write(messageText);
            string inputData = Console.ReadLine();
            string[] tempArray = new string[array.Length + extensionArray];

            for (int i = 0; i < array.Length; i++)
            {
                tempArray[i] = array[i];
            }

            tempArray[tempArray.Length - extensionArray] = inputData;
            array = tempArray;
        }

        static void ShowAllDossier(string[] fullNameArray, string[] workPositionArray, string spaceForShow)
        {
            Console.Clear();
            Console.WriteLine("Список всех досье:");

            for (int i = 0; i < fullNameArray.Length; i++)
            {
                Console.WriteLine(fullNameArray[i] + spaceForShow + workPositionArray[i]);
            }

            Console.WriteLine("Нажми любую кнопку для возврата в меню");
            Console.ReadKey();
        }

        static void DeleteDossier(ref string[] array, int numberOfDeletedDossier, int extensionArray)
        {
            if (numberOfDeletedDossier > array.Length || numberOfDeletedDossier < 0)
            {
                Console.WriteLine("Введено число, которое больше чем массив данных");
                Console.ReadKey();
            }
            else
            {
                string[] tempArray = new string[array.Length - extensionArray];

                for (int i = 0; i < array.Length; i++)
                {
                    if (i < (numberOfDeletedDossier - extensionArray))
                    {
                        tempArray[i] = array[i];
                    }
                    else if (i > (numberOfDeletedDossier - extensionArray))
                    {
                        tempArray[i - 1] = array[i];
                    }
                }

                array = tempArray;
                Console.WriteLine("Удаление последней записи успешно завершено! Нажми любую кнопку.");
                Console.ReadKey();
            }
        }

        static void FindDossierBySurname(string[] fullNameArray, int extensionArray)
        {
            bool isHaveWorker = false;
            Console.Write("Введи фамилию для получения ФИО сотрудников с такой фамилией: ");
            string inputSurname = Console.ReadLine();
            string[] namesakeArray = { };

            for (int i = 0; i < fullNameArray.Length; i++)
            {
                if (inputSurname == fullNameArray[i].Split(' ').FirstOrDefault())
                {
                    isHaveWorker = true;
                    string[] tempNamesakeArray = new string[namesakeArray.Length + extensionArray];

                    for (int j = 0; j < namesakeArray.Length; j++)
                    {
                        tempNamesakeArray[j] = namesakeArray[j];
                    }

                    tempNamesakeArray[tempNamesakeArray.Length - extensionArray] = fullNameArray[i];
                    namesakeArray = tempNamesakeArray;
                }
                else
                {
                    isHaveWorker = false;
                }
            }

            if (isHaveWorker)
            {
                for (int i = 0; i < namesakeArray.Length; i++)
                {
                    Console.WriteLine(namesakeArray[i]);
                }

                Console.WriteLine("Нажми любую кнопку для возврата в меню");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("такой фамилии нет!");
                Console.ReadKey();
            }
        }
    }
}