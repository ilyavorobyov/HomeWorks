using System;
using System.Collections.Generic;

namespace CarService
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CarService carService = new CarService();
            carService.Work();
        }
    }

    class CarService
    {
        private WareHouse _wareHouse = new WareHouse();
        private int _money = 0;
        private int _fine = 500;
        private int _priceForWork = 300;

        public void Work()
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
            int fullPrice = _wareHouse.GetDetailPrice(client.GetNecessaryPartName()) + _priceForWork;
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

            if (int.TryParse(userInput, out autopartNumber) && autopartNumber > 0 && autopartNumber <= _wareHouse.GetAutopartsLenght())
            {
                autoPart = _wareHouse.GetAutoPartFromList(autopartNumber);
                InstallDetail(client, autoPart, fullPrice);
            }
            else if (userInput == RefuseClientCommand)
            {
                _money -= _fine;
                Console.WriteLine($"Клиенту отказано в ремонте, штраф {_fine} рублей");
            }
            else
            {
                _money -= _fine;
                Console.WriteLine($"Клиент вас не понял, и остался недоволен, штраф {_fine} рублей");
            }

            Console.ReadKey();
        }

        private void InstallDetail(Client client, AutoPart autoPart, int fullPrice)
        {
            if (client.GetNecessaryPartName() == autoPart.Name)
            {
                _money += fullPrice;
                Console.WriteLine($"Деталь успешно заменена! Клиент заплатил {fullPrice} рублей");
                _wareHouse.RemovePart(autoPart);
            }
            else
            {
                int indemnification = autoPart.Price + _fine;
                _money -= indemnification;
                Console.WriteLine($"Вы заменили не ту деталь! Возмещение ущерба {indemnification} рублей");
            }
        }
    }

    class WareHouse
    {
        private static Random _random = new Random();
        private List<AutoPart> _autoParts = new List<AutoPart>();
        private PartsDatabase _partsDatabase = new PartsDatabase();
        private int _capacity = 20;

        public WareHouse()
        {
            FillWithAutoParts();
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

        public int GetDetailPrice(string necessaryPart)
        {
            int partPrice = _partsDatabase.GetAutoPartPrice(necessaryPart);
            return partPrice;
        }

        private void FillWithAutoParts()
        {
            for (int i = 0; i < _capacity; i++)
            {
                int minNumber = 0;
                int maxNumber = PartsDatabase.GetAutoPartsLength();
                int partNumber = _random.Next(minNumber, maxNumber);
                _autoParts.Add(PartsDatabase.GetAutoPart(partNumber));
            }
        }
    }

    class PartsDatabase
    {
        private static List<AutoPart> _autoPartsСatalog = new List<AutoPart>();

        public PartsDatabase()
        {
            _autoPartsСatalog.Add(new AutoPart("Двигатель", 1000, "Поломка двигателя"));
            _autoPartsСatalog.Add(new AutoPart("Аккумулятор", 500, "Поломка аккумулятора"));
            _autoPartsСatalog.Add(new AutoPart("Коробка передач", 700, "Поломка коробки передач"));
            _autoPartsСatalog.Add(new AutoPart("Сцепление", 600, "Поломка сцепления"));
        }

        public static int GetAutoPartsLength()
        {
            return _autoPartsСatalog.Count;
        }

        public static AutoPart GetAutoPart(int number)
        {
            return _autoPartsСatalog[number];
        }

        public int GetAutoPartPrice(string autoPartName)
        {
            int price = 0;

            foreach (AutoPart autoPart in _autoPartsСatalog)
            {
                if (autoPart.Name == autoPartName)
                {
                    price = autoPart.Price;
                }
            }

            return price;
        }
    }

    class Client
    {
        private static Random _random = new Random();
        private AutoPart _necessaryPart;

        public Client()
        {
            FindBreakdown();
        }

        public string BreakdownDescription { get; private set; }

        public string GetNecessaryPartName()
        {
            return _necessaryPart.Name;
        }

        private void FindBreakdown()
        {
            int minNumber = 0;
            int maxNumber = PartsDatabase.GetAutoPartsLength();
            int numberNecessaryPart = _random.Next(minNumber, maxNumber);
            _necessaryPart = PartsDatabase.GetAutoPart(numberNecessaryPart);
            BreakdownDescription = _necessaryPart.BreakdownDescription;
        }
    }

    class AutoPart
    {
        public AutoPart(string name, int price, string breakdownDescription)
        {
            Name = name;
            Price = price;
            BreakdownDescription = breakdownDescription;
        }

        public string Name { get; private set; }
        public int Price { get; private set; }
        public string BreakdownDescription { get; private set; }
    }
}