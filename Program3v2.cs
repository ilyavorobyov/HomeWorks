using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp12
{
    internal class Program3
    {
        static void Main(string[] args)
        {
            int pictures = 52;
            int rowCapacity = 3;

            int numberOfCompleteRows = pictures / rowCapacity;
            int picturesWithoutRow = pictures % rowCapacity;
            
            Console.WriteLine("Полностью заполненных рядов картинок: "  + numberOfCompleteRows + " , а картинок без ряда осталось: " + picturesWithoutRow);
            Console.WriteLine("Полностью заполненных рядов картинок: "  + numberOfCompleteRows + " , а картинок без ряда осталось: " + picturesWithoutRow);
            Console.WriteLine("Полностью заполненных рядов картинок: "  + numberOfCompleteRows + " , а картинок без ряда осталось: " + picturesWithoutRow);
            Console.WriteLine("Слияние изменений2");
        }

        private void TestingNewBranch()
        {
            Console.WriteLine("Изменения из новой ветки");
        }
    }
}
