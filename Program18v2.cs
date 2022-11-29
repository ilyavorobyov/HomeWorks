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
            const string AbrakadabraSpell = "Abrakadabra";
            const string BombardoSpell = "Bombardo";
            const string KonfringoSpell = "Konfringo";
            const string DeletriusSpell = "Deletrius";

            Random random = new Random();
            int enemyHealth = 400;
            int enemyDamage = 30;
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
                Console.WriteLine("Вводи названия заклинания для нанесения урона боссу:\n" + AbrakadabraSpell + " - меняет здоровье игрока и здоровье босса местами\n" +
                    BombardoSpell + " - стреляет огненным шаром, который наносит 100 урона боссу, но отнимает 30 здоровья\n" + KonfringoSpell + " - восстанавливает игроку 100 здоровья" +
                    ", босс атакует, а вы нет.\n" + DeletriusSpell + " - нанесение критического урона боссу");
                Console.WriteLine("У вас: " + playerHealth + " здоровья, а у босса: " + enemyHealth + " здоровья");
                playerInput = Console.ReadLine();

                switch (playerInput)
                {
                    case AbrakadabraSpell:
                        (playerHealth, enemyHealth) = (enemyHealth, playerHealth);
                        enemyDamageMultyply = random.Next(minEnemyDamageMultyply, maxEnemyDamageMultyply);
                        playerHealth -= enemyDamage * enemyDamageMultyply;
                        break;
                    case BombardoSpell:
                        enemyDamageMultyply = random.Next(minEnemyDamageMultyply, maxEnemyDamageMultyply);
                        enemyHealth -= spell2DamageForEnemy;
                        playerHealth -= enemyDamage * enemyDamageMultyply;
                        playerHealth -= spell2DamageForPlayer;
                        break;
                    case KonfringoSpell:
                        enemyDamageMultyply = random.Next(minEnemyDamageMultyply, maxEnemyDamageMultyply);
                        playerHealth -= enemyDamage * enemyDamageMultyply;
                        playerHealth += spell3Healing;
                        break;
                    case DeletriusSpell:
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

                if (playerHealth <= 0 && enemyHealth <= 0)
                {
                    Console.Clear();
                    isGameActive = false;
                    Console.WriteLine("Ничья! оба погибли");
                }
                else if (enemyHealth <= 0)
                {
                    Console.Clear();
                    isGameActive = false;
                    Console.WriteLine("Босс убит ");
                }
                else if (playerHealth <= 0)
                {
                    Console.Clear();
                    isGameActive = false;
                    Console.WriteLine("Игрок убит ");

                }
            }
        }
    }
}