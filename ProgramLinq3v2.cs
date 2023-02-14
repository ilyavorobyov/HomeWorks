using System;
using System.Collections.Generic;
using System.Linq;

namespace TopPlayersLinq
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PlayersManager playersManager = new PlayersManager();
            playersManager.Work();
        }
    }

    class PlayersManager
    {
        private List<Player> _players = new List<Player>()
        {
            new Player("Иван",10,153), new Player("Никита",14,222), new Player("Стас",12,139), new Player("Тимур",30,521), new Player("Женя",11,124),
            new Player("Артем",43,667), new Player("Тимофей",20,350), new Player("Андрей",50,1310), new Player("Антон",9,135), new Player("Георгий",22,366),
            new Player("Павел",35,441), new Player("Александр",22,150), new Player("Леонид",37,633), new Player("Аркадий",29,402), new Player("Руслан",41,353),
        };

        public void Work()
        {
            const string ShowListWithoutSortingCommand = "1";
            const string TopThreeByLevelCommand = "2";
            const string TopThreeByPowerCommand = "3";
            const string ExitCommand = "4";

            int numberOfTopPlayers = 3;
            string errorInput = "Введена неверная команда, попробуй ещё раз";
            string exitText = "Выполнение программы завершено";
            bool isWork = true;

            while (isWork)
            {
                Console.Clear();
                Console.WriteLine("Добро пожаловать в программу просмотра списка лучних игроков.");
                Console.WriteLine($"Вводи команды:\n{ShowListWithoutSortingCommand} - показать полный список игроков\n{TopThreeByLevelCommand} - топ 3 игрока по уровню\n{TopThreeByPowerCommand} - топ 3 игрока по силе" +
                    $"\n{ExitCommand} - выход из программы");
                string input = Console.ReadLine();

                switch (input)
                {
                    case ShowListWithoutSortingCommand:
                        ShowList(_players);
                        break;

                    case TopThreeByLevelCommand:
                        ShowTopThreeByLevel(numberOfTopPlayers);
                        break;

                    case TopThreeByPowerCommand:
                        ShowTopThreeByPower(numberOfTopPlayers);
                        break;

                    case ExitCommand:
                        isWork = false;
                        break;

                    default:
                        Console.WriteLine(errorInput);
                        break;
                }

                Console.ReadKey();
            }

            Console.WriteLine(exitText);
        }

        private void ShowTopThreeByLevel(int numberOfTopPlayer)
        {
            var topThreePlayerseList = _players.OrderByDescending(player => player.Level).Take(numberOfTopPlayer).ToList();
            ShowList(topThreePlayerseList);
        }

        private void ShowTopThreeByPower(int numberOfTopPlayer)
        {
            var topThreePlayerseList = _players.OrderByDescending(player => player.Power).Take(numberOfTopPlayer).ToList();
            ShowList(topThreePlayerseList);
        }

        private void ShowList(List<Player> players)
        {
            foreach (var player in players)
            {
                player.ShowInfo();
            }
        }
    }

    class Player
    {
        public Player(string name, int level, int power)
        {
            Name = name;
            Level = level;
            Power = power;
        }

        public string Name { get; private set; }
        public int Level { get; private set; }
        public int Power { get; private set; }

        public void ShowInfo()
        {
            Console.WriteLine($"Имя: {Name}, уровень: {Level}, сила: {Power}");
        }
    }
}