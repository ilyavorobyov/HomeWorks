using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp42
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Player player = new Player(-100, 40, 300);
            player.ShowInfo();
        }
    }

    class Player
    {
        private int _health;
        private int _moveSpeed;
        private int _damage;

        public Player(int health, int moveSpeed, int damage)
        {
            if (health <= 0)
            {
                _health = 100;
            }
            else
            {
                _health = health;
            }

            _moveSpeed = moveSpeed;
            _damage = damage;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"У игрока {_health} здоровья, скорость его передвижения {_moveSpeed}, его урон {_damage}");
        }
    }
}