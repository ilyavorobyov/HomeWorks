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
        private int _soldTickets;
        private string _newRoute;

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

        private void CreateRoute()
        {
            Route route = new Route();
            _newRoute = route.CreateNew();
            SellTickets();
        }

        private void ShowTrainsInfo()
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

        private void SellTickets()
        {
            int _minPassengers = 250;
            int _maxPassengers = 500;
            Random random = new Random();
            _soldTickets = random.Next(_minPassengers, _maxPassengers);
            Console.WriteLine($"Было продано {_soldTickets} билетов, чтобы отправить поезд нажми любую кнопку");
            CalculateNumberOfCarriages(_soldTickets);
        }

        private void CalculateNumberOfCarriages(int soldTickets)
        {
            int seatsInOneCarriage;
            int requiredNumberOfRailwayWagons;
            seatsInOneCarriage = RailwayCarriage.NumberOfSeats;
            requiredNumberOfRailwayWagons = soldTickets / seatsInOneCarriage;
            ++requiredNumberOfRailwayWagons;
            AddTrain(requiredNumberOfRailwayWagons);
        }

        private void AddTrain(int requiredNumberOfRailwayWagons)
        {
            _trains.Add(new Train(_newRoute, requiredNumberOfRailwayWagons, _soldTickets));
        }
    }

    class Train
    {
        private List<RailwayCarriage> _carriages = new List<RailwayCarriage>();
        private string _route;
        private int _requiredNumberOfRailwayWagons;
        private int _soldTickets;

        public Train(string route, int requiredNumberOfRailwayWagons, int soldTickets)
        {
            _route = route;
            _requiredNumberOfRailwayWagons = requiredNumberOfRailwayWagons;
            _soldTickets = soldTickets;
            AddCarriages();
        }

        public void ShowTrainInfo()
        {
            Console.WriteLine($"Поезд маршрута {_route}, было продано {_soldTickets} билетов, потребовалось вагонов: {_carriages.Count}");
        }

        private void AddCarriages()
        {
            for (int i = 0; i < _requiredNumberOfRailwayWagons; i++)
            {
                _carriages.Add(new RailwayCarriage());
            }
        }
    }

    class RailwayCarriage
    {
        public static int NumberOfSeats = 50;
    }

    class Route
    {
        public string CreateNew()
        {
            Console.Write("Укажите город, откуда поезд уедет: ");
            string arrivalCity = Console.ReadLine();
            Console.Write("Укажите город, до которого поезд едет: ");
            string dispatchСity = Console.ReadLine();
            string newRoute = $"Был создан поезд маршрута {arrivalCity} - {dispatchСity}";
            return newRoute;
        }
    }
}