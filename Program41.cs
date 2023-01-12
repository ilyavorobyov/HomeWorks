using System;
using System.Collections.Generic;

namespace ConsoleApp45
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string ShowSalesmanGoodsCommand = "1";
            const string SellProductCommand = "2";
            const string ShowPlayerGoodsCommand = "3";
            const string ExitCommand = "4";

            string errorInput = "Введена неверная команда, попробуй ещё раз";
            string exitText = "Выполнение программы завершено";
            bool isWork = true;

            SalesMan salesMan = new SalesMan();
            Player player = new Player();

            while (isWork)
            {
                Console.Clear();
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
                        salesMan.SellProduct();
                        break;

                    case ShowPlayerGoodsCommand:
                        player.ShowPurchasedGoods();
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
        }

        class SalesMan
        {
            private List<Product> _goods = new List<Product>() { new Product("Bread"), new Product("Milk"), new Product("Chocolate"), new Product("Potatoes"), new Product("Sausage") };

            public void ShowAllGoods()
            {
                foreach (Product good in _goods)
                {
                    good.ShowInventory();
                }
            }

            public void SellProduct()
            {
                ShowAllGoods();
                bool isHaveProduct = false;
                string input;

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
                                _goods.Remove(good);
                                Console.WriteLine($"Товар {good.Name} успешно куплен!");
                                isHaveProduct = true;
                                Player.AddProduct(good.Name);
                                Console.ReadKey();
                                break;
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

        class Player
        {
            private static List<string> _purchasedGoods = new List<string>();

            public void ShowPurchasedGoods()
            {
                foreach (string product in _purchasedGoods)
                {
                    Console.WriteLine(product);
                }

                Console.ReadKey();
            }

            public static void AddProduct(String productName)
            {
                _purchasedGoods.Add(productName);
            }
        }

        class Product
        {
            public Product(string productName)
            {
                Name = productName;
            }

            public string Name { get; private set; }

            public void ShowInventory()
            {
                Console.WriteLine("Имя продукта - " + Name);
            }
        }
    }
}