using System;
using System.Collections.Generic;
using System.Linq;

namespace search_for_a_criminal
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SearchBar searchBar = new SearchBar();
            searchBar.FindCriminal();
        }
    }

    class SearchBar
    {
        private List<Criminal> _criminals = new List<Criminal>()
        {
            new Criminal("Михайлов Дмитрий Ярославович", false, 170, 70, "Русский"), new Criminal("Зайцев Фёдор Константинович", false, 151, 65, "Русский"), new Criminal("Зайцев Александр Александрович", true, 175, 90, "Грузин"), new Criminal("Капустин Леонид Степанович", false, 171, 61, "Грузин"), new Criminal("Фадеев Юрий Александрович", false, 171, 61, "Китаец"),
            new Criminal("Семин Арсений Тимурович", false, 166, 66, "Русский"), new Criminal("Беляев Михаил Константинович", false, 166, 66, "Грузин"), new Criminal("Лопатин Филипп Георгиевич", false, 150, 51, "Китаец"), new Criminal("Гуляев Артём Тимофеевич", false, 177, 76, "Американец"), new Criminal("Васильев Илья Лукич", true, 173, 72, "Американец"),
            new Criminal("Бондарев Герман Петрович", false, 151, 70, "Узбек"), new Criminal("Журавлев Георгий Александрович", true, 168, 73, "Узбек"), new Criminal("Иванов Владимир Тимурович", false, 163, 61, "Японец"), new Criminal("Поляков Михаил Артёмович", true, 164, 62, "Японец"), new Criminal("Балашов Даниил Юрьевич", false, 190, 90, "Марокканец"),
        };

        public void FindCriminal()
        {
            const string FindCriminalCommand = "1";
            const string ExitCommand = "2";

            string errorInput = "Введена неверная команда, попробуй ещё раз";
            string exitText = "Выполнение программы завершено";
            bool isWork = true;

            while (isWork)
            {
                Console.Clear();
                Console.WriteLine("Добро пожаловать в программу поиска преступников по параметрам");
                Console.WriteLine($"Вводи команды:\n{FindCriminalCommand} - найти преступника \n{ExitCommand} - выход из программы");
                string input = Console.ReadLine();

                switch (input)
                {
                    case FindCriminalCommand:
                        FindByDescription();
                        break;

                    case ExitCommand:
                        Console.WriteLine(exitText);
                        isWork = false;
                        break;

                    default:
                        Console.WriteLine(errorInput);
                        break;
                }

                Console.ReadKey();
            }
        }

        private void FindByDescription()
        {
            int height;
            int weight;
            string nationality;

            Console.Write("Введите рост преступника: ");

            if (int.TryParse(Console.ReadLine(), out height))
            {
                Console.Write("Введите вес преступника: ");

                if (int.TryParse(Console.ReadLine(), out weight))
                {
                    Console.Write("Введите национальность преступника: ");
                    nationality = Console.ReadLine();

                    var selectedСriminals = _criminals.Where(criminal => criminal.Height == height && criminal.Weight == weight && criminal.Nationality.ToLower() == nationality.ToLower() && criminal.IsArrested == false).ToList();

                    if (selectedСriminals.Count == 0)
                    {
                        Console.WriteLine("Преступники не найдены");
                    }
                    else
                    {
                        ShowList(selectedСriminals);
                    }
                }
                else
                {
                    Console.WriteLine("Данные введены неверно, нужно вводить числа");
                }
            }
            else
            {
                Console.WriteLine("Данные введены неверно, нужно вводить числа");
            }
        }

        private void ShowList(List<Criminal> list)
        {
            foreach (var criminal in list)
            {
                criminal.ShowInfo();
            }
        }
    }

    class Criminal
    {
        public Criminal(string fullName, bool isArrested, int height, int weight, string nationality)
        {
            FullName = fullName;
            IsArrested = isArrested;
            Height = height;
            Weight = weight;
            Nationality = nationality;
        }

        public string FullName { get; private set; }
        public bool IsArrested { get; private set; }
        public int Height { get; private set; }
        public int Weight { get; private set; }
        public string Nationality { get; private set; }

        public void ShowInfo()
        {
            Console.WriteLine($"Имя: {FullName}, рост: {Height}, вес: {Weight}, национальность: {Nationality}");
        }
    }
}