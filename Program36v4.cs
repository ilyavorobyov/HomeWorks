using System;
using System.Collections.Generic;

namespace ConsoleApp22
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string AddDossierCommand = "1";
            const string ShowAllDossierCommand = "2";
            const string DeleteDossierCommand = "3";
            const string ExitCommand = "4";

            Dictionary<string, string> employees = new Dictionary<string, string>();
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
                    $"{DeleteDossierCommand} - удалить досье по номеру\n{ExitCommand} - выход из программы");
                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case AddDossierCommand:
                        AddDossier(employees);
                        break;

                    case ShowAllDossierCommand:
                        ShowAllDossiers(employees, spaceForShow);
                        break;

                    case DeleteDossierCommand:
                        DeleteDossier(employees, messageTextDeleteDossier);
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

        static void AddDossier(Dictionary<string, string> employees)
        {
            Console.Clear();
            string messageTextInputName = "Введите ФИО: ";
            string messageTextInputPosition = "Введите должность: ";
            string errorTextInputName = "Досье с таким именем уже есть, попробуйте заново: ";
            Console.Write(messageTextInputName);
            string position;
            bool isCheckInputName = true;

            while (isCheckInputName)
            {
                string name = Console.ReadLine();

                if (employees.ContainsKey(name))
                {
                    Console.Write(errorTextInputName);
                }
                else
                {
                    Console.Write(messageTextInputPosition);
                    position = Console.ReadLine();
                    employees.Add(name, position);
                    isCheckInputName = false;
                }
            }
        }

        static void ShowAllDossiers(Dictionary<string, string> employees, string spaceForShow)
        {
            Console.Clear();
            Console.WriteLine("Список всех досье:");

            foreach (var dossier in employees)
            {
                Console.WriteLine(dossier.Key + spaceForShow + dossier.Value);
            }

            Console.WriteLine("Нажми любую кнопку для возврата в меню");
            Console.ReadKey();
        }

        static void DeleteDossier(Dictionary<string, string> employees, string messageTextDeleteDossier)
        {
            int counter = 0;
            Console.Write(messageTextDeleteDossier);
            int numberOfDeletedDossier;

            if (int.TryParse(Console.ReadLine(), out numberOfDeletedDossier) && numberOfDeletedDossier < employees.Count || numberOfDeletedDossier > 0)
            {
                foreach (var employeesNames in employees.Keys)
                {
                    counter++;

                    if (counter == numberOfDeletedDossier)
                    {
                        employees.Remove(employeesNames);
                        break;
                    }
                }

                Console.WriteLine("Удаление записи успешно завершено! Нажми любую кнопку.");
                Console.ReadKey();
            }
            else
            {
                Console.Write("Введено число, которое больше чем количество записей данных, либо введено НЕ ЧИСЛО");
                Console.ReadKey();
            }
        }
    }
}