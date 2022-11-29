using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp16
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = "You win some. You lose some.";
            string[] words = text.Split(' ');

            foreach (string word in words)
            {
                Console.WriteLine(word);
            }
        }
    }
}