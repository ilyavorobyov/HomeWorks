using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

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
            bool isActive = true;
            int extensionArray = 1;
            string userInput;

            while (isActive)
            {
                Console.Clear();
                Console.WriteLine($"Вводи следующие комманды:\n{AddDossierCommand} - добавить новое досье\n{ShowAllDossierCommand} - показать все досье\n" +
                    $"{DeleteDossierCommand} - удалить досье по номеру\n{SearchBySurnameCommand} - найти досье по фамилии\n{ExitCommand} - выход из программы");
                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case AddDossierCommand:
                        AddDossier(ref fullNameArray, ref workPositionArray, extensionArray);
                        break;

                    case ShowAllDossierCommand:
                        ShowAllDossier(fullNameArray, workPositionArray, spaceForShow);
                        break;

                    case DeleteDossierCommand:
                        DeleteDossier(ref fullNameArray, ref workPositionArray, extensionArray);
                        break;

                    case SearchBySurnameCommand:
                        FindDossierBySurname(fullNameArray, workPositionArray);
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

        static void AddDossier(ref string[] fullNameArray, ref string[] workPositionArray, int extensionArray)
        {
            Console.Clear();
            Console.Write("Введите ФИО: ");
            string inputFullName = Console.ReadLine();
            string[] tempFullnameArray = new string[fullNameArray.Length + extensionArray];

            for (int i = 0; i < fullNameArray.Length; i++)
            {
                tempFullnameArray[i] = fullNameArray[i];
            }

            tempFullnameArray[tempFullnameArray.Length - extensionArray] = inputFullName;
            fullNameArray = tempFullnameArray;

            Console.Write("Введите должность: ");
            string inputWorkPosition = Console.ReadLine();
            string[] tempWorkPositionArray = new string[workPositionArray.Length + extensionArray];

            for (int i = 0; i < workPositionArray.Length; i++)
            {
                tempWorkPositionArray[i] = workPositionArray[i];
            }

            tempWorkPositionArray[tempWorkPositionArray.Length - extensionArray] = inputWorkPosition;
            workPositionArray = tempWorkPositionArray;
            Console.WriteLine("Ввод данных успешно завершен!");
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

        static void DeleteDossier(ref string[] fullNameArray, ref string[] workPositionArray, int extensionArray)
        {
            Console.Clear();
            int inputDosierNumber;
            Console.Write("Введите номер досье, которое вы хотите удалить: ");

            if (int.TryParse(Console.ReadLine(), out inputDosierNumber))
            {
                if (inputDosierNumber > fullNameArray.Length || inputDosierNumber < 0)
                {
                    Console.WriteLine("Введено число, которое больше чем массив данных");
                    Console.ReadKey();
                }
                else
                {
                    string[] tempFullnameArray = new string[fullNameArray.Length - extensionArray];
                    string[] tempWorkPositionArray = new string[workPositionArray.Length - extensionArray];

                    for (int i = 0; i < fullNameArray.Length; i++)
                    {
                        if (i < (inputDosierNumber - extensionArray))
                        {
                            tempFullnameArray[i] = fullNameArray[i];
                            tempWorkPositionArray[i] = workPositionArray[i];
                        }
                        else if (i > (inputDosierNumber - extensionArray))
                        {
                            tempFullnameArray[i - 1] = fullNameArray[i];
                            tempWorkPositionArray[i - 1] = workPositionArray[i];
                        }
                    }

                    fullNameArray = tempFullnameArray;
                    workPositionArray = tempWorkPositionArray;
                    Console.WriteLine("Удаление последней записи успешно завершено! Нажми любую кнопку.");
                    Console.ReadKey();
                }
            }
            else
            {
                Console.WriteLine("Введено не число, попробуй ещё раз");
                Console.ReadKey();
            }
        }

        static void FindDossierBySurname(string[] fullNameArray, string[] workPositionArray)
        {
            Console.Write("Введи фамилию для получения названия должности сотрудника: ");
            string inputSurname = Console.ReadLine();
            bool isHaveWorker = false;
            int indexOfWorkPosition = 0;

            for (int i = 0; i < fullNameArray.Length; i++)
            {
                if (inputSurname == fullNameArray[i])
                {
                    isHaveWorker = true;
                    indexOfWorkPosition = i;
                }
            }

            if (isHaveWorker)
            {
                Console.WriteLine("Такой человек есть! Его должность - " + workPositionArray[indexOfWorkPosition]);
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Такого сотрудника нет");
                Console.ReadKey();
            }
        }
    }
}