using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace two_lists_with_soldiers_linq
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string firstLetter = "Б";
            PlatoonManager platoonManager = new PlatoonManager();
            platoonManager.СhangeThePlatoonOfSoldiers(firstLetter);
        }
    }

    class PlatoonManager
    {
        private List<Soldier> _firstPlatoonOfSoldiers = new List<Soldier>()
        {
            new Soldier("Быков Максим Владимирович"), new Soldier("Сорокин Эмин Львович"), new Soldier("Белов Александр Александрович"), new Soldier("Богданов Всеволод Фёдорович")
        };
        private List<Soldier> _secondPlatoonOfSoldiers = new List<Soldier>()
        {
            new Soldier("Морозов Марк Мирославович"), new Soldier("Романов Рафаэль Арсентьевич"), new Soldier("Иванов Александр Романович")
        };

        public void СhangeThePlatoonOfSoldiers(string firstLetter)
        {
            Console.WriteLine("Первый отряд: ");
            ShowList(_firstPlatoonOfSoldiers);
            Console.WriteLine("\nВторой отряд: ");
            ShowList(_secondPlatoonOfSoldiers);
            Console.WriteLine("\nНажмите любую кнопку для перемещения солдат в другой звод по признаку");
            Console.ReadKey(); 
            _secondPlatoonOfSoldiers = _secondPlatoonOfSoldiers.Union(_firstPlatoonOfSoldiers.Where(soldier => soldier.Name.ToUpper().StartsWith(firstLetter))).ToList();
            _firstPlatoonOfSoldiers = _firstPlatoonOfSoldiers.Except(_secondPlatoonOfSoldiers).ToList();
            Console.WriteLine("\nПервый отряд: ");
            ShowList(_secondPlatoonOfSoldiers);
            Console.WriteLine("\nВторой отряд: ");
            ShowList(_firstPlatoonOfSoldiers);
        }

        private void ShowList(List<Soldier> list)
        {
            foreach (var soldier in list)
            {
                soldier.ShowInfo();
            }
        }
    }

    class Soldier
    {
        public Soldier(string fullName)
        {
            Name = fullName;
        }

        public string Name { get; private set; }

        public void ShowInfo()
        {
            Console.WriteLine($"ФИО - {Name}");
        }
    }
}
