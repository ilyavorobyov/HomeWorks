using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp23
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] firstArray = { 2, 1, 3, 5, 1 };
            int[] secondArray = { 4, 2, 6, 1 };
            List<int> list = new List<int>();

            WriteInList(list, firstArray.Length, firstArray);
            WriteInList(list, secondArray.Length, secondArray);

            foreach (int number in list)
            {
                Console.WriteLine(number);
            }
        }

        static void WriteInList(List<int> list, int arrayLength, int[] array)
        {
            for (int i = 0; i < arrayLength; i++)
            {
                if (list.Contains(array[i]) == false)
                {
                    list.Add(array[i]);
                }
            }
        }
    }
}