using System;
using System.Collections.Generic;

namespace trainconfig
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StationManager stationManager = new StationManager();
            stationManager.ShowManagerPanel();
        }
    }

    class StationManager
    {
        private List<Train> _trains = new List<Train>();
        private string _arrivalCity;
        private string _dispatchСity;
        private int _soldTickets;
        private int _minPassengers = 250;
        private int _maxPassengers = 500;

        public void ShowManagerPanel()
        {
            const string CreateNewRouteCommand = "1";
            const string ExitCommand = "2";

            string errorInput = "Введена неверная команда, попробуй ещё раз";
            string exitText = "Выполнение программы завершено";
            bool isWork = true;

            while (isWork)
            {
                Console.Clear();
                ShowTrainsInfo();
                Console.WriteLine($"Вводи команды:\n{CreateNewRouteCommand} - создать новый поезд\n{ExitCommand} - выход из программы");
                string input = Console.ReadLine();

                switch (input)
                {
                    case CreateNewRouteCommand:
                        CreateRoute();
                        Console.ReadKey();
                        break;

                    case ExitCommand:
                        isWork = false;
                        Console.WriteLine(exitText);
                        break;

                    default:
                        Console.WriteLine(errorInput);
                        Console.ReadKey();
                        break;
                }
            }
        }

        public void CreateRoute()
        {
            Console.Write("Укажите город, откуда поезд уедет: ");
            _arrivalCity = Console.ReadLine();
            Console.Write("Укажите город, до которого поезд едет: ");
            _dispatchСity = Console.ReadLine();
            Console.WriteLine($"Был создан поезд маршрута {_arrivalCity} - {_dispatchСity}, нажми любую кнопку чтобы продать на него билеты");
            Console.ReadKey();
            SellTickets();
        }

        private void SellTickets()
        {
            Random random = new Random();
            _soldTickets = random.Next(_minPassengers, _maxPassengers);
            Console.WriteLine($"Было продано {_soldTickets} билетов, чтобы отправить поезд нажми любую кнопку");
            Console.ReadKey();
            AddTrain();
        }

        private void AddTrain()
        {
            _trains.Add(new Train(_arrivalCity, _dispatchСity, _soldTickets));
        }

        public void ShowTrainsInfo()
        {
            if (_trains.Count > 0)
            {
                foreach (var train in _trains)
                {
                    train.ShowTrainInfo();
                }
            }
            else
            {
                Console.WriteLine("Поездов еще нет");
            }
        }
    }

    class Train
    {
        private List<RailwayCarriage> _carriages = new List<RailwayCarriage>();
        private RailwayCarriage _carriage = new RailwayCarriage();

        private string _arrivalCity;
        private string _dispatchСity;
        private int _soldTickets;
        private int _requiredNumberOfRailwayWagons;

        public Train(string arrivalCity, string dispatchCity, int soldTickets)
        {
            _arrivalCity = arrivalCity;
            _dispatchСity = dispatchCity;
            _soldTickets = soldTickets;
            SetTheNumberOfRailwayCarriages();
        }

        private void SetTheNumberOfRailwayCarriages()
        {
            _requiredNumberOfRailwayWagons = _soldTickets / _carriage.NumberOfSeats;
            ++_requiredNumberOfRailwayWagons;
            AddCarriages();
        }

        private void AddCarriages()
        {
            for (int i = 0; i < _requiredNumberOfRailwayWagons; i++)
            {
                _carriages.Add(_carriage);
            }
        }

        public void ShowTrainInfo()
        {
            Console.WriteLine($"Поезд маршрута {_arrivalCity} - {_dispatchСity} было продано {_soldTickets} билетов, потребовалось вагонов: {_carriages.Count}");
        }
    }

    class RailwayCarriage
    {
        public int NumberOfSeats { get; private set; } = 50;
    }

}
