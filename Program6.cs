using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp12
{
    internal class Program6
    {
        static void Main(string[] args)
        {
            int peopleInLine;
            int timeOfReceipt = 10;
            int hourDuration = 60;
            int totalWaitingTime;
            int waitingHours;
            int waitingminutes;

            Console.Write("Сколько людей в очереди?: ");
            peopleInLine = Convert.ToInt32(Console.ReadLine());
            totalWaitingTime = peopleInLine * timeOfReceipt;
            waitingHours = totalWaitingTime / hourDuration;
            waitingminutes = totalWaitingTime % hourDuration;
            Console.WriteLine("Вам осталось ждать: " + waitingHours + " часов, и: " + waitingminutes + " минут");
            Console.ReadKey();
        }
    }
}