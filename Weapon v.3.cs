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
        private Player _player = new Player(50);
        private Weapon _weapon = new Weapon(10, 30);

        public void StartShooting()
        {
            Bot bot = new Bot(_weapon);
            string clueText = "Нажимай Enter, чтобы стрелять в игрока";
            string gameOverText = "Игра окончена";
            bool isPlayerAlive = _player.IsAlive;
            bool isCanShoot = _weapon.CheckShootOpportunity;

            while (isPlayerAlive && isCanShoot)
            {
                Console.Clear();
                Console.WriteLine(clueText);
                Console.ReadLine();
                bot.OnSeePlayer(_player);
                isPlayerAlive = _player.IsAlive;
                isCanShoot = _weapon.CheckShootOpportunity;
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
                if (bullets <= 0 || damage <= 0)
                    throw new ArgumentOutOfRangeException();

                _damage = damage;
                _bullets = bullets;
            }

            public bool CheckShootOpportunity => _damage > 0 && _bullets > 0;

            public void Fire(Player player)
            {
                if(player == null)
                    throw new ArgumentNullException();

                Console.WriteLine(beforeShotText + _bullets);

                if (CheckShootOpportunity)
                {
                    player.TakeDamage(_damage);
                    _bullets--;
                    Console.WriteLine(afterShotText + _bullets);
                }
                else
                {
                    throw new InvalidOperationException();
                }
            }
        }

        class Player
        {
            private int _health;

            public Player(int health)
            {
                _health = health;

                if (_health > 0)
                    _health = health;
                else
                    throw new ArgumentOutOfRangeException();
            }

            public bool IsAlive => _health > 0; 

            public void TakeDamage(int damage)
            {
                if(damage < 0 )
                    throw new ArgumentOutOfRangeException();

                if (IsAlive)
                {
                    _health -= damage;

                    if (_health <= 0)
                        Die();
                }

                Console.WriteLine("ХП игрока " + _health);
            }

            private void Die()
            {
                Console.WriteLine("Игрок погиб");
            }
        }

        class Bot
        {
            private Weapon _weapon;

            public Bot(Weapon weapon)
            {
                if (weapon == null)
                    throw new ArgumentNullException();

                _weapon = weapon;
            }

            public void OnSeePlayer(Player player)
            {
                if (player == null)
                    throw new ArgumentNullException();

                _weapon.Fire(player);
            }
        }
    }
}