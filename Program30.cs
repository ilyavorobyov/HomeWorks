using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace ConsoleApp22
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> localMax = new List<int>();
            Random random = new Random();
            int arraySize = 30;
            int[] array = new int[arraySize];
            int minvalue = 1;
            int maxvalue = 20;
            int numberForCalculate = 1;
            int secondNumberForCalculate = 2;

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(minvalue, maxvalue);
            }

            if (array[0] > array[1])
            {
                localMax.Add(array[0]);
            }

            for (int i = numberForCalculate; i < arraySize - numberForCalculate; i++)
            {
                if (array[i - numberForCalculate] < array[i] && array[i + numberForCalculate] < array[i])
                {
                    localMax.Add(array[i]);
                }
            }

            if (array[array.Length - numberForCalculate] > array[array.Length - secondNumberForCalculate])
            {
                localMax.Add(array[array.Length - numberForCalculate]);
            }

            foreach (int numb in localMax)
            {
                Console.WriteLine(numb + " ");
            }
        }
    }
}