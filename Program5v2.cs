using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp12
{
    internal class Program6
    {
        static void Main(string[] args)
        {
            int userGold;
            int crystalPrice = 5;
            int countOfCrystalsToBuy;

            Console.Write("Добро пожаловать в магазин! Сколько у вас золота?: ");
            userGold = Convert.ToInt32(Console.ReadLine());
            Console.Write("Цена одного кристалла: " + crystalPrice + " Сколько кристаллов вы хотите купить?: ");
            countOfCrystalsToBuy = Convert.ToInt32(Console.ReadLine());
            userGold -= crystalPrice * countOfCrystalsToBuy;
            Console.Write("Золота осталось: " + userGold + " Число кристаллов: " + countOfCrystalsToBuy);
            Console.ReadKey();
        }
    }
}