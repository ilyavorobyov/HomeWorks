using System;
using System.Collections.Generic;

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
        private Player _player = new Player(100);
        private SalesMan _salesMan = new SalesMan(0);

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
                Console.Write("Введите название товара, который вы хотите купить: ");
                input = Console.ReadLine();
                _salesMan.CheckProductAvailability(ref isHaveProduct, input);

                if (isHaveProduct)
                {
                    bool isEnoughMoney = _player.CheckSolvency(_salesMan.HandOverSoldProduct());

                    if (isEnoughMoney)
                    {
                        _salesMan.ReceiveMoneyForProduct();
                        _player.ReceivePurchasedProduct(_salesMan.HandOverSoldProduct());
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

    class SalesMan : Human
    {
        private Product _soldProduct;

        public SalesMan(int money) : base(money)
        {
            AddStartProducts();
        }

        public int CheckNumberOfProducts()
        {
            return Goods.Count;
        }

        public void CheckProductAvailability(ref bool isHaveProduct, string input)
        {
            foreach (Product good in Goods)
            {
                if (input == good.Name)
                {
                    _soldProduct = good;
                    isHaveProduct = true;
                    Goods.Remove(good);
                    break;
                }
                else
                {
                    isHaveProduct = false;
                }
            }
        }

        public void ReceiveMoneyForProduct()
        {
            Money += _soldProduct.Price;
        }

        public Product HandOverSoldProduct()
        {
            return _soldProduct;
        }

        private void AddStartProducts()
        {
            Goods.Add(new Product("Bread", 10));
            Goods.Add(new Product("Milk", 20));
            Goods.Add(new Product("Chocolate", 30));
            Goods.Add(new Product("Potatoes", 15));
            Goods.Add(new Product("Sausage", 35));
            Goods.Add(new Product("Apples", 15));
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
            foreach (Product product in Goods)
            {
                Console.WriteLine($"Продукт: {product.Name}, cтоимость: {product.Price}");
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
