using System;

namespace ConsoleApp71
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int value = 5;
            int minValue = 1;
            int maxValue = 3;
            Console.WriteLine(Clamp(value, minValue, maxValue));
        }

        public static int Clamp(int value, int minValue, int maxValue)
        {
            if (minValue > maxValue)
                throw new ArgumentOutOfRangeException();

            if (value < minValue)
                return minValue;
            else if (value > maxValue)
                return maxValue;
            else
                return value;
        }
    }
}