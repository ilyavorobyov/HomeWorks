using System;
using System.Collections.Generic;
using System.Linq;

namespace soldiersLinq
{
    internal class Program
    {
        static void Main(string[] args)
        {
            InformationManager informationManager = new InformationManager();
            informationManager.GetNamesAndTitles();
        }
    }

    class InformationManager
    {
        private List<Soldier> _soldiers = new List<Soldier>
        {
            new Soldier("Макаров Матвей Николаевич", "Автомат", "Сержант", 60), new Soldier("Волков Михаил Артёмович", "Автомат", "Рядовой", 12),new Soldier("Касаткин Кирилл Александрович", "Пулемёт Калашникова", "Сержант", 40),
            new Soldier("Волков Артём Эмирович", "Автомат", "Лейтенант", 70), new Soldier("Иванов Даниил Матвеевич", "Гранатомет", "мл. Лейтенант", 55),new Soldier("Алексеев Фёдор Адамович", "Пулемёт Калашникова", "мл. Сержант", 21),
            new Soldier("Новиков Роман Антонович", "АСВК", "Старшина", 33), new Soldier("Галкин Владислав Кириллович", "Снайперская винтовка Драгунова", "Майор", 77),new Soldier("Борисов Иван Игоревич", "АСВК", "Капитан", 70),
        };

        public void GetNamesAndTitles()
        {
            var newSoldiersList = _soldiers.Select(soldier => new { soldier.Name, soldier.Rank }).ToList();

            foreach (var soldier in newSoldiersList)
            {
                Console.WriteLine($"ФИО: {soldier.Name}, звание: {soldier.Rank}");
            }
        }
    }

    class Soldier
    {
        public Soldier(string fullName, string armament, string rank, int termOfServiceInMonths)
        {
            Name = fullName;
            Armanent = armament;
            Rank = rank;
            TermOfServiceInMonths = termOfServiceInMonths;
        }

        public string Name { get; private set; }
        public string Armanent { get; private set; }
        public string Rank { get; private set; }
        public int TermOfServiceInMonths { get; private set; }
    }
}