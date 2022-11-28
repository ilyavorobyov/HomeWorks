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

            const string usdToRubСommand = "1";
            const string usdToEurCommand = "2";
            const string rubToUsdCommand = "3";
            const string rubToEurCommand = "4";
            const string eurToUsdCommand = "5";
            const string eurToRubCommand = "6";
            const string exitCommand = "7";

            Console.WriteLine("Конвертер валют. \nУ вас: " + usdBalance + " долларов, " + rubBalance + " рублей, " + eurBalance + " евро");
            Console.WriteLine("Введите нужную комманду:\n" + usdToRubСommand + " - обмен долларов на рубли \n" + usdToEurCommand + " - обмен долларов на евро \n" + rubToUsdCommand + " - обмен рублей на доллары " +
                "\n" + rubToEurCommand + " - обмен рублей на евро \n" + eurToUsdCommand + " - обмен евро на доллары \n" + eurToRubCommand + " - обмен евро на рубли \n" + exitCommand + " - закрыть конвертер");
            userInput = Console.ReadLine();

            while (isOpen)
            {
                switch (userInput)
                {
                    case usdToRubСommand:
                        Console.WriteLine("Обмен долларов на рубли.");
                        Console.Write("Сколько вы хотите обменять:");
                        currencyCount = Convert.ToSingle(Console.ReadLine());

                        if (usdBalance >= currencyCount)
                        {
                            usdBalance -= currencyCount;
                            rubBalance += currencyCount * usdToRubExchangeRate;
                            Console.WriteLine("Конвертер валют. \nУ вас: " + usdBalance + " долларов, " + rubBalance + " рублей, " + eurBalance + " евро");
                        }
                        else
                        {
                            Console.WriteLine("Недостаточно долларов");
                        }
                        break;
                    case usdToEurCommand:
                        Console.WriteLine("Обмен долларов на евро.");
                        Console.Write("Сколько вы хотите обменять:");
                        currencyCount = Convert.ToSingle(Console.ReadLine());

                        if (usdBalance >= currencyCount)
                        {
                            usdBalance -= currencyCount;
                            eurBalance += currencyCount * usdToEurExchangeRate;
                            Console.WriteLine("Конвертер валют. \nУ вас: " + usdBalance + " долларов, " + rubBalance + " рублей, " + eurBalance + " евро");
                        }
                        else
                        {
                            Console.WriteLine("Недостаточно долларов");
                        }
                        break;
                    case rubToUsdCommand:
                        Console.WriteLine("Обмен рублей на доллары.");
                        Console.Write("Сколько вы хотите обменять:");
                        currencyCount = Convert.ToSingle(Console.ReadLine());

                        if (rubBalance >= currencyCount)
                        {
                            rubBalance -= currencyCount;
                            usdBalance += currencyCount * rubToUsdExchangeRate;
                            Console.WriteLine("Конвертер валют. \nУ вас: " + usdBalance + " долларов, " + rubBalance + " рублей, " + eurBalance + " евро");
                        }
                        else
                        {
                            Console.WriteLine("Недостаточно рублей");
                        }
                        break;
                    case rubToEurCommand:
                        Console.WriteLine("Обмен рублей на евро.");
                        Console.Write("Сколько вы хотите обменять:");
                        currencyCount = Convert.ToSingle(Console.ReadLine());

                        if (rubBalance >= currencyCount)
                        {
                            rubBalance -= currencyCount;
                            eurBalance += currencyCount * rubToEurExchangeRate;
                            Console.WriteLine("Конвертер валют. \nУ вас: " + usdBalance + " долларов, " + rubBalance + " рублей, " + eurBalance + " евро");
                        }
                        else
                        {
                            Console.WriteLine("Недостаточно рублей");
                        }
                        break;
                    case eurToUsdCommand:
                        Console.WriteLine("Обмен евро на доллары.");
                        Console.Write("Сколько вы хотите обменять:");
                        currencyCount = Convert.ToSingle(Console.ReadLine());

                        if (eurBalance >= currencyCount)
                        {
                            eurBalance -= currencyCount;
                            usdBalance += currencyCount * eurToUsdExchangeRate;
                            Console.WriteLine("Конвертер валют. \nУ вас: " + usdBalance + " долларов, " + rubBalance + " рублей, " + eurBalance + " евро");
                        }
                        else
                        {
                            Console.WriteLine("Недостаточно евро");
                        }
                        break;
                    case eurToRubCommand:
                        Console.WriteLine("Обмен евро на рубли.");
                        Console.Write("Сколько вы хотите обменять:");
                        currencyCount = Convert.ToSingle(Console.ReadLine());

                        if (eurBalance >= currencyCount)
                        {
                            eurBalance -= currencyCount;
                            rubBalance += currencyCount * eurToRubExchangeRate;
                            Console.WriteLine("Конвертер валют. \nУ вас: " + usdBalance + " долларов, " + rubBalance + " рублей, " + eurBalance + " евро");
                        }
                        else
                        {
                            Console.WriteLine("Недостаточно евро");
                        }
                        break;
                    case exitCommand:
                        Console.WriteLine("Конвертер закрыт.");
                        isOpen = false;
                        break;
                }
            }
        }
    }
}