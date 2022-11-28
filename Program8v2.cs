using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp13
{
    internal class Program8
    {
        static void Main(string[] args)
        {
            bool isActive = true;
            string message;
            string stopLoop = "exit";

            while (isActive)
            {
                Console.WriteLine("Введите сообщение: ");
                message = Console.ReadLine();

                if (message == stopLoop)
                {
                    Console.WriteLine("Цикл завершен! ");
                    isActive = false;
                }
            }
        }
    }
}
