using System;

namespace HomeWorkWeapon
{
    internal class Porgramm
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            game.StartShooting();
        }
    }

    class Game
    {
        private Player _player = new Player(20);
        private Weapon _weapon = new Weapon(10, 10);

        public void StartShooting()
        {
            Bot bot = new Bot(_weapon);
            string clueText = "Нажимай Enter, чтобы стрелять в игрока";
            string gameOverText = "Игра окончена";
            bool isPlayerAlive = _player.IsAlive;
            bool isCanShoot = _weapon.CheckShootOpportunity();

            while (isPlayerAlive && isCanShoot)
            {
                Console.Clear();
                Console.WriteLine(clueText);
                Console.ReadLine();
                bot.OnSeePlayer(_player);
                isPlayerAlive = _player.IsAlive;
                isCanShoot = _weapon.CheckShootOpportunity();
                Console.ReadLine();
            }

            Console.WriteLine(gameOverText);
        }

        class Weapon
        {
            private int _damage;
            private int _bullets;
            private string beforeShotText = "Пуль до выстрела: ";
            private string afterShotText = "Пуль после выстрела: ";

            public Weapon(int damage, int bullets)
            {
                _damage = damage;
                _bullets = bullets;

               if (!CheckShootOpportunity())
                {
                    Console.WriteLine("введите правильные данные");
                }
            }

            public void Fire(Player player)
            {
                Console.WriteLine(beforeShotText + _bullets);

                if (CheckShootOpportunity())
                {
                    player.TakeDamage(_damage);
                    _bullets--;
                    Console.WriteLine(afterShotText + _bullets);
                }
                else
                {
                    Console.WriteLine("Пули кончились");
                    Console.ReadLine();
                }
            }

            public bool CheckShootOpportunity()
            {
                return _damage > 0 && _bullets > 0;
            }
        }

        class Player
        {
            private int _health;

            public bool IsAlive { get; private set; }

            public Player(int health)
            {
                _health = health;

                if (_health > 0)
                {
                    _health = health;
                    IsAlive = true;
                }
                else
                {
                    Console.WriteLine("Укажите правильно число ХП");
                    Console.ReadLine();
                    IsAlive = false;
                }
            }

            public void TakeDamage(int damage)
            {
                if (IsAlive)
                {
                    _health -= damage;

                    if (_health <= 0)
                        Die();
                }

                Console.WriteLine("ХП игрока" + _health);
            }

            private void Die()
            {
                Console.WriteLine("Игрок погиб");
                IsAlive = false;
            }
        }

        class Bot
        {
            private Weapon _weapon;

            public Bot(Weapon weapon)
            {
                _weapon = weapon;
            }

            public void OnSeePlayer(Player player)
            {
                _weapon.Fire(player);
            }
        }
    }
}