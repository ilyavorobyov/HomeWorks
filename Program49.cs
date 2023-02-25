using System;
using System.Collections.Generic;

namespace CarService
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CarService carService = new CarService();
            carService.ShowManagerPanel();
        }
    }

    class CarService
    {
        private WareHouse _wareHouse = new WareHouse();
        private int _money = 0;
        private int _fine = 500;
        private int _priceForWork = 300;

        public void ShowManagerPanel()
        {
            const string NewСlientСommand = "1";
            const string ExitCommand = "2";

            string errorInput = "Введена неверная команда, попробуй ещё раз";
            string exitText = "Выполнение программы завершено";
            bool isWork = true;

            while (isWork)
            {
                Console.Clear();
                ShowBalance();
                Console.WriteLine($"Вводи команды:\n{NewСlientСommand} - принять нового клиента\n{ExitCommand} - выход из программы");
                string input = Console.ReadLine();

                switch (input)
                {
                    case NewСlientСommand:
                        AcceptСlient();
                        break;

                    case ExitCommand:
                        isWork = false;
                        break;

                    default:
                        Console.WriteLine(errorInput);
                        Console.ReadKey();
                        break;
                }
            }

            Console.WriteLine(exitText);
            Console.ReadKey();
        }

        private void ShowBalance()
        {
            Console.WriteLine($"Баланс автосервиса {_money} рублей");
        }

        private void AcceptСlient()
        {
            Client client = new Client();
            Console.Clear();
            ShowBalance();
            int fullPrice = _wareHouse.GetDetailPrice(client.NecessaryPart) + _priceForWork;
            Console.WriteLine($"У клиента поломка: {client.BreakdownDescription}, цена починки {fullPrice} рублей");
            _wareHouse.ShowAll();
            FindPartForClient(client, fullPrice);
        }

        private void FindPartForClient(Client client, int fullPrice)
        {
            const string RefuseClientCommand = "No";
            AutoPart autoPart;
            Console.Write($"Введите {RefuseClientCommand} чтобы отказать клиенту в ремонте\nИли введите номер детали, которую хотите поставить клиенту:"); ;
            string userInput;
            int autopartNumber;
            userInput = Console.ReadLine();

            if (int.TryParse(userInput, out autopartNumber))
            {
                if (autopartNumber > 0 && autopartNumber <= _wareHouse.GetAutopartsLenght())
                {
                    autoPart = _wareHouse.GetAutoPartFromList(autopartNumber);
                    CheckPartCompatibility(client, autoPart, fullPrice);
                }
                else
                {
                    Console.WriteLine("Детали с таким номером нет!");
                }
            }
            else
            {
                if (userInput == RefuseClientCommand)
                {
                    _money -= _fine;
                    Console.WriteLine($"Клиенту отказано в ремонте, штраф {_fine} рублей");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("Данные введены неверно, попробуй ещё раз");
                }
            }
        }

        private void CheckPartCompatibility(Client client, AutoPart autoPart, int fullPrice)
        {
            if (client.NecessaryPart == autoPart.Name)
            {
                _money += fullPrice;
                Console.WriteLine($"Деталь успешно заменена! Клиент заплатил {fullPrice} рублей");
                _wareHouse.RemovePart(autoPart);
                Console.ReadLine();
            }
            else
            {
                int indemnification = autoPart.Price + _fine;
                _money -= indemnification;
                Console.WriteLine($"Вы заменили не ту деталь! Возмещение ущерба {indemnification} рублей");
                Console.ReadLine();
            }
        }
    }

    class WareHouse
    {
        private List<AutoPart> _autoParts = new List<AutoPart>();
        private static Random _random = new Random();
        private int _enginePrice = 1000;
        private int _accumulatorPrice = 500;
        private int _transmissionPrice = 700;
        private int _clutchPrice = 600;

        private int _capacity = 20;

        public WareHouse()
        {
            FillWithAutoParts(_capacity);
        }

        public void ShowAll()
        {
            int number = 1;
            Console.WriteLine("\nСписок деталей на складе:\n");

            foreach (AutoPart autoPart in _autoParts)
            {
                Console.WriteLine($"{number} Деталь: {autoPart.Name}, цена: {autoPart.Price}");
                number++;
            }
        }

        public AutoPart GetAutoPartFromList(int autopartNumber)
        {
            return _autoParts[autopartNumber - 1];
        }

        public void RemovePart(AutoPart autoPart)
        {
            _autoParts.Remove(autoPart);
        }

        public int GetAutopartsLenght()
        {
            return _autoParts.Count;
        }

        public int GetDetailPrice(string NecessaryPart)
        {
            const string Engine = "Двигатель";
            const string Accumulator = "Аккумулятор";
            const string Transmission = "Коробка передач";
            const string Clutch = "Сцепление";

            int partPrice;

            switch (NecessaryPart)
            {
                case Engine:
                    partPrice = _enginePrice;
                    break;

                case Accumulator:
                    partPrice = _accumulatorPrice;
                    break;

                case Transmission:
                    partPrice = _transmissionPrice;
                    break;

                case Clutch:
                    partPrice = _clutchPrice;
                    break;

                default:
                    partPrice = 0;
                    break;
            }

            return partPrice;

        }

        private void FillWithAutoParts(int capacity)
        {
            for (int i = 0; i < capacity; i++)
            {
                int minNumber = 0;
                int maxNumber = 4;
                int breakdownNumber = _random.Next(minNumber, maxNumber);

                if (breakdownNumber == 0)
                {
                    _autoParts.Add(new AutoPart("Двигатель", _enginePrice));
                }
                else if (breakdownNumber == 1)
                {
                    _autoParts.Add(new AutoPart("Аккумулятор", _accumulatorPrice));
                }
                else if (breakdownNumber == 2)
                {
                    _autoParts.Add(new AutoPart("Коробка передач", _transmissionPrice));
                }
                else if (breakdownNumber == 3)
                {
                    _autoParts.Add(new AutoPart("Сцепление", _clutchPrice));
                }
            }
        }
    }

    class Client
    {
        private static Random _random = new Random();

        public Client()
        {
            FindBreakdown();
        }

        public string BreakdownDescription { get; private set; }
        public string NecessaryPart { get; private set; }

        private void FindBreakdown()
        {
            int minNumber = 0;
            int maxNumber = 4;
            int breakdownNumber = _random.Next(minNumber, maxNumber);

            if (breakdownNumber == 0)
            {
                BreakdownDescription = "Поломка двигателя";
                NecessaryPart = "Двигатель";
            }
            else if (breakdownNumber == 1)
            {
                BreakdownDescription = "Поломка аккумулятора";
                NecessaryPart = "Аккумулятор";
            }
            else if (breakdownNumber == 2)
            {
                BreakdownDescription = "Поломка коробки передач";
                NecessaryPart = "Коробка передач";
            }
            else
            {
                BreakdownDescription = "Поломка сцепления";
                NecessaryPart = "Сцепление";
            }
        }
    }

    class AutoPart
    {
        public AutoPart(string name, int price)
        {
            Name = name;
            Price = price;
        }

        public string Name { get; private set; }
        public int Price { get; private set; }
    }
}