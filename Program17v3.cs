using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp18
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string parenthesis = "(())";
            char rightParenth = '(';
            char leftParenth = ')';
            int depth = 0;
            int maxDepth = 0;

            foreach (char symbol in parenthesis)
            {
                if (symbol == rightParenth)
                {
                    depth++;
                }
                else if (symbol == leftParenth)
                {
                    depth--;
                }

                if (depth < 0)
                {
                    break;
                }

                if (depth > maxDepth)
                {
                    maxDepth = depth;
                }
            }

            if (depth == 0)
            {
                Console.WriteLine("Корректное скобочное выражение. Глубина: " + maxDepth);
            }
            else
            {
                Console.WriteLine("Некорректное скобочное выражение");
            }
        }
    }
}