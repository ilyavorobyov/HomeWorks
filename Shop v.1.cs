using System;
using System.Collections.Generic;
using System.Linq;

namespace ShopNapilnik1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Good iPhone12 = new Good("IPhone 12");
            Good iPhone11 = new Good("IPhone 11");

            Warehouse warehouse = new Warehouse();

            Shop shop = new Shop(warehouse);

            warehouse.Delive(iPhone12, 10);
            warehouse.Delive(iPhone11, 1);

            //Вывод всех товаров на складе с их остатком

            Cart cart = shop.Cart();
            cart.Add(iPhone12, 4);
            cart.Add(iPhone11, 3); //при такой ситуации возникает ошибка так, как нет нужного количества товара на складе

            //Вывод всех товаров в корзине

            Console.WriteLine(cart.Order().Paylink);

            cart.Add(iPhone12, 9); //Ошибка, после заказа со склада убираются заказанные товары
        }
    }

    class Shop
    {
        private Warehouse _warehouse;

        public Shop(Warehouse warehouse)
        {
            _warehouse = warehouse;
        }

        public Cart Cart()
        {
            return new Cart(_warehouse);
        }
    }

    public class Warehouse : IWarehouse
    {
        private Dictionary<Good, int> _cells = new Dictionary<Good, int>();

        public void Delive(Good good, int count)
        {
            if (count < 0)
                throw new ArgumentOutOfRangeException();

            if (IsHasGood(good, count) == false)
                _cells[good] = 0;

            _cells[good] += count;
        }

        public bool IsHasGood(Good good, int count)
        {
            if (_cells.ContainsKey(good) == false)
                return false;

            return _cells[good] >= count;
        }

        public void RemoveGood(Good good, int count)
        {
            if (IsHasGood(good, count))
                _cells[good] -= count;
        }

        public void Show()
        {
            Console.WriteLine("На складе:");

            foreach (var cell in _cells)
            {
                Console.WriteLine($"Товар: {cell.Key.Name}");
                Console.WriteLine($"Количество: {cell.Value}");
            }

            Console.WriteLine();
        }
    }

    public class Cart
    {
        private IWarehouse _warehouse;

        private Dictionary<Good, int> _goods = new Dictionary<Good, int>();

        public Cart(IWarehouse warehouse)
        {
            _warehouse = warehouse;
        }

        public void Add(Good good, int count)
        {
            if (count < 0)
                throw new ArgumentOutOfRangeException();

            if (_warehouse.IsHasGood(good, count) == false)
                throw new ArgumentOutOfRangeException();

            if (_goods.ContainsKey(good))
            {
                _goods[good] += count;
                return;
            }

            _goods.Add(good, count);
        }

        public Order Order()
        {
            IReadOnlyDictionary<Good, int> goods = _goods;
            Order order = new Order(goods);

            _warehouse.RemoveGood(order.CurrentOrder.Key, order.CurrentOrder.Value);

            _goods[order.CurrentOrder.Key] -= order.CurrentOrder.Value;

            if (_goods[order.CurrentOrder.Key] == 0)
            {
                _goods.Remove(order.CurrentOrder.Key);
            }

            return order;
        }

        public void Show()
        {
            Console.WriteLine("Товары в корзине:");

            foreach (var good in _goods)
            {
                Console.WriteLine($"Товар: {good.Key.Name}");
                Console.WriteLine($"Количество: {good.Value}");
            }

            Console.WriteLine();
        }
    }

    public class Order
    {
        private IReadOnlyDictionary<Good, int> _goods;

        public Order(IReadOnlyDictionary<Good, int> orders)
        {
            _goods = orders;
        }

        public KeyValuePair<Good, int> CurrentOrder => _goods.FirstOrDefault();

        public string Paylink { get; private set; } = "gtqpUBYPirSz";
    }

    public class Good
    {
        public Good(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }
    }

    public interface IWarehouse
    {
        bool IsHasGood(Good good, int count);

        void RemoveGood(Good good, int count);
    }
}