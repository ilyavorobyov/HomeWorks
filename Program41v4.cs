using System;
using System.Collections.Generic;

namespace ConsoleApp64
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Player _player = new Player(150);
            SalesMan _salesMan = new SalesMan(0);
            Shop shop = new Shop(_player, _salesMan);
            shop.Work();
        }
    }

    class Shop
    {
        private Player _player;
        private SalesMan _salesMan;

        public Shop(Player player, SalesMan salesMan)
        {
            _player = player;
            _salesMan = salesMan;
        }

        public void Work()
        {
            const string ShowSalesmanGoodsCommand = "1";
            const string SellProductCommand = "2";
            const string ShowPlayerGoodsCommand = "3";
            const string ExitCommand = "4";

            string errorInput = "Введена неверная команда, попробуй ещё раз";
            string exitText = "Выполнение программы завершено";
            bool isWork = true;

            while (isWork)
            {
                Console.Clear();
                Console.WriteLine($"У вас осталось: {_player.Money} рублей, у продавца - {_salesMan.Money} рублей");
                Console.WriteLine($"Вводи команды:\n{ShowSalesmanGoodsCommand} - показать все товары продавца\n{SellProductCommand} - купить продукт из списка доступных" +
                    $"\n{ShowPlayerGoodsCommand} - показать товары игрока \n{ExitCommand} - выход из программы");
                string input = Console.ReadLine();

                switch (input)
                {
                    case ShowSalesmanGoodsCommand:
                        _salesMan.ShowAllGoods();
                        break;

                    case SellProductCommand:
                        Trade();
                        break;

                    case ShowPlayerGoodsCommand:
                        _player.ShowAllGoods();
                        break;

                    case ExitCommand:
                        Console.WriteLine(exitText);
                        isWork = false;
                        break;

                    default:
                        Console.WriteLine(errorInput);
                        break;
                }

                Console.ReadKey();
            }
        }

        private void Trade()
        {
            _salesMan.ShowAllGoods();
            bool isHaveProduct = false;
            string input;
            int numberOfSalesmanProducts = _salesMan.CheckNumberOfProducts();

            if (numberOfSalesmanProducts > 0)
            {
                Console.Write("Введите номер товара, который вы хотите купить: ");
                input = Console.ReadLine();
                int productNumber;
                int productIndex = 0;

                if (int.TryParse(input, out productNumber))
                {
                    _salesMan.CheckProductAvailability(ref isHaveProduct, productNumber, ref productIndex);

                    if (isHaveProduct)
                    {
                        Product soldProduct = _salesMan.GiveAwayProduct(productIndex);
                        bool isEnoughMoney = _player.CheckSolvency(soldProduct);

                        if (isEnoughMoney)
                        {
                            _salesMan.ReceiveMoneyForProduct(soldProduct);
                            _player.ReceivePurchasedProduct(soldProduct);
                            Console.Write("Товар куплен");
                        }
                        else
                        {
                            Console.Write("У вас не достаточно денег на покупку ");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Такого товара у продавца нет!");
                    }
                }
                else
                {
                    Console.Write("Вводите цифры товара, а не символы!");
                }
            }
            else
            {
                Console.Write("У продавца больше нет товаров на продажу.");
            }
        }
    }

    class Player : Human
    {
        public Player(int money) : base(money) { }

        public void ReceivePurchasedProduct(Product product)
        {
            Goods.Add(product);
        }

        public bool CheckSolvency(Product product)
        {
            if (Money >= product.Price)
            {
                Money -= product.Price;
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    class SalesMan : Human
    {
        public SalesMan(int money) : base(money)
        {
            AddStartProducts();
        }

        public int CheckNumberOfProducts()
        {
            return Goods.Count;
        }

        public void CheckProductAvailability(ref bool isHaveProduct, int productNumber, ref int productIndex)
        {
            if (productNumber > 0 && productNumber <= Goods.Count)
            {
                for (int i = 0; i < Goods.Count; i++)
                {
                    if (i == productNumber - 1)
                    {
                        isHaveProduct = true;
                        productIndex = i;
                        break;
                    }
                }
            }
            else
            {
                isHaveProduct = false;
            }
        }

        public Product GiveAwayProduct(int productIndex)
        {
            return Goods[productIndex];
        }

        public void ReceiveMoneyForProduct(Product product)
        {
            Money += product.Price;
            Goods.Remove(product);
        }

        private void AddStartProducts()
        {
            Goods.Add(new Product("Хлеб", 10));
            Goods.Add(new Product("Молоко", 20));
            Goods.Add(new Product("Шоколад", 30));
            Goods.Add(new Product("Картошка", 15));
            Goods.Add(new Product("Сосиски", 35));
            Goods.Add(new Product("Яблоки", 15));
        }
    }

    class Human
    {
        protected List<Product> Goods = new List<Product>();

        public Human(int money)
        {
            Money = money;
        }

        public int Money { get; protected set; }

        public void ShowAllGoods()
        {
            for (int i = 0; i < Goods.Count; i++)
            {
                Console.WriteLine($"номер {i + 1}, продукт: {Goods[i].Name}, cтоимость: {Goods[i].Price}");
            }
        }
    }

    class Product
    {
        public Product(string productName, int price)
        {
            Name = productName;
            Price = price;
        }

        public string Name { get; }
        public int Price { get; }
    }
}