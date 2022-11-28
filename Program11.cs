using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp13
{
    internal class Program11
    {
        static void Main(string[] args)
        {
            float usdBalance = 200;
            float rubBalance = 5000;
            float eurBalance = 300;
            float usdToRubExchangeRate = 60f;
            float usdToEurExchangeRate = 0.9f;
            float rubToUsdExchangeRate = 0.016f;
            float rubToEurExchangeRate = 0.015f;
            float eurToUsdExchangeRate = 1.1f;
            float eurToRubExchangeRate = 62f;
            string userInput;
            float currencyCount;

            bool isOpen = true;

            Console.WriteLine("Конвертер валют. \n У вас: " + usdBalance + " долларов, " + rubBalance + " рублей, " + eurBalance + " евро");
            Console.WriteLine(" Введите нужную комманду:\n 1 - обмен долларов на рубли \n 2 - обмен долларов на евро \n 3 - обмен рублей на доллары " +
                "\n 4 - обмен рублей на евро \n 5 - обмен евро на доллары \n 6 - обмен евро на рубли \n 7 - закрыть конвертер");
            userInput = Console.ReadLine();

            while (isOpen)
            {
                switch (userInput)
                {
                    case "1":
                        Console.WriteLine("Обмен долларов на рубли.");
                        Console.Write("Сколько вы хотите обменять:");
                        currencyCount = Convert.ToSingle(Console.ReadLine());

                        if (usdBalance >= currencyCount)
                        {
                            usdBalance -= currencyCount;
                            rubBalance += currencyCount * usdToRubExchangeRate;
                            Console.WriteLine("Конвертер валют. \n У вас: " + usdBalance + " долларов, " + rubBalance + " рублей, " + eurBalance + " евро");
                            Console.WriteLine("Чтобы выйти в главное меню, введите back");
                        }
                        else
                        {
                            Console.WriteLine("Недостаточно долларов");
                        }
                        break;
                    case "2":
                        Console.WriteLine("Обмен долларов на евро.");
                        Console.Write("Сколько вы хотите обменять:");
                        currencyCount = Convert.ToSingle(Console.ReadLine());

                        if (usdBalance >= currencyCount)
                        {
                            usdBalance -= currencyCount;
                            eurBalance += currencyCount * usdToEurExchangeRate;
                            Console.WriteLine("Конвертер валют. \n У вас: " + usdBalance + " долларов, " + rubBalance + " рублей, " + eurBalance + " евро");
                        }
                        else
                        {
                            Console.WriteLine("Недостаточно долларов");
                        }
                        break;
                    case "3":
                        Console.WriteLine("Обмен рублей на доллары.");
                        Console.Write("Сколько вы хотите обменять:");
                        currencyCount = Convert.ToSingle(Console.ReadLine());

                        if (rubBalance >= currencyCount)
                        {
                            rubBalance -= currencyCount;
                            usdBalance += currencyCount * rubToUsdExchangeRate;
                            Console.WriteLine("Конвертер валют. \n У вас: " + usdBalance + " долларов, " + rubBalance + " рублей, " + eurBalance + " евро");
                        }
                        else
                        {
                            Console.WriteLine("Недостаточно рублей");
                        }
                        break;
                    case "4":
                        Console.WriteLine("Обмен рублей на евро.");
                        Console.Write("Сколько вы хотите обменять:");
                        currencyCount = Convert.ToSingle(Console.ReadLine());

                        if (rubBalance >= currencyCount)
                        {
                            rubBalance -= currencyCount;
                            eurBalance += currencyCount * rubToEurExchangeRate;
                            Console.WriteLine("Конвертер валют. \n У вас: " + usdBalance + " долларов, " + rubBalance + " рублей, " + eurBalance + " евро");
                        }
                        else
                        {
                            Console.WriteLine("Недостаточно рублей");
                        }
                        break;
                    case "5":
                        Console.WriteLine("Обмен евро на доллары.");
                        Console.Write("Сколько вы хотите обменять:");
                        currencyCount = Convert.ToSingle(Console.ReadLine());

                        if (eurBalance >= currencyCount)
                        {
                            eurBalance -= currencyCount;
                            usdBalance += currencyCount * eurToUsdExchangeRate;
                            Console.WriteLine("Конвертер валют. \n У вас: " + usdBalance + " долларов, " + rubBalance + " рублей, " + eurBalance + " евро");
                        }
                        else
                        {
                            Console.WriteLine("Недостаточно евро");
                        }
                        break;
                    case "6":
                        Console.WriteLine("Обмен евро на рубли.");
                        Console.Write("Сколько вы хотите обменять:");
                        currencyCount = Convert.ToSingle(Console.ReadLine());

                        if (eurBalance >= currencyCount)
                        {
                            eurBalance -= currencyCount;
                            rubBalance += currencyCount * eurToRubExchangeRate;
                            Console.WriteLine("Конвертер валют. \n У вас: " + usdBalance + " долларов, " + rubBalance + " рублей, " + eurBalance + " евро");
                        }
                        else
                        {
                            Console.WriteLine("Недостаточно евро");
                        }
                        break;
                    case "7":
                        {
                            Console.WriteLine("Конвертер закрыт.");
                            isOpen = false;
                            break;
                        }
                }
            }
        }
    }
}