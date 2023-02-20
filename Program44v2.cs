using System;
using System.Collections.Generic;

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
            _fighters.Add(new WhiteMage("White Mage", 100, 5, 15, 7));
            _fighters.Add(new FireArcher("Fire Archer", 90, 5, 10, 3));
            _fighters.Add(new StoneGiant("Stone Giant", 110, 12, 5, 3));
            _fighters.Add(new Swordsman("Swordsman", 100, 5, 10, 2, 2));
            _fighters.Add(new DarkWizard("Dark Wizard", 100, 5, 8, 5, 1));
            ShowAllFighters();
            ChooseFighter(out _firstFighter);
            ChooseFighter(out _secondFighter);
            ShowChoosingfighters();
            Fight();
        }

        private void ChooseFighter(out Fighter fighter)
        {
            bool isNotChosen = true;
            int fighterIndex = 0;

            while (isNotChosen)
            {
                Console.Write("Введите номер бойца: ");
                bool isNumber = int.TryParse(Console.ReadLine(), out fighterIndex);

                if (isNumber == false)
                {
                    Console.WriteLine("Данные введены неверно, попробуй ещё раз");
                }
                else if (fighterIndex > 0 && fighterIndex - 1 < _fighters.Count)
                {
                    Console.WriteLine("Боец выбран");
                    isNotChosen = false;
                }
                else
                {
                    Console.WriteLine("Бойца с таким номером нет!");
                }
            }

            fighter = _fighters[fighterIndex - 1];
        }

        private void ShowChoosingfighters()
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
                _firstFighter.CalculationChanceSpecialAbility();
                _secondFighter.CalculationChanceSpecialAbility();
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
                Console.WriteLine($"Победил боец - {_firstFighter.Name}");
        }
    }

    class Fighter
    {
        protected int _attacksCounter = 0;
        protected static Random _random = new Random();

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
            int minDamage = 2;

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

        public void CalculationChanceSpecialAbility()
        {
            int maxNumber = 101;
            int abilityChance = 20;
            int numberToChanceCalculation = _random.Next(maxNumber);

            if (numberToChanceCalculation <= abilityChance)
            {
                UseSpecialAbility();
            }
        }

        public virtual void UseSpecialAbility() { }
    }

    class WhiteMage : Fighter
    {
        private int _addHealth;

        public WhiteMage(string name, int health, int armor, int damage, int additionalHealth) : base(name, health, armor, damage)
        {
            _addHealth = additionalHealth;
        }

        public override void UseSpecialAbility()
        {
            Console.WriteLine($"{Name} - использовал способность - лечение");
            Health += _addHealth;
        }

        public override void Attack(Fighter fighter)
        {
            int addHealth = 1;
            int maxNumber = 101;
            int abilityChance = 20;
            int numberToChanceCalculation = _random.Next(maxNumber);

            if (numberToChanceCalculation <= abilityChance)
            {
                Health += addHealth;
                Console.WriteLine($"У {Name} сработал эффект магического вампиризма от атаки");
                base.Attack(fighter);
            }
            else
            {
                base.Attack(fighter);
            }
        }
    }

    class FireArcher : Fighter
    {
        private int _additionalDamage;

        public FireArcher(string name, int health, int damage, int armor, int additionalDamage) : base(name, health, armor, damage)
        {
            _additionalDamage = additionalDamage;
        }

        public override void UseSpecialAbility()
        {
            Damage += _additionalDamage;
            Console.WriteLine($"{Name} - использовал способность - повышение урона, теперь урон бойца {Damage}");
        }

        public override void Attack(Fighter fighter)
        {
            int newDamage = Damage;
            _attacksCounter++;
            int specialAttackNumber = 5;

            if (_attacksCounter == specialAttackNumber)
            {
                _attacksCounter = 0;
                Console.WriteLine($"{Name} выстрелил огненной стрелой");
                Damage += Damage;
                base.Attack(fighter);
                Damage = newDamage;
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

        public override void UseSpecialAbility()
        {
            Armor += _additionalArmor;
            Console.WriteLine($"{Name} - использовал способность - повышение брони, теперь броня {Armor}");
        }

        public override void Attack(Fighter fighter)
        {
            int standardDamage = Damage;
            _attacksCounter++;
            int specialAttackNumber = 4;

            if (_attacksCounter == specialAttackNumber)
            {
                _attacksCounter = 0;
                Console.WriteLine($"{Name} вызвал камнепад");
                Damage += Damage;
                base.Attack(fighter);
                Damage = standardDamage;
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

        public override void UseSpecialAbility()
        {
            Armor += _additionalArmor;
            Damage += _additionalDamage;
            Console.WriteLine($"{Name} - использовал способность - повышение брони и урона");
        }

        public override void Attack(Fighter fighter)
        {
            int extraArmor = 2;
            _attacksCounter++;
            int specialAttackNumber = 5;

            if (_attacksCounter == specialAttackNumber)
            {
                _attacksCounter = 0;
                Console.WriteLine($"{Name} использовал свой щит, броня увеличена");
                Armor += extraArmor;
                base.Attack(fighter);
            }
            else
            {
                base.Attack(fighter);
            }
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

        public override void UseSpecialAbility()
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
            int numberToChanceCalculation = _random.Next(maxNumber);

            if (numberToChanceCalculation <= abilityChance)
            {
                Damage += extraDamage;
                Console.WriteLine($"{Name} применил древнюю магию и увеличил свой урон");
                base.Attack(fighter);
            }
            else
            {
                base.Attack(fighter);
            }
        }
    }
}