using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homeworks
{
    internal class Program7
    {
        static void Main(string[] args)
        {
            int repeatsCount;
            string message;
            Console.Write("Введите сообщение для повтора: ");
            message = Console.ReadLine();
            Console.Write("Введите, сколько раз нужно повторить вывод сообщения: ");
            repeatsCount = Convert.ToInt32(Console.ReadLine());

            for(int i =0; i< repeatsCount; i++) 
            { 
                Console.WriteLine(message);
            }
        }
    }
}