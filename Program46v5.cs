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

        private Animal _foxSample = new Animal("Лиса", "Фыркает");
        private Animal _wolfSample = new Animal("Волк", "Воет");
        private Animal _owlSample = new Animal("Cова", "Укает");
        private Animal _squirrelSample = new Animal("Белка", "Цвиркает");

        public EnclosureBuilder()
        {
            _animalEnclosures.Add(new AnimalEnclosure(_enclosureNumber, "Вольер с лисами", 5, _foxSample));
            _animalEnclosures.Add(new AnimalEnclosure(++_enclosureNumber, "Вольер с волками", 4, _wolfSample));
            _animalEnclosures.Add(new AnimalEnclosure(++_enclosureNumber, "Вольер с совами", 3, _owlSample));
            _animalEnclosures.Add(new AnimalEnclosure(++_enclosureNumber, "Вольер с белками", 6, _squirrelSample));

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
                if (animalEnclosure.AnimalType == _foxSample)
                {
                    animalEnclosure.AddAnimals(_foxSample.Name, _foxSample.Sound);
                }
                else if (animalEnclosure.AnimalType == _wolfSample)
                {
                    animalEnclosure.AddAnimals(_wolfSample.Name, _wolfSample.Sound);
                }
                else if (animalEnclosure.AnimalType == _owlSample)
                {
                    animalEnclosure.AddAnimals(_owlSample.Name, _owlSample.Sound);
                }
                else if (animalEnclosure.AnimalType == _squirrelSample)
                {
                    animalEnclosure.AddAnimals(_squirrelSample.Name, _squirrelSample.Sound);
                }
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
            string maleGender = "Мужской";
            string femaleGender = "Женский";
            int minimumNumberGender = 0;
            int maximumNumberGender = 2;
            int genderNumber = _random.Next(minimumNumberGender, maximumNumberGender);

            if (genderNumber == 0)
            {
                _gender = maleGender;
            }
            else
            {
                _gender = femaleGender;
            }
        }
    }
}