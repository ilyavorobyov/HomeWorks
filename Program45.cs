using System;
using System.Collections.Generic;

namespace aquarium
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AquariumManager aquariumManager = new AquariumManager();
            aquariumManager.Work();
        }
    }

    class Aquarium
    {
        private int _maxNumberOfFish = 15;
        public int _fishId = 1;
        private List<Fish> _fishes = new List<Fish>();

        public Aquarium()
        {
            for (int i = 0; i < _maxNumberOfFish; i++)
            {
                _fishes.Add(new Fish(_fishId));
                _fishId++;
            }
        }

        public void AddFish()
        {
            if (_fishes.Count >= _maxNumberOfFish)
            {
                Console.WriteLine("Рыбок в аквариуме максимальное количество");
            }
            else
            {
                _fishes.Add(new Fish(_fishId));
                Console.WriteLine($"Рыбка с номером {_fishId} успешно добавлена");
                _fishId++;
            }

            IncreaseAgeOfFishes();
        }

        public void DeleteFish()
        {
            int numberToDecrease = 1;
            string userInput;
            int fishNumber;
            Console.Write("Введите номер рыбки, которую хотите удалить из аквариума: ");
            userInput = Console.ReadLine();

            if (int.TryParse(userInput, out fishNumber))
            {
                if (fishNumber > 0 && fishNumber <= _fishes.Count)
                {
                    _fishes.Remove(_fishes[fishNumber - numberToDecrease]);
                    Console.WriteLine("Рыбка удалена из аквариума");
                }
                else
                {
                    Console.WriteLine("Рыбки с таким номером нет");
                }
            }
            else
            {
                Console.WriteLine("Данные введены неверно, попробуй ещё раз");
            }

            IncreaseAgeOfFishes();
        }

        public void ShowFishes()
        {
            foreach (Fish fish in _fishes)
            {
                fish.ShowInfo();
            }
        }

        public void IncreaseAgeOfFishes()
        {
            foreach (Fish fish in _fishes)
            {
                fish.AddAge();
            }
        }

        public void DeleteOldFish()
        {
            for (int i = 0; i < _fishes.Count; i++)
            {
                if (_fishes[i].IsAlive == false)
                {
                    Console.WriteLine($"Рыбка {_fishes[i].FishId} умерла от старости");
                    _fishes.Remove(_fishes[i]);
                    DeleteOldFish();
                }
            }
        }
    }

    class AquariumManager
    {
        Aquarium aquarium = new Aquarium();

        public void Work()
        {
            const string AddFishCommand = "1";
            const string DeleteFishCommand = "2";
            const string AddFishAgeCommand = "3";
            const string ExitCommand = "4";

            string errorInput = "Введена неверная команда, попробуй ещё раз";
            string exitText = "Выполнение программы завершено";
            bool isWork = true;

            while (isWork)
            {
                aquarium.ShowFishes();

                Console.WriteLine($"\nАквариум:\n{AddFishCommand} Добавить рыбку \n{DeleteFishCommand} Удалить рыбку " +
                   $"\n{AddFishAgeCommand} Пропустить итерацию, просто добавить возраст\n{ExitCommand} Завершить выполнение программы\n");
                Console.Write("Введите команду: ");
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case AddFishCommand:
                        aquarium.AddFish();
                        break;

                    case DeleteFishCommand:
                        aquarium.DeleteFish();
                        break;

                    case AddFishAgeCommand:
                        aquarium.IncreaseAgeOfFishes();
                        break;

                    case ExitCommand:
                        Console.WriteLine(exitText);
                        isWork = false;
                        break;

                    default:
                        Console.WriteLine(errorInput);
                        break;
                }

                aquarium.DeleteOldFish();
                Console.ReadKey();
                Console.Clear();
            }
        }
    }

    class Fish
    {
        private int _maxAge = 6;

        public Fish(int fishId)
        {
            FishId = fishId;
        }

        public int FishId { get; private set; }
        public int Age { get; private set; } = 0;
        public bool IsAlive { get; private set; } = true;

        public void AddAge()
        {
            ++Age;

            if (Age >= _maxAge)
            {
                IsAlive = false;
            }
        }

        public void ShowInfo()
        {
            Console.WriteLine($"Рыбка номер {FishId}, её возраст {Age}");
        }
    }
}