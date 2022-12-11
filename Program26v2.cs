using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp22
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int cursorXPosition = 10;
            int cursorYPosition = 20;
            int healthBarLenght = 10;
            int minValue = 0;
            int maxValue = 10;
            char leftParenthesis = '[';
            char rightParenthesis = ']';
            char emptySymbol = '_';
            char filledSymbol = '#';
            string errorMessage = "Число некорректное";

            Console.Write($"Введите количество здоровья - число от {minValue} до {maxValue}: ");
            int inputValue = Convert.ToInt32(Console.ReadLine());
            DrawBar(inputValue, cursorYPosition, cursorXPosition, healthBarLenght, maxValue, leftParenthesis, rightParenthesis, emptySymbol, filledSymbol, errorMessage, minValue);
        }

        static void DrawBar(int inputValue, int cursorYPosition, int cursorXPosition, int healthBarLenght, int maxValue, char leftParenthesis, char rightParenthesis, char emptySymbol, char filledSymbol, string errorMessage, int minValue)
        {
            if (inputValue >= minValue && inputValue <= maxValue)
            {
                Console.SetCursorPosition(cursorYPosition, cursorXPosition);
                string healthBar = "";
                Console.Write(leftParenthesis);

                for (int i = 0; i < inputValue; i++)
                {
                    healthBar += filledSymbol;
                }

                for (int i = 0; i < (healthBarLenght - inputValue); i++)
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

