using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp17
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string Parenthesis = "()(())";
            char LeftParenth = ')';
            char RightParenth = '(';

            bool isClosed = false;
            bool isOpen = false;

            int firstParenthesisIndex = 0;
            int lastParenthesisIndex = Parenthesis.Length - 1;

            int countOfRightParenthesis = 0;
            int countOfLeftParenthesis = 0;
            int parenthesisNesting = 0;
            int firstCounter = 0;
            int secondCounter = 0;

            for (int i = 0; i < Parenthesis.Length; i++)
            {
                if (Parenthesis[i] == LeftParenth)
                {
                    countOfLeftParenthesis++;
                    firstCounter++;
                    if (Parenthesis[lastParenthesisIndex] == LeftParenth)
                    {
                        isOpen = true;
                    }
                }
                else if (Parenthesis[i] == RightParenth)
                {
                    countOfRightParenthesis++;
                    firstCounter = 0;
                    if (Parenthesis[firstParenthesisIndex] == RightParenth)
                    {
                        isClosed = true;
                    }
                }

                if (firstCounter > 0)
                {
                    if (secondCounter < firstCounter)
                    {
                        secondCounter = firstCounter;
                        parenthesisNesting = secondCounter;
                    }
                }
            }

            if (countOfRightParenthesis == countOfLeftParenthesis && isOpen == true && isClosed == true)
            {
                Console.WriteLine("скобки закрытые");
            }
            else
            {
                Console.WriteLine("скобки не закрытые");
            }

            Console.WriteLine("Максимальная вложенность: " + parenthesisNesting);
        }
    }
}
