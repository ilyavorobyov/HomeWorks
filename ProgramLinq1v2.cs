using System;
using System.Collections.Generic;
using System.Linq;

namespace amnesty
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string amnesticCrime = "Антиправительственное";
            Prison prison = new Prison();
            prison.StartAmnesty(amnesticCrime);
        }
    }

    class Prison
    {
        private List<Human> _listOfPrisoners = new List<Human>
        { new Human("Симон Венс", "Убийство"), new Human("Винс Лестрад", "Вооруженное ограбление"),
          new Human("Шае Пьерсовска", "Антиправительственное"), new Human("Джордж Костава","Подделка документов"),
          new Human("Мессоф Онегов","Антиправительственное"), new Human("Элиза Катсенжа","Кража"), new Human("Кордон Калло","Антиправительственное")
        };

        public void StartAmnesty(string amnesticCrime)
        {
            Console.WriteLine($"Внимание! Объявлется амнисития за {amnesticCrime} преступление! Список заключенных до амнистии:\n");

            foreach (Human human in _listOfPrisoners)
            {
                human.ShowInfo();
            }

            Console.WriteLine("\nЧтобы начать амнистию нажмите кнопку, будет выведен список заключенных после амнистии:\n");
            Console.ReadKey();

            _listOfPrisoners = _listOfPrisoners.Where(human => human.Crime != amnesticCrime).ToList();

            foreach (var human in _listOfPrisoners)
            {
                human.ShowInfo();
            }
        }
    }

    class Human
    {
        public Human(string fullname, string crime)
        {
            FullName = fullname;
            Crime = crime;
        }

        public string FullName { get; private set; }
        public string Crime { get; private set; }

        public void ShowInfo()
        {
            Console.WriteLine($"ФИО: {FullName}, преступление: {Crime}");
        }
    }
}