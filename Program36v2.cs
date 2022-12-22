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
                        ShowAllDossier(employees, spaceForShow);
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
            string name = Console.ReadLine();

            foreach (var employeesNames in employees.Keys)
            {
                if (employeesNames == name)
                {
                    Console.Write(errorTextInputName);
                    name = Console.ReadLine();
                }
            }

            Console.Write(messageTextInputPosition);
            string position = Console.ReadLine();
            employees.Add(name, position);
        }

        static void ShowAllDossier(Dictionary<string, string> employees, string spaceForShow)
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
            int numberOfDeletedDossier = Convert.ToInt32(Console.ReadLine());

            if (numberOfDeletedDossier > employees.Count || numberOfDeletedDossier < 0)
            {
                Console.WriteLine("Введено число, которое больше чем количество записей данных");
                Console.ReadKey();
            }
            else
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
        }
    }
}