using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp21
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int cursorXPosition = 10;
            int cursorYPosition = 20;
            int healthBarLenght = 10;
            int maxHealth = 10;
            char leftParenthesis = '[';
            char rightParenthesis = ']';
            char emptySymbol = '_';
            char filledSymbol = '#';
            string errorMessage = "Число некорректное";

            Console.Write("Введите количество здоровья - число от 0 до 10: ");
            int health = Convert.ToInt32(Console.ReadLine());
            DrawHealthBar(health, cursorYPosition, cursorXPosition, healthBarLenght, maxHealth, leftParenthesis, rightParenthesis, emptySymbol, filledSymbol, errorMessage);
        }

        static void DrawHealthBar(int health, int cursorYPosition, int cursorXPosition, int healthBarLenght, int maxHealth, char leftParenthesis, char rightParenthesis, char emptySymbol, char filledSymbol, string errorMessage)
        {
            if (health >= 0 && health <= maxHealth)
            {
                Console.SetCursorPosition(cursorYPosition, cursorXPosition);
                string healthBar = "";
                Console.Write(leftParenthesis);

                for (int i = 0; i < health; i++)
                {
                    healthBar += filledSymbol;
                }

                for (int i = 0; i < (healthBarLenght - health); i++)
                {
                    healthBar += emptySymbol;
                }

                Console.Write(healthBar);
                Console.Write(rightParenthesis);
            }
            else
            {
                Console.WriteLine(errorMessage);
            }
        }
    }
}
