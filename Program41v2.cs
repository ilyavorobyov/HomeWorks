using System;
using System.Collections.Generic;
using System.Security.Policy;

namespace ConsoleApp64
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Shop shop = new Shop();
            shop.Work();
        }
    }

    class Shop
    {
        const string ShowSalesmanGoodsCommand = "1";
        const string SellProductCommand = "2";
        const string ShowPlayerGoodsCommand = "3";
        const string ExitCommand = "4";

        string errorInput = "Введена неверная команда, попробуй ещё раз";
        string exitText = "Выполнение программы завершено";
        bool isWork = true;

        public void Work()
        {
            SalesMan salesMan = new SalesMan();
            Player player = new Player(25);

            while (isWork)
            {
                Console.Clear();
                Console.WriteLine($"У вас осталось: {player.Money} рублей");
                Console.WriteLine($"Вводи команды:\n{ShowSalesmanGoodsCommand} - показать все товары продавца\n{SellProductCommand} - купить продукт из списка доступных" +
                    $"\n{ShowPlayerGoodsCommand} - показать товары игрока \n{ExitCommand} - выход из программы");
                string input = Console.ReadLine();

                switch (input)
                {
                    case ShowSalesmanGoodsCommand:
                        salesMan.ShowAllGoods();
                        Console.ReadKey();
                        break;

                    case SellProductCommand:
                        salesMan.SellProduct(player);
                        break;

                    case ShowPlayerGoodsCommand:
                        player.ShowAllGoods();
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
    }

    class Player
    {
        private List<Product> _goods = new List<Product>();
        public int Money { get; private set; }

        public Player(int money)
        {
            if (money <= 20)
            {
                Money = 100;
            }
            else
            {
                Money = money;
            }
        }

        public void AddProduct(Product product)
        {
            _goods.Add(product);
        }

        public void ShowAllGoods()
        {
            foreach (Product product in _goods)
            {
                Console.WriteLine($"Продукт: {product.Name}");
            }
        }

        public bool CheckSolvency(Product good)
        {
            if (Money >= good.Price)
            {
                Money -= good.Price;
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    class SalesMan
    {
        private List<Product> _goods = new List<Product>() { new Product("Bread", 10), new Product("Milk", 20), new Product("Chocolate", 30), new Product("Potatoes", 15), new Product("Sausage", 35) };

        public void ShowAllGoods()
        {
            foreach (Product product in _goods)
            {
                Console.WriteLine($"Продукт: {product.Name}, стоимость: {product.Price}");
            }
        }

        public void SellProduct(Player player)
        {
            ShowAllGoods();
            bool isHaveProduct = false;
            string input;
            bool isEnoughMoney = false;

            if (_goods.Count > 0)
            {
                Console.Write("Введите название товара, который вы хотите купить: ");
                input = Console.ReadLine();
                isHaveProduct = false;


                foreach (Product good in _goods)
                {
                    if (_goods.Count > 0)
                    {
                        if (input == good.Name)
                        {
                            isEnoughMoney = player.CheckSolvency(good);

                            if (isEnoughMoney)
                            {
                                _goods.Remove(good);
                                Console.WriteLine($"Товар {good.Name} успешно куплен!");
                                isHaveProduct = true;
                                player.AddProduct(good);
                                Console.ReadKey();
                                break;
                            }
                            else
                            {
                                Console.WriteLine($"Денег на покупку {good.Name} не достаточно!");
                                break;
                            }
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("У продавца не остолось товаров");
                Console.ReadKey();
                isHaveProduct = true;
            }

            if (isHaveProduct == false)
            {
                Console.WriteLine("Такого товара у продавца нет");
                Console.ReadKey();
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

        public string Name { get; private set; }
        public int Price { get; private set; }
        public void ShowInventory()
        {
            Console.WriteLine($"Продукт - {Name}, цена: {Price}");
        }
    }
}