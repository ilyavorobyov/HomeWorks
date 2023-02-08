using System;

namespace homeWorkGladiators
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BattleField battleField = new BattleField();
            battleField.ChooseFighters();
        }
    }

    class BattleField
    {
        private Fighter[] _fighters = { new WhiteMage("White Mage", 100, 5, 15, 7), new FireArcher("Fire Archer", 90,5,10,3),
                               new StoneGiant("Stone Giant", 110, 12, 5, 3), new Swordsman("Swordsman",100,5,10,2,2), new DarkWizard("Dark Wizard", 100,5,8,5,1)};
        private Fighter _firstFighter;
        private Fighter _secondFighter;

        public void ChooseFighters()
        {
            int fighterNumber;
            int reducedNumber = 1;

            ShowAllFighters();

            Console.Write("Введи номер первого бойца ");

            if (int.TryParse(Console.ReadLine(), out fighterNumber))
            {
                _firstFighter = _fighters[fighterNumber - reducedNumber];
                Console.WriteLine("Боец выбран");
            }
            else
            {
                Console.WriteLine("Данные введены неверно, попробуй ещё раз");
            }

            Console.Write("Введи номер второго бойца ");

            if (int.TryParse(Console.ReadLine(), out fighterNumber))
            {
                _secondFighter = _fighters[fighterNumber - reducedNumber];
                Console.WriteLine("Боец выбран");
                ShowChoosingfighters();
            }
            else
            {
                Console.WriteLine("Данные введены неверно, попробуй ещё раз");
            }
        }

        private void ShowChoosingfighters()
        {
            Console.Clear();
            Console.WriteLine("Были выбраны бойцы: ");
            _firstFighter.ShowInfo();
            _secondFighter.ShowInfo();
            Fight();
        }

        private void ShowAllFighters()
        {
            for (int i = 0; i < _fighters.Length; i++)
            {
                Console.Write(i + 1 + " ");
                _fighters[i].ShowInfo();
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
                _firstFighter.TakeDamage(_secondFighter.Damage);
                _secondFighter.TakeDamage(_firstFighter.Damage);
                _firstFighter.CalculationChanceSpecialAbility();
                _secondFighter.CalculationChanceSpecialAbility();
            }

            ShowBattleResult();
        }

        private void ShowBattleResult()
        {
            if (_firstFighter.Health <= 0)
                Console.WriteLine($"Победил боец - {_secondFighter.Name}");
            else
                Console.WriteLine($"Победил боец - {_firstFighter.Name}");
        }
    }

    class Fighter
    {
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

        public void TakeDamage(int damage)
        {
            Health -= damage - Armor;
        }

        public void CalculationChanceSpecialAbility()
        {
            Random random = new Random();
            int maxNumber = 4;
            int abilitychance = 1;
            int numberToChanceCalculation = random.Next(maxNumber);

            if (numberToChanceCalculation == abilitychance)
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
    }
}