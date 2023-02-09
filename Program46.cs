using System;
using System.Collections.Generic;
using System.Security.Policy;

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
            _animalEnclosures.Add(new AnimalEnclosure(_enclosureNumber, "Вольер с лисами", "Лиса", 4, "Фыркают"));
            _animalEnclosures.Add(new AnimalEnclosure(++_enclosureNumber, "Вольер с волками", "Волк", 3, "Воют"));
            _animalEnclosures.Add(new AnimalEnclosure(++_enclosureNumber, "Вольер с совами", "Сова", 2, "Ухают"));
            _animalEnclosures.Add(new AnimalEnclosure(++_enclosureNumber, "Вольер с белками", "Белка", 5, "Цвиркают"));
        }

        public void StartWalking()
        {
            const string СhoiceOfAviary = "1";
            const string ExitCommand = "2";

            string exitText = "Выход из программы успешно выполнен.";
            string errorText = "Ошибка. Введена неправильная команда. Попробуй ещё раз";

            bool isWork = true;

            while (isWork)
            {
                Console.Clear();
                Console.WriteLine("Добро пожаловать в зоопарк! Выберите, что хотите сделать:");
                Console.WriteLine($"{СhoiceOfAviary} - меню выбора вольера\n{ExitCommand} - уйти из зоопарка");

                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case СhoiceOfAviary:
                        ShowAllEnclosures();
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

            int reduceNumber = 1;
            Console.Write("Введите номер вольера, который вы хотите осмотреть: ");
            bool isNumber = int.TryParse(Console.ReadLine(), out int avairyNumber);

            if (isNumber == false)
            {
                Console.WriteLine("Введены некорректные данные!");
            }
            else if (avairyNumber > 0 && avairyNumber <= _animalEnclosures.Count)
            {
                _animalEnclosures[avairyNumber - reduceNumber].ShowFullInfo();
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
        private Random _random = new Random();
        private string _maleGender = "Мужской";
        private string _femaleGender = "Женский";
        private int _number;
        private string _description;
        private string _animalName;
        private int _numberOfAnimals;
        private string _animalSound;

        private List<Animal> _animals = new List<Animal>();

        public AnimalEnclosure(int enclosureNumber, string description, string animalName, int numberOfAnimals, string animalSound)
        {
            _number = enclosureNumber;
            _description = description;
            _animalName = animalName;
            _numberOfAnimals = numberOfAnimals;
            _animalSound = animalSound;

            FillWithAnimals();
        }

        private void FillWithAnimals()
        {
            string animalGender;
            int minimumNumberGender = 0;
            int maximumNumberGender = 2;

            for (int i = 0; i < _numberOfAnimals; i++)
            {
                int genderNumber = _random.Next(minimumNumberGender, maximumNumberGender);

                if (genderNumber == 1)
                {
                    animalGender = _maleGender;
                }
                else
                {
                    animalGender = _femaleGender;
                }

                _animals.Add(new Animal(_animalName, _animalSound, animalGender));
            }
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
            Console.WriteLine($"Вольер номер {_number}, {_description}, тут живут: {_animalName}");
        }
    }

    class Animal
    {
        private string _name;
        private string _sound;
        private string _gender;

        public Animal(string animalName, string animalSound, string animalGender)
        {
            _name = animalName;
            _sound = animalSound;
            _gender = animalGender;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"{_name} , пол особи: {_gender}, издает звук: {_sound}");
        }
    }
}