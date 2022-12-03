using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp17
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string AbrakadabraSpell = "Abrakadabra";
            const string BombardoSpell = "Bombardo";
            const string KonfringoSpell = "Konfringo";
            const string DeletriusSpell = "Deletrius";
            const string PetrifikusSpell = "Petrifikus";

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
            int spell5Healing = 30;
            int spell5Damage = 20;
            int spell5DamageMultyply;
            int spell5DamageMultyplyMin = 1;
            int spell5DamageMultyplyMax = 3;

            bool isPlayerWinner = false;
            bool isBossWinner = false;
            bool isNobodyWinner = false;

            string playerInput;
            bool isGameActive = true;
            bool isPetrifikusAvailable = false;

            while (isGameActive)
            {
                Console.Clear();
                Console.WriteLine("Вводи названия заклинания для нанесения урона боссу:\n" + AbrakadabraSpell + " - меняет здоровье игрока и здоровье босса местами\n" +
                    BombardoSpell + " - стреляет огненным шаром, который наносит " + spell2DamageForEnemy + " урона боссу, но отнимает " + enemyDamage + " здоровья\n" + KonfringoSpell + " - восстанавливает игроку" + spell3Healing + " здоровья" +
                    ", босс атакует, а вы нет.\n" + DeletriusSpell + " - нанесение критического урона боссу\n" + PetrifikusSpell + " - нанесение небольшого урона боссу, босс не атакует, игрок немонго вылечивается, работает только после " + DeletriusSpell);
                Console.WriteLine("У вас: " + playerHealth + " здоровья, а у босса: " + enemyHealth + " здоровья");
                playerInput = Console.ReadLine();

                switch (playerInput)
                {
                    case AbrakadabraSpell:
                        (playerHealth, enemyHealth) = (enemyHealth, playerHealth);
                        enemyDamageMultyply = random.Next(minEnemyDamageMultyply, maxEnemyDamageMultyply);
                        playerHealth -= enemyDamage * enemyDamageMultyply;
                        isPetrifikusAvailable = false;
                        break;

                    case BombardoSpell:
                        enemyDamageMultyply = random.Next(minEnemyDamageMultyply, maxEnemyDamageMultyply);
                        enemyHealth -= spell2DamageForEnemy;
                        playerHealth -= enemyDamage;
                        playerHealth -= spell2DamageForPlayer;
                        isPetrifikusAvailable = false;
                        break;

                    case KonfringoSpell:
                        enemyDamageMultyply = random.Next(minEnemyDamageMultyply, maxEnemyDamageMultyply);
                        playerHealth -= enemyDamage * enemyDamageMultyply;
                        playerHealth += spell3Healing;
                        isPetrifikusAvailable = false;
                        break;

                    case DeletriusSpell:
                        enemyDamageMultyply = random.Next(minEnemyDamageMultyply, maxEnemyDamageMultyply);
                        playerHealth -= enemyDamage * enemyDamageMultyply;
                        spell4DamageMultyply = random.Next(spell4DamageMultyplyMin, spell4DamageMultyplyMax);
                        enemyHealth -= spell4Damage * spell4DamageMultyply;
                        isPetrifikusAvailable = true;
                        break;

                    case PetrifikusSpell:

                        if (isPetrifikusAvailable)
                        {
                            spell5DamageMultyply = random.Next(spell5DamageMultyplyMin, spell5DamageMultyplyMax);
                            enemyHealth -= spell5Damage * spell5DamageMultyply;
                            playerHealth += spell5Healing;
                            isPetrifikusAvailable = false;
                        }
                        else
                        {
                            Console.WriteLine("Заклинание недоступно! Сначала нужно применить заклинание " + DeletriusSpell + "\nВы получаете урон");
                            enemyDamageMultyply = random.Next(minEnemyDamageMultyply, maxEnemyDamageMultyply);
                            playerHealth -= enemyDamage * enemyDamageMultyply;
                            Console.ReadKey();
                        }
                        break;

                    default:
                        Console.WriteLine("Неизвестное заклинание, попробуй снова, босс тебя атаковал!");
                        enemyDamageMultyply = random.Next(minEnemyDamageMultyply, maxEnemyDamageMultyply);
                        playerHealth -= enemyDamage * enemyDamageMultyply;
                        break;
                }

                if (playerHealth <= 0 && enemyHealth <= 0)
                {
                    isNobodyWinner = true;
                    isGameActive = false;
                    Console.Clear();
                    break;
                }
                else if (enemyHealth <= 0)
                {
                    isPlayerWinner = true;
                    isGameActive = false;
                    Console.Clear();
                    break;
                }
                else if (playerHealth <= 0)
                {
                    isBossWinner = true;
                    isGameActive = false;
                    Console.Clear();
                    break;
                }
            }

            if (isNobodyWinner)
            {
                Console.WriteLine("Ничья! оба погибли");
                Console.ReadKey();
            }
            else if(isPlayerWinner)
            {
                Console.WriteLine("Босс убит ");
                Console.ReadKey();
            }
            else if(isBossWinner)
            {
                Console.WriteLine("Игрок убит ");
                Console.ReadKey();
            }
        }
    }
}