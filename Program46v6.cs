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
        EnclosureManager enclosureBuilder = new EnclosureManager();

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

    class EnclosureManager
    {
        private static Random _random = new Random();
        private List<AnimalEnclosure> _animalEnclosures = new List<AnimalEnclosure>();
        private List<Animal> _animalSamples = new List<Animal>() { new Animal("Лиса", "Фыркает"),
            new Animal("Волк", "Воет"), new Animal("Cова", "Укает"), new Animal("Белка", "Цвиркает") };
        private int _enclosureNumber = 1;
        private int _minNumberOfAnimals = 3;
        private int _maxNumberOfAnimals = 7;

        public EnclosureManager()
        {
            for (int i = 0; i < _animalSamples.Count; i++)
            {
                _animalEnclosures.Add(new AnimalEnclosure(_enclosureNumber, $"Животные: {_animalSamples[i].Name}",
                    _random.Next(_minNumberOfAnimals, _maxNumberOfAnimals), _animalSamples[i]));
                _enclosureNumber++;
            }

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
            foreach (AnimalEnclosure animalEnclosure in _animalEnclosures)
            {
                animalEnclosure.AddAnimals();
            }
        }
    }

    class AnimalEnclosure
    {
        private int _number;
        private int _numberOfAnimals;
        private string _description;
        private List<Animal> _animals = new List<Animal>();

        public AnimalEnclosure(int enclosureNumber, string description, int numberOfAnimals, Animal animal)
        {
            _number = enclosureNumber;
            _description = description;
            _numberOfAnimals = numberOfAnimals;
            AnimalType = animal;
        }

        public Animal AnimalType { get; private set; }

        public void ShowFullInfo()
        {
            Console.WriteLine($"{_description}, животных в вольере {_numberOfAnimals}, список животных: ");

            foreach (Animal animal in _animals)
            {
                animal.ShowInfo();
            }
        }

        public void ShowShortDescription()
        {
            Console.WriteLine($"Вольер номер {_number}, {_description}");
        }

        public void AddAnimals()
        {
            for (int i = 0; i < _numberOfAnimals; i++)
            {
                _animals.Add(new Animal(AnimalType.Name, AnimalType.Sound));
            }
        }
    }

    class Animal
    {
        private static Random _random = new Random();
        private string _gender;

        public Animal(string animalName, string animalSound)
        {
            Name = animalName;
            Sound = animalSound;
            IdentifyGender();
        }

        public string Name { get; private set; }
        public string Sound { get; private set; }

        public void ShowInfo()
        {
            Console.WriteLine($"{Name} , пол особи: {_gender}, издает звук: {Sound}");
        }

        private void IdentifyGender()
        {
            List<string> genderOptions = new List<string>() { "Мужской", "Женский" };
            _gender = genderOptions[_random.Next(0, genderOptions.Count)];
        }
    }
}