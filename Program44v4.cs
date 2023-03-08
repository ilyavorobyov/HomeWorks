using System;
using System.Collections.Generic;
using System.Threading;

namespace homeWorkGladiators
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BattleField battleField = new BattleField();
        }
    }

    class BattleField
    {
        private List<Fighter> _fighters = new List<Fighter>();
        private Fighter _firstFighter;
        private Fighter _secondFighter;

        public BattleField()
        {
            _fighters.Add(new WhiteMage("White Mage", 100, 5, 15, 4));
            _fighters.Add(new FireArcher("Fire Archer", 90, 5, 10, 1));
            _fighters.Add(new StoneGiant("Stone Giant", 120, 12, 5, 3));
            _fighters.Add(new Swordsman("Swordsman", 100, 5, 10, 2, 2));
            _fighters.Add(new DarkWizard("Dark Wizard", 100, 5, 8, 5, 1));
            ShowAllFighters();
            _firstFighter = ChooseFighter();
            _secondFighter = ChooseFighter();
            ShowChoosingFighters();
            Fight();
        }

        private Fighter ChooseFighter()
        {
            bool isNotChosen = true;
            int inputNumber = 0;

            while (isNotChosen)
            {
                Console.Write("Введите номер бойца: ");
                bool isNumber = int.TryParse(Console.ReadLine(), out inputNumber);

                if (isNumber == false)
                {
                    Console.WriteLine("Данные введены неверно, попробуй ещё раз");
                }
                else if (inputNumber > 0 && inputNumber - 1 < _fighters.Count)
                {
                    Console.WriteLine("Боец выбран");
                    isNotChosen = false;
                }
                else
                {
                    Console.WriteLine("Бойца с таким номером нет!");
                }
            }

            return _fighters[inputNumber - 1]; ;
        }

        private void ShowChoosingFighters()
        {
            Console.Clear();
            Console.WriteLine("Были выбраны бойцы: ");
            _firstFighter.ShowInfo();
            _secondFighter.ShowInfo();
        }

        private void ShowAllFighters()
        {
            int fighterNumber = 1;

            foreach (Fighter fighter in _fighters)
            {
                Console.Write(fighterNumber + " ");
                fighter.ShowInfo();
                fighterNumber++;
            }
        }

        private void Fight()
        {
            Console.WriteLine("Для начала боя нажмите любую кнопку...");
            Console.ReadKey();

            while (_firstFighter.Health > 0 && _secondFighter.Health > 0)
            {
                _firstFighter.ShowCurrentHealth();
                _secondFighter.ShowCurrentHealth();
                _firstFighter.Attack(_secondFighter);
                _secondFighter.Attack(_firstFighter);
            }

            ShowBattleResult();
        }

        private void ShowBattleResult()
        {
            if (_firstFighter.Health <= 0 && _secondFighter.Health <= 0)
            {
                Console.WriteLine("Ничья, погибли оба");
            }
            else if (_firstFighter.Health <= 0)
            {
                Console.WriteLine($"Победил боец - {_secondFighter.Name}");
            }
            else if (_secondFighter.Health <= 0)
            {
                Console.WriteLine($"Победил боец - {_firstFighter.Name}");
            }
        }
    }

    class Fighter
    {
        protected int AttacksCounter = 0;
        protected static Random Random = new Random();

        public Fighter(string name, int health, int damage, int armor)
        {
            Name = name;
            Health = health;
            Damage = damage;
            Armor = armor;
        }

        public string Name { get; protected set; }
        public int Health { get; protected set; }
        public int Damage { get; protected set; }
        public int Armor { get; protected set; }

        public void ShowInfo()
        {
            Console.WriteLine($"Боец: {Name}, здоровье: {Health}, наносимый урон: {Damage}, броня: {Armor}");
        }

        public void ShowCurrentHealth()
        {
            Console.WriteLine($"{Name}, здоровье: {Health}");
        }

        public virtual void TakeDamage(int damage)
        {
            int minDamage = 1;

            if (damage > Armor)
            {
                Health -= (damage - Armor);
            }
            else
            {
                Health -= minDamage;
                Console.WriteLine("Большая часть урона заблокирована броней");
            }
        }

        public virtual void Attack(Fighter fighter)
        {
            fighter.TakeDamage(Damage);
        }
    }

    class WhiteMage : Fighter
    {
        private int _addHealth;

        public WhiteMage(string name, int health, int armor, int damage, int additionalHealth) : base(name, health, armor, damage)
        {
            _addHealth = additionalHealth;
        }

        private void UseSpecialAbility()
        {
            Console.WriteLine($"{Name} - использовал способность - лечение");
            Health += _addHealth;
        }

        public override void Attack(Fighter fighter)
        {
            int addHealth = 1;
            int maxNumber = 101;
            int specialAttackChance = 20;
            int specialAbilityChance = 15;
            int numberToCalculateChance = Random.Next(maxNumber);

            if (numberToCalculateChance <= specialAbilityChance)
            {
                UseSpecialAbility();
            }
            else if (numberToCalculateChance <= specialAttackChance)
            {
                Health += addHealth;
                Console.WriteLine($"У {Name} сработал эффект магического вампиризма от атаки");
            }

            base.Attack(fighter);
        }
    }

    class FireArcher : Fighter
    {
        private int _additionalDamage;

        public FireArcher(string name, int health, int damage, int armor, int additionalDamage) : base(name, health, armor, damage)
        {
            _additionalDamage = additionalDamage;
        }

        private void UseSpecialAbility()
        {
            Damage += _additionalDamage;
            Console.WriteLine($"{Name} - использовал способность - повышение урона, теперь урон бойца {Damage}");
        }

        public override void Attack(Fighter fighter)
        {
            int specialAttackNumber = 7;
            AttacksCounter++;

            if (AttacksCounter == specialAttackNumber)
            {
                int damageMultiplier = 2;
                AttacksCounter = 0;
                Console.WriteLine($"{Name} выстрелил огненной стрелой");
                int newDamage = Damage * damageMultiplier;
                UseSpecialAbility();
                fighter.TakeDamage(newDamage);
            }
            else
            {
                base.Attack(fighter);
            }
        }
    }

    class StoneGiant : Fighter
    {
        private int _additionalArmor;

        public StoneGiant(string name, int health, int armor, int damage, int additionalArmor) : base(name, health, armor, damage)
        {
            _additionalArmor = additionalArmor;
        }

        private void UseSpecialAbility()
        {
            Armor += _additionalArmor;
            Console.WriteLine($"{Name} - использовал способность - повышение брони, теперь броня {Armor}");
        }

        public override void Attack(Fighter fighter)
        {
            AttacksCounter++;
            int specialAttackNumber = 5;

            if (AttacksCounter == specialAttackNumber)
            {
                int additionalDamage = 5;
                AttacksCounter = 0;
                Console.WriteLine($"{Name} вызвал камнепад");
                int newDamage = Damage + additionalDamage;
                UseSpecialAbility();
                fighter.TakeDamage(newDamage);
            }
            else
            {
                base.Attack(fighter);
            }
        }
    }

    class Swordsman : Fighter
    {
        private int _additionalDamage;
        private int _additionalArmor;

        public Swordsman(string name, int health, int armor, int damage, int additionalArmor, int additionalDamage) : base(name, health, armor, damage)
        {
            _additionalArmor = additionalArmor;
            _additionalDamage = additionalDamage;
        }

        private void UseSpecialAbility()
        {
            Armor += _additionalArmor;
            Damage += _additionalDamage;
            Console.WriteLine($"{Name} - использовал способность - повышение брони и урона");
        }

        public override void Attack(Fighter fighter)
        {
            int extraArmor = 1;
            AttacksCounter++;
            int specialAttackNumber = 5;

            if (AttacksCounter == specialAttackNumber)
            {
                AttacksCounter = 0;
                Console.WriteLine($"{Name} использовал свой щит, броня увеличена");
                Armor += extraArmor;
                UseSpecialAbility();
            }

            base.Attack(fighter);
        }
    }

    class DarkWizard : Fighter
    {
        private int _additionalHealth;
        private int _armorReduction;

        public DarkWizard(string name, int health, int armor, int damage, int additionalHealth, int armorReduction) : base(name, health, armor, damage)
        {
            _additionalHealth = additionalHealth;
            _armorReduction = armorReduction;
        }

        private void UseSpecialAbility()
        {
            Console.WriteLine($"{Name} - Использовал способность - лечение с небольшим уменьшением брони");

            if (Armor <= 0)
            {
                Armor = 0;
            }
            else
            {
                Armor += _armorReduction;
            }

            Health += _additionalHealth;
        }

        public override void Attack(Fighter fighter)
        {
            int extraDamage = 1;
            int maxNumber = 101;
            int abilityChance = 15;
            int numberToChanceCalculation = Random.Next(maxNumber);

            if (numberToChanceCalculation <= abilityChance)
            {
                Damage += extraDamage;
                Console.WriteLine($"{Name} применил древнюю магию и увеличил свой урон");
                UseSpecialAbility();
            }

            base.Attack(fighter);
        }
    }
}