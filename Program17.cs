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
            const string Parenthesis = "(()(())))(()))";
            const char LeftParenth = ')';

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
                }
                else
                {
                    countOfRightParenthesis++;
                    firstCounter = 0;
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

            if (countOfRightParenthesis == countOfLeftParenthesis)
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