using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace getting_expired_cans_Linq
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int yearNow = 2023;
            Warehouse warehouse = new Warehouse();
            warehouse.SearchExpiredProducts(yearNow);
        }
    }

    class Warehouse
    {
        private List<СanOfStew> _сanOfStews = new List<СanOfStew>
        {
            new СanOfStew("БарсЭкстра", 2015,6), new СanOfStew("БарсЭкстра", 2010,15), new СanOfStew("Говядина ГОСТ", 2020,3), new СanOfStew("Говядина ГОСТ", 2018,3),
            new СanOfStew("Кронидов", 2019,7), new СanOfStew("Кронидов", 2018,4), new СanOfStew("ГОСТ", 2008,15), new СanOfStew("ГОСТ", 2014,13),
            new СanOfStew("Слоним", 2020,2), new СanOfStew("Слоним", 2022,2), new СanOfStew("ГродФуд", 2011,7), new СanOfStew("ГродФуд", 2020,4)
        };

        public void SearchExpiredProducts(int yearNow)
        {
            Console.WriteLine("Список всех банок на складе:");
            ShowList(_сanOfStews);
            Console.WriteLine("\nНажмите любую кнопку для поиска просроченных банок");
            Console.ReadKey();

            var expiredСans = _сanOfStews.Where(player => player.ProductionYear + player.ShelfLifeYears < yearNow).ToList();

            if (expiredСans.Count == 0)
            {
                Console.WriteLine("Просроченных банок на складе нет");
            }
            else
            {
                ShowList(expiredСans);
            }
        }

        private void ShowList(List<СanOfStew> expiredСans)
        {
            foreach (var criminal in expiredСans)
            {
                criminal.ShowInfo();
            }
        }
    }

    class СanOfStew
    {
        public СanOfStew(string name, int productionYear, int shelfLifeYears)
        {
            Name = name;
            ProductionYear = productionYear;
            ShelfLifeYears = shelfLifeYears;
        }

        public string Name { get; private set; }
        public int ProductionYear { get; private set; }
        public int ShelfLifeYears { get; private set; }

        public void ShowInfo()
        {
            Console.WriteLine($"Название: {Name}, год производства: {ProductionYear}, срок годности: {ShelfLifeYears}");
        }
    }
}