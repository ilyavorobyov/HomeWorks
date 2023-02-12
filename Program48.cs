using System;
using System.Collections.Generic;

namespace supermarket
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Supermarket supermarket = new Supermarket();
            supermarket.Work();
        }
    }

    class Supermarket
    {
        private List<Product> _productsAssortment = new List<Product>();
        private Queue<Buyer> _buyers = new Queue<Buyer>();
        private int _money = 0;

        public Supermarket()
        {
            AddRangeOfProducts();
            CreateClientQueue();
        }

        public void Work()
        {
            const string TakeBuyerCommand = "1";
            const string AddQueueCommand = "2";
            const string ExitCommand = "3";

            string errorInput = "Введена неверная команда, попробуй ещё раз";
            string exitText = "Магазин закрыт";
            bool isWork = true;

            while (isWork)
            {
                Console.Clear();
                Console.WriteLine($"Денег у супермаркета: {_money} рублей, в очереди - {_buyers.Count} покупателей");
                Console.WriteLine($"Вводи команды:\n{TakeBuyerCommand} - принять покупателя\n{AddQueueCommand} - пригласить новых покупателей\n{ExitCommand} - закрыть магазин");
                string input = Console.ReadLine();

                switch (input)
                {
                    case TakeBuyerCommand:
                        AcceptBuyer();
                        break;

                    case AddQueueCommand:
                        CreateClientQueue();
                        break;

                    case ExitCommand:
                        Console.WriteLine(exitText);
                        isWork = false;
                        break;

                    default:
                        Console.WriteLine(errorInput);
                        Console.ReadKey();
                        break;
                }
            }
        }

        private void AcceptBuyer()
        {
            if (_buyers.Count > 0)
            {
                СalculateTheCost(_buyers.Dequeue());
            }
            else
            {
                Console.WriteLine("Очередь кончилась, ждем новых покупателей.");
                Console.ReadKey();
            }
        }

        private void СalculateTheCost(Buyer buyer)
        {
            int totalPrice = 0;
            List<Product> cart = buyer.GiveCartToCashier();
            bool isNotEnoughMoney = true;

            foreach (Product product in cart)
            {
                totalPrice = totalPrice + product.Price;
            }

            Console.WriteLine($"Сумма покупки {totalPrice} рублей, нажмите чтобы назвать эту сумму покупателю");
            Console.ReadKey();

            while (isNotEnoughMoney)
            {
                if (totalPrice > buyer.Money)
                {
                    isNotEnoughMoney = true;
                    buyer.DeleteProduct(ref totalPrice);
                }
                else
                {
                    isNotEnoughMoney = false;
                    TakeBuyerMoney(totalPrice);
                }
            }

            Console.ReadKey();
        }

        private void TakeBuyerMoney(int totalPrice)
        {
            Console.WriteLine($"В кассу магазина добавлено {totalPrice} рублей");
            _money = _money + totalPrice;
            Console.WriteLine("Денег хватило! Покупка совершена");
        }

        private void AddRangeOfProducts()
        {
            _productsAssortment.Add(new Product("Хлеб", 10));
            _productsAssortment.Add(new Product("Молоко", 15));
            _productsAssortment.Add(new Product("Макароны", 20));
            _productsAssortment.Add(new Product("Йогурт", 17));
            _productsAssortment.Add(new Product("Колбаса", 30));
            _productsAssortment.Add(new Product("Печенье", 16));
            _productsAssortment.Add(new Product("Шоколадка", 22));
        }

        private void CreateClientQueue()
        {
            int clientCount = 8;

            for (int i = 0; i < clientCount; i++)
            {
                _buyers.Enqueue(new Buyer(_productsAssortment));
            }
        }
    }

    class Buyer
    {
        private static Random _random = new Random();
        private List<Product> _cart = new List<Product>();

        public Buyer(List<Product> productsAssortment)
        {
            int minAmountMoney = 80;
            int maxAmountMoney = 130;
            int minAmountOfProducts = 4;
            int maxAmountOfProducts = 9;
            int numberOfProducts = _random.Next(minAmountOfProducts, maxAmountOfProducts);

            Money = _random.Next(minAmountMoney, maxAmountMoney);

            for (int i = 0; i <= numberOfProducts; i++)
            {
                int randomProductIndex = _random.Next(0, productsAssortment.Count - 1);
                _cart.Add(productsAssortment[randomProductIndex]);
            }
        }

        public int Money { get; private set; }

        public List<Product> GiveCartToCashier()
        {
            return _cart;
        }

        public void DeleteProduct(ref int totalPrice)
        {
            Console.WriteLine("У покупателя не хватило денег, он начал убирать товары из своей корзины");
            int randomIndex = _random.Next(0, _cart.Count);
            Product productToRemove = _cart[randomIndex];
            totalPrice = totalPrice - productToRemove.Price;
            _cart.Remove(productToRemove);
            Console.WriteLine("удален продукт из корзины покупателя");
            Console.ReadKey();
        }
    }

    class Product
    {
        private string _name;

        public Product(string name, int price)
        {
            _name = name;
            Price = price;
        }

        public int Price { get; private set; }
    }
}