using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace ConsoleApp15
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string Spell1 = "Abrakadabra";
            const string Spell2 = "Bombardo";
            const string Spell3 = "Konfringo";
            const string Spell4 = "Deletrius";

            Random random = new Random();
            int enemyHealth = 400;
            int enemyDamage = 500;
            int enemyDamageMultyply;
            int minEnemyDamageMultyply = 2;
            int maxEnemyDamageMultyply = 3;
            int playerHealth = 300;
            int spell2DamageForEnemy = 100;
            int spell2DamageForPlayer = 20;
            int spell3Healing = 100;
            int spell4Damage = 40;
            int spell4DamageMultyply;
            int spell4DamageMultyplyMin = 3;
            int spell4DamageMultyplyMax = 5;
            string playerInput;
            bool isGameActive = true;

            while (isGameActive)
            {
                Console.Clear();
                Console.WriteLine("Вводи названия заклинания для нанесения урона боссу:\n" + Spell1 + " - меняет здоровье игрока и здоровье босса местами\n" +
                    Spell2 + " - стреляет огненным шаром, который наносит 100 урона боссу, но отнимает 30 здоровья\n" + Spell3 + " - восстанавливает игроку 100 здоровья" +
                    ", босс атакует, а вы нет.\n" + Spell4 + " - нанесение критического урона боссу");
                Console.WriteLine("У вас: " + playerHealth + " здоровья, а у босса: " + enemyHealth + " здоровья");
                playerInput = Console.ReadLine();

                switch (playerInput)
                {
                    case Spell1:
                        (playerHealth, enemyHealth) = (enemyHealth, playerHealth);
                        enemyDamageMultyply = random.Next(minEnemyDamageMultyply, maxEnemyDamageMultyply);
                        playerHealth -= enemyDamage * enemyDamageMultyply;
                        break;
                    case Spell2:
                        enemyDamageMultyply = random.Next(minEnemyDamageMultyply, maxEnemyDamageMultyply);
                        enemyHealth -= spell2DamageForEnemy;
                        playerHealth -= enemyDamage * enemyDamageMultyply;
                        playerHealth -= spell2DamageForPlayer;
                        break;
                    case Spell3:
                        enemyDamageMultyply = random.Next(minEnemyDamageMultyply, maxEnemyDamageMultyply);
                        playerHealth -= enemyDamage * enemyDamageMultyply;
                        playerHealth += spell3Healing;
                        break;
                    case Spell4:
                        enemyDamageMultyply = random.Next(minEnemyDamageMultyply, maxEnemyDamageMultyply);
                        playerHealth -= enemyDamage * enemyDamageMultyply;
                        spell4DamageMultyply = random.Next(spell4DamageMultyplyMin, spell4DamageMultyplyMax);
                        enemyHealth -= spell4Damage * spell4DamageMultyply;
                        break;
                    default:
                        Console.WriteLine("Неизвестное заклинание, попробуй снова, босс тебя атаковал!");
                        enemyDamageMultyply = random.Next(minEnemyDamageMultyply, maxEnemyDamageMultyply);
                        playerHealth -= enemyDamage * enemyDamageMultyply;
                        break;
                }

                if (playerHealth <= 0)
                {
                    Console.Clear();
                    isGameActive = false;
                    Console.WriteLine("Игрок убит боссом");
                }
                else if (enemyHealth <= 0)
                {
                    Console.Clear();
                    isGameActive = false;
                    Console.WriteLine("Босс убит ");
                }
            }
        }
    }
}