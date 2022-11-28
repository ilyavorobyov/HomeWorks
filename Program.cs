using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp12
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string userName;
            int userAge;
            string userCity;
            string userWork;

            Console.WriteLine("Здравствуйте! Расскажите о себе: ");
            Console.Write("Как вас зовут?: ");
            userName = Console.ReadLine();
            Console.Write("Сколько вам лет?: ");
            userAge = Convert.ToInt32(Console.ReadLine());
            Console.Write("Из какого вы города?: ");
            userCity = Console.ReadLine();
            Console.Write("Где вы работаете?: ");
            userWork = Console.ReadLine();
            Console.WriteLine("Вас зовут " + userName + " Ваш возраст " + userAge + " лет, вы из города " + userCity + " вы работаете " + userWork );
            Console.ReadKey();
        }
    }
}



