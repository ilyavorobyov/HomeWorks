using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp18
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> purchases = new Queue<int>();

            purchases.Enqueue(12);
            purchases.Enqueue(23);
            purchases.Enqueue(17);
            purchases.Enqueue(9);
            purchases.Enqueue(46);
            purchases.Enqueue(22);
            purchases.Enqueue(36);
            purchases.Enqueue(40);
            purchases.Enqueue(75);
            purchases.Enqueue(33);
            purchases.Enqueue(59);

            CalculateMoney(purchases);
        }

        static void CalculateMoney(Queue<int> purchases)
        {
            int purchasesCount = purchases.Count;
            int sumOfPurchases = 0;

            for (int i = 0; i < purchasesCount; i++)
            {
                sumOfPurchases += purchases.Dequeue();
                Console.WriteLine("Денег сейчас - " + sumOfPurchases);
                Console.ReadKey();
                Console.Clear();
            }

            Console.WriteLine("Теперь очередь пуста, всего денег: " + sumOfPurchases);
        }
    }
}