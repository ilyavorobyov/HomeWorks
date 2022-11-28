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
            string userName = " Ivanov";
            string userSurname = " Stepan";
            Console.WriteLine("До перестановки ИМЯ и ФАМИЛИЯ:" + userName + userSurname);
            (userName, userSurname) = (userSurname, userName);
            Console.WriteLine("После перестановки ИМЯ и ФАМИЛИЯ:" + userName + userSurname);
            Console.ReadKey();
        }
    }
}



