using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homeworks
{
    internal class Program8
    {
        static void Main(string[] args)
        {
            bool isActive = true;
            string message;

            while(isActive)
            {
                Console.WriteLine("Введите сообщение: ");
                message = Console.ReadLine();
                if(message == "exit")
                {
                    Console.WriteLine("Цикл завершен! ");
                    isActive = false;
                }
            }
        }
    }
}