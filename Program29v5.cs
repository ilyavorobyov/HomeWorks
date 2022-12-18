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

            string[] fullNames = { };
            string[] workPositions = { };
            string spaceForShow = "-";
            string exitText = "Выполнение программы завершено";
            string errorText = "Неверная команда, попробуй снова";
            string messageTextDeleteDossier = "Введите номер досье, которое вы хотите удалить: ";
            bool isActive = true;
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
                        AddDossier(ref fullNames, ref workPositions);
                        break;

                    case ShowAllDossierCommand:
                        ShowAllDossier(fullNames, workPositions, spaceForShow);
                        break;

                    case DeleteDossierCommand:
                        DeleteDossier(ref fullNames, ref workPositions, messageTextDeleteDossier);
                        break;

                    case SearchBySurnameCommand:
                        FindDossierBySurname(fullNames);
                        break;

                    case ExitCommand:
                        isActive = false;
                        break;

                    default:
                        Console.WriteLine(errorText);
                        break;
                }
            }

            if (isActive == false)
            {
                Console.WriteLine(exitText);
                Console.ReadKey();
            }
        }

        static void AddDossier(ref string[] names, ref string[] positions)
        {
            string messageTextInputName = "Введите ФИО: ";
            string messageTextInputPosition = "Введите должность: ";
            Console.Clear();
            names = IncreaseArray(names, messageTextInputName);
            positions = IncreaseArray(positions, messageTextInputPosition);
        }

        static string[] IncreaseArray(string[] array, string messageTextNames)
        {
            int extensionArray = 1;
            Console.Write(messageTextNames);
            string inputData = Console.ReadLine();
            string[] tempArray = new string[array.Length + extensionArray];

            for (int i = 0; i < array.Length; i++)
            {
                tempArray[i] = array[i];
            }

            tempArray[tempArray.Length - extensionArray] = inputData;
            return tempArray;
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

        static void DeleteDossier(ref string[] fullNameArray, ref string[] workPositionArray, string messageTextDeleteDossier)
        {
            Console.Write(messageTextDeleteDossier);
            int numberOfDeletedDossier = Convert.ToInt32(Console.ReadLine());
            int extensionArray = 1;

            if (numberOfDeletedDossier > fullNameArray.Length || numberOfDeletedDossier < 0)
            {
                Console.WriteLine("Введено число, которое больше чем массив данных");
                Console.ReadKey();
            }
            else
            {
                DeleteData(numberOfDeletedDossier, ref fullNameArray, extensionArray);
                DeleteData(numberOfDeletedDossier, ref workPositionArray, extensionArray);
                Console.WriteLine("Удаление записи успешно завершено! Нажми любую кнопку.");
                Console.ReadKey();
            }
        }

        static void DeleteData(int numberOfDeletedDossier, ref string[] array, int extensionArray)
        {
            string[] tempArray = new string[array.Length - extensionArray];

            for (int i = 0; i < numberOfDeletedDossier - extensionArray; i++)
            {
                tempArray[i] = array[i];
            }

            for (int i = numberOfDeletedDossier - extensionArray; i < tempArray.Length; i++)
            {
                tempArray[i] = array[i + extensionArray];
            }

            array = tempArray;
        }

        static void FindDossierBySurname(string[] fullNameArray)
        {
            Console.Write("Введи фамилию для получения ФИО сотрудников с такой фамилией: ");
            string inputSurname = Console.ReadLine();

            for (int i = 0; i < fullNameArray.Length; i++)
            {
                if (inputSurname == fullNameArray[i].Split(' ').FirstOrDefault())
                {
                    Console.WriteLine(fullNameArray[i]);
                }
                else
                {
                    Console.WriteLine("такой фамилии нет!");
                    break;
                }
            }

            Console.WriteLine("Нажми любую кнопку для возврата в меню");
            Console.ReadKey();
        }
    }
}