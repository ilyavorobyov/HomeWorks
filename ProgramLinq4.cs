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
            new Criminal("Михайлов Дмитрий Ярославович", false, 170, 70, "Русский"), new Criminal("Зайцев Фёдор Константинович", false, 165, 65, "Русский"), new Criminal("Зайцев Александр Александрович", true, 175, 90, "Грузин"), new Criminal("Капустин Леонид Степанович", false, 171, 61, "Грузин"), new Criminal("Фадеев Юрий Александрович", false, 171, 61, "Китаец"),
            new Criminal("Семин Арсений Тимурович", false, 166, 66, "Русский"), new Criminal("Беляев Михаил Константинович", false, 166, 66, "Грузин"), new Criminal("Лопатин Филипп Георгиевич", false, 150, 51, "Китаец"), new Criminal("Гуляев Артём Тимофеевич", false, 177, 76, "Американец"), new Criminal("Васильев Илья Лукич", true, 173, 72, "Американец"),
            new Criminal("Бондарев Герман Петрович", false, 151, 70, "Узбек"), new Criminal("Журавлев Георгий Александрович", true, 168, 73, "Узбек"), new Criminal("Иванов Владимир Тимурович", false, 163, 61, "Японец"), new Criminal("Поляков Михаил Артёмович", true, 164, 62, "Японец"), new Criminal("Балашов Даниил Юрьевич", false, 190, 90, "Марокканец"),
        };

        public void FindCriminal()
        {
            const string FindByHeightCommand = "1";
            const string FindByWeightCommand = "2";
            const string FindByNationalityCommand = "3";
            const string ExitCommand = "4";

            string errorInput = "Введена неверная команда, попробуй ещё раз";
            string exitText = "Выполнение программы завершено";
            bool isWork = true;

            while (isWork)
            {
                Console.Clear();
                Console.WriteLine("Добро пожаловать в программу поиска преступников по параметрам");
                Console.WriteLine($"Вводи команды:\n{FindByHeightCommand} - найти преступников по росту\n{FindByWeightCommand} - найти преступников по весу\n{FindByNationalityCommand} - найти преступников по национальности" +
                    $"\n{ExitCommand} - выход из программы");
                string input = Console.ReadLine();

                switch (input)
                {
                    case FindByHeightCommand:
                        FindByHeight();
                        break;

                    case FindByWeightCommand:
                        FindByWeight();
                        break;

                    case FindByNationalityCommand:
                        FindByNationality();
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

        private void FindByHeight()
        {
            Console.Write("Введите рост преступника: ");
            int height;

            if (int.TryParse(Console.ReadLine(), out height))
            {
                var SelectedByHeightList = _criminals.Where(criminal => criminal.Height == height).Where(criminal => criminal.IsArrested == false).ToList();

                if (SelectedByHeightList.Count == 0)
                {
                    Console.WriteLine("Преступники c таким ростом не найдены");
                }
                else
                {
                    ShowList(SelectedByHeightList);
                }
            }
            else
            {
                Console.WriteLine("Данные введены неверно, нужно вводить числа");
            }
        }

        private void FindByWeight()
        {
            Console.Write("Введите вес преступника: ");
            int weight;

            if (int.TryParse(Console.ReadLine(), out weight))
            {
                var SelectedByWeightList = _criminals.Where(criminal => criminal.Weight == weight).Where(criminal => criminal.IsArrested == false).ToList();

                if (SelectedByWeightList.Count == 0)
                {
                    Console.WriteLine("Преступники c таким весом не найдены");
                }
                else
                {
                    ShowList(SelectedByWeightList);
                }
            }
            else
            {
                Console.WriteLine("Данные введены неверно, нужно вводить числа");
            }
        }

        private void FindByNationality()
        {
            Console.Write("Введите национальность преступника: ");
            string nationality = Console.ReadLine();

            var SelectedByNationalityList = _criminals.Where(criminal => criminal.Nationality == nationality).Where(criminal => criminal.IsArrested == false).ToList();

            if (SelectedByNationalityList.Count == 0)
            {
                Console.WriteLine("Преступники c такой национальностью не найдены");
            }
            else
            {
                ShowList(SelectedByNationalityList);
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