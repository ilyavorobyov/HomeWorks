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
            Shuffle();
        }

        static void Shuffle()
        {
            int[] massiveToShuffle = { 3, 12, 35, 22, 119, 62, 11, 4, 85, 12 };
            Random random = new Random();

            for (int i = massiveToShuffle.Length - 1; i >= 1; i--)
            {
                int randomIndex = random.Next(i + 1);
                int shuffleIndex = massiveToShuffle[randomIndex];
                massiveToShuffle[randomIndex] = massiveToShuffle[i];
                massiveToShuffle[i] = shuffleIndex;
                Console.WriteLine(massiveToShuffle[i]);
            }
        }
    }
}
