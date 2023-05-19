using System;
using System.Collections.Generic;

namespace war
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BattleField battleField = new BattleField();
            battleField.Initiate();
        }
    }

    class BattleField
    {
        private Platoon _redCountryPlatoon = new Platoon(10);
        private Platoon _blueCountryPlatoon = new Platoon(10);
        private Soldier _redSoldier;
        private Soldier _blueSoldier;

        public void Initiate()
        {
            Console.WriteLine("Бой взводов двух стран. Нажмите любую кнопку чтобы начать!");
            Console.ReadKey();
            Battle();
            ShowResult();
        }

        private void Battle()
        {
            while (_redCountryPlatoon.GetCountOfSoldiers() > 0 && _blueCountryPlatoon.GetCountOfSoldiers() > 0)
            {
                _redSoldier = _redCountryPlatoon.GetSoldierToBattle();
                _blueSoldier = _blueCountryPlatoon.GetSoldierToBattle();
                Console.WriteLine("\nПервый взвод:");
                _redCountryPlatoon.ShowInfo();
                Console.WriteLine("\nВторой взвод:");
                _blueCountryPlatoon.ShowInfo();
                _redSoldier.Attack(_blueSoldier);
                _blueCountryPlatoon.RemoveDeadSoldier(_blueSoldier);
                _blueSoldier.Attack(_redSoldier);
                _redCountryPlatoon.RemoveDeadSoldier(_redSoldier);
                Console.ReadKey();
                Console.Clear();
            }
        }

        private void ShowResult()
        {
            if (_redCountryPlatoon.GetCountOfSoldiers() == 0 && _blueCountryPlatoon.GetCountOfSoldiers() == 0)
            {
                Console.WriteLine("Ничья все погибли");
            }
            else if (_redCountryPlatoon.GetCountOfSoldiers() == 0)
            {
                Console.WriteLine("Победил взвод второй страны");
            }
            else if (_blueCountryPlatoon.GetCountOfSoldiers() == 0)
            {
                Console.WriteLine("Победил взвод первой страны");
            }
        }
    }

    class Platoon
    {
        private static Random _random = new Random();
        private List<Soldier> _soldiers = new List<Soldier>();

        public Platoon(int numberOfSoldiers)
        {
            Fill(numberOfSoldiers);
        }

        public void RemoveDeadSoldier(Soldier soldier)
        {
            if (soldier.Health <= 0)
            {
                _soldiers.Remove(soldier);
            }
        }

        public void ShowInfo()
        {
            foreach (Soldier soldier in _soldiers)
            {
                soldier.ShowStats();
            }
        }

        public int GetCountOfSoldiers()
        {
            return _soldiers.Count;
        }

        public Soldier GetSoldierToBattle()
        {
            return _soldiers[_random.Next(0, _soldiers.Count)];
        }

        private void Fill(int numberOfSoldiers)
        {
            List<Soldier> soldiers;

            for (int i = 0; i < numberOfSoldiers; i++)
            {
                soldiers = new List<Soldier>() { new Sniper("Снайпер", 100, 60, 10), new Infantry("Пехота", 150, 40, 15), new HeavyInfantry("Тяжелая пехота", 200, 50, 20) };
                _soldiers.Add(CreateSoldier(soldiers));
            }
        }

        private Soldier CreateSoldier(List<Soldier> soldiers)
        {
            int minNumber = 0;
            int maxNumber = 3;
            int randomClass = _random.Next(minNumber, maxNumber);
            return soldiers[randomClass];
        }
    }

    class Soldier
    {
        private static Random _random = new Random();

        public Soldier(string name, int health, int damage, int armor)
        {
            Name = name;
            Health = health;
            Damage = damage;
            Armor = armor;
        }

        public string Name { get; private set; }
        public int Health { get; protected set; }
        public int Damage { get; protected set; }
        public int Armor { get; protected set; }

        public void TakeDamage(int damage)
        {
            if (Armor >= damage)
            {
                damage = 1;
                Health -= damage;
            }
            else
            {
                Health -= damage - Armor;
            }

            Console.WriteLine($"\n{Name} получил {damage} урона.");
        }

        public void Attack(Soldier enemySoldier)
        {
            if (TryUseSpecialAbility())
            {
                UseSpecialAbility();
            }

            enemySoldier.TakeDamage(Damage);
        }

        public void ShowStats()
        {
            Console.WriteLine($"{Name} - {Health} здоровья, {Damage} урона, {Armor} брони.");
        }

        private bool TryUseSpecialAbility()
        {
            int number = 1;
            int maximumNumber = 5;
            int minimumNumber = 1;
            int randomNumber = _random.Next(minimumNumber, maximumNumber);

            if (randomNumber == number)
            {
                return true;
            }

            return false;
        }

        protected virtual void UseSpecialAbility() { }
    }

    class Sniper : Soldier
    {
        public Sniper(string name, int health, int damage, int armor) : base(name, health, damage, armor) { }

        protected override void UseSpecialAbility()
        {
            int extraDamage = 50;
            Console.WriteLine($"\n{Name} начал стрелять более метко и увеличил урон");
            Damage += extraDamage;
        }
    }

    class Infantry : Soldier
    {
        public Infantry(string name, int health, int damage, int armor) : base(name, health, damage, armor) { }

        protected override void UseSpecialAbility()
        {
            int extraDamage = 15;
            int additionalArmor = 15;
            Console.WriteLine($"\n{Name} увеличил боевой дух и увеличил броню и урон");
            Damage += extraDamage;
            Armor += additionalArmor;
        }
    }

    class HeavyInfantry : Soldier
    {
        public HeavyInfantry(string name, int health, int damage, int armor) : base(name, health, damage, armor) { }

        protected override void UseSpecialAbility()
        {
            int extraDamage = 25;
            Console.WriteLine($"\n{Name} применяет гранатомет, урон увеличен");
            Damage += extraDamage;
        }
    }
}