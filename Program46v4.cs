using System;
using System.Collections.Generic;

namespace Zoo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Zoo zoo = new Zoo();
            zoo.ShowExcursionPanel();
        }
    }

    class Zoo
    {
        EnclosureBuilder enclosureBuilder = new EnclosureBuilder();

        public void ShowExcursionPanel()
        {
            const string ChooseOfAviary = "1";
            const string ExitCommand = "2";

            string exitText = "Выход из программы успешно выполнен.";
            string errorText = "Ошибка. Введена неправильная команда. Попробуй ещё раз";

            bool isWork = true;

            while (isWork)
            {
                Console.Clear();
                Console.WriteLine("\nДобро пожаловать в зоопарк! В зоопарке есть следующие вольеры:");
                ShowAllEnclosures();
                Console.WriteLine("\nВыберите, что хотите сделать: ");
                Console.WriteLine($"{ChooseOfAviary} - меню выбора вольера\n{ExitCommand} - уйти из зоопарка");

                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case ChooseOfAviary:
                        ShowEnclosure();
                        break;

                    case ExitCommand:
                        isWork = false;
                        Console.WriteLine(exitText);
                        break;

                    default:
                        Console.WriteLine(errorText);
                        Console.ReadKey();
                        break;
                }
            }
        }

        private void ShowAllEnclosures()
        {
            enclosureBuilder.ShowAll();
        }

        private void ShowEnclosure()
        {
            enclosureBuilder.ShowSelected();
        }
    }

    class EnclosureBuilder
    {
        private List<AnimalEnclosure> _animalEnclosures = new List<AnimalEnclosure>();
        private int _enclosureNumber = 1;

        public EnclosureBuilder()
        {
            _animalEnclosures.Add(new AnimalEnclosure(_enclosureNumber, "Вольер с лисами", 5));
            _animalEnclosures.Add(new AnimalEnclosure(++_enclosureNumber, "Вольер с волками", 4));
            _animalEnclosures.Add(new AnimalEnclosure(++_enclosureNumber, "Вольер с совами", 3));
            _animalEnclosures.Add(new AnimalEnclosure(++_enclosureNumber, "Вольер с белками", 6));

            FillWithAnimals();
        }

        public void ShowAll()
        {
            Console.Clear();

            foreach (AnimalEnclosure animalEnclosure in _animalEnclosures)
            {
                animalEnclosure.ShowShortDescription();
            }
        }

        public void ShowSelected()
        {
            Console.Write("\nВведите номер вольера, который вы хотите осмотреть: ");
            bool isNumber = int.TryParse(Console.ReadLine(), out int avairyNumber);

            if (isNumber == false)
            {
                Console.WriteLine("Введены некорректные данные!");
            }
            else if (avairyNumber > 0 && avairyNumber <= _animalEnclosures.Count)
            {
                _animalEnclosures[avairyNumber - 1].ShowFullInfo();
            }
            else
            {
                Console.WriteLine("Такого вольера нет!");
            }

            Console.ReadKey();
        }

        private void FillWithAnimals()
        {
            string aviaryWithFoxes = "Вольер с лисами";
            string aviaryWithWolves = "Вольер с волками";
            string aviaryWithOwls = "Вольер с совами";
            string aviaryWithSquirrels = "Вольер с белками";

            foreach (AnimalEnclosure animalEnclosure in _animalEnclosures)
            {
                if (animalEnclosure.Description == aviaryWithFoxes)
                {
                    animalEnclosure.AddAnimals("Лиса", "Фыркает");
                }
                else if (animalEnclosure.Description == aviaryWithWolves)
                {
                    animalEnclosure.AddAnimals("Волк", "Воет");
                }
                else if (animalEnclosure.Description == aviaryWithOwls)
                {
                    animalEnclosure.AddAnimals("Cова", "Укает");
                }
                else if (animalEnclosure.Description == aviaryWithSquirrels)
                {
                    animalEnclosure.AddAnimals("Белка", "Цвиркает");
                }
            }
        }
    }

    class AnimalEnclosure
    {
        private int _number;
        private int _numberOfAnimals;
        private List<Animal> _animals = new List<Animal>();

        public AnimalEnclosure(int enclosureNumber, string description, int numberOfAnimals)
        {
            _number = enclosureNumber;
            Description = description;
            _numberOfAnimals = numberOfAnimals;
        }

        public string Description { get; private set; }

        public void ShowFullInfo()
        {
            Console.WriteLine($"{Description}, животных в вольере {_numberOfAnimals}, список животных: ");

            foreach (Animal animal in _animals)
            {
                animal.ShowInfo();
            }
        }

        public void ShowShortDescription()
        {
            Console.WriteLine($"Вольер номер {_number}, {Description}");
        }

        public void AddAnimals(string name, string sound)
        {
            for (int i = 0; i < _numberOfAnimals; i++)
            {
                _animals.Add(new Animal(name, sound));
            }
        }
    }

    class Animal
    {
        private static Random _random = new Random();
        private string _name;
        private string _sound;
        private string _gender;
        private string _maleGender = "Мужской";
        private string _femaleGender = "Женский";

        public Animal(string animalName, string animalSound)
        {
            _name = animalName;
            _sound = animalSound;
            IdentifyGender();
        }

        public void ShowInfo()
        {
            Console.WriteLine($"{_name} , пол особи: {_gender}, издает звук: {_sound}");
        }

        private void IdentifyGender()
        {
            int minimumNumberGender = 0;
            int maximumNumberGender = 2;
            int genderNumber = _random.Next(minimumNumberGender, maximumNumberGender);

            if (genderNumber == 0)
            {
                _gender = _maleGender;
            }
            else
            {
                _gender = _femaleGender;
            }
        }
    }
}