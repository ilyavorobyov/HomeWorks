using System;
using System.Collections.Generic;

namespace Zoo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Zoo zoo = new Zoo();
            zoo.StartWalking();
        }
    }

    class Zoo
    {
        private List<AnimalEnclosure> _animalEnclosures = new List<AnimalEnclosure>();
        private int _enclosureNumber = 1;

        public Zoo()
        {
            _animalEnclosures.Add(new AnimalEnclosure(_enclosureNumber, "Вольер с лисами", 5));
            _animalEnclosures.Add(new AnimalEnclosure(++_enclosureNumber, "Вольер с волками", 4));
            _animalEnclosures.Add(new AnimalEnclosure(++_enclosureNumber, "Вольер с совами", 3));
            _animalEnclosures.Add(new AnimalEnclosure(++_enclosureNumber, "Вольер с белками", 6));
        }

        public void StartWalking()
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
            Console.Clear();

            foreach (AnimalEnclosure animalEnclosure in _animalEnclosures)
            {
                animalEnclosure.ShowShortDescription();
            }
        }

        private void ShowEnclosure()
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
    }

    class AnimalEnclosure
    {
        private int _number;
        private string _description;
        private int _numberOfAnimals;
        private List<Animal> _animals = new List<Animal>();

        public AnimalEnclosure(int enclosureNumber, string description, int numberOfAnimals)
        {
            _number = enclosureNumber;
            _description = description;
            _numberOfAnimals = numberOfAnimals;

            FillWithAnimals();
        }

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

        private void FillWithAnimals()
        {
            const string AviaryWithFoxes = "Вольер с лисами";
            const string AviaryWithWolves = "Вольер с волками";
            const string AviaryWithOwls = "Вольер с совами";
            const string AviaryWithSquirrels = "Вольер с белками";

            switch (_description)
            {
                case AviaryWithFoxes:
                    AddFoxes();
                    break;

                case AviaryWithWolves:
                    AddWolves();
                    break;

                case AviaryWithOwls:
                    AddOwls();
                    break;

                case AviaryWithSquirrels:
                    AddSquirrels();
                    break;
            }
        }

        private void AddFoxes()
        {
            for (int i = 0; i < _numberOfAnimals; i++)
            {
                _animals.Add(new Animal("Лиса", "Фыркает"));
            }
        }

        private void AddWolves()
        {
            for (int i = 0; i < _numberOfAnimals; i++)
            {
                _animals.Add(new Animal("Волк", "Воет"));
            }
        }

        private void AddOwls()
        {
            for (int i = 0; i < _numberOfAnimals; i++)
            {
                _animals.Add(new Animal("Cова", "Укает"));
            }
        }

        private void AddSquirrels()
        {
            for (int i = 0; i < _numberOfAnimals; i++)
            {
                _animals.Add(new Animal("Белка", "Цвиркает"));
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