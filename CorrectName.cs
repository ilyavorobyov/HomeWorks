using System;

namespace ConsoleApp71
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = 5;
            int minValue = 1;
            int maxValue = 3;
            Console.WriteLine(ClampNumber(number, minValue, maxValue));
        }

        public static int ClampNumber(int number, int minValue, int maxValue)
        {
            if (minValue > maxValue)
                throw new ArgumentOutOfRangeException();

            if (number < minValue)
                return minValue;
            else if (number > maxValue)
                return maxValue;
            else
                return number;
        }
    }
}