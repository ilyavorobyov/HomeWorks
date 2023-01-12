using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Xml.Linq;

namespace ConsoleApp42
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string AddPlayerCommand = "1";
            const string ShowAllPlayersCommand = "2";
            const string BanPlayerByIdCommand = "3";
            const string UnbanPlayerByIdCommand = "4";
            const string DeletePlayerCommand = "5";
            const string ExitCommand = "6";

            string errorInput = "Введена неверная команда, попробуй ещё раз";
            string exitText = "Выполнение программы завершено";
            Database dataBase = new Database();
            bool isWork = true;

            while (isWork)
            {
                Console.Clear();
                Console.WriteLine($"Вводи команды:\n{AddPlayerCommand} - добавить игрока\n{ShowAllPlayersCommand} - показать всех игроков" +
                    $"\n{BanPlayerByIdCommand} - забанить игрока по ID \n{UnbanPlayerByIdCommand} - разбанить игрока по ID\n{DeletePlayerCommand} - удалить игрока по ID" +
                    $"\n{ExitCommand} - выход их программы");
                string input = Console.ReadLine();

                switch (input)
                {
                    case AddPlayerCommand:
                        dataBase.AddPlayer();
                        break;

                    case ShowAllPlayersCommand:
                        dataBase.ShowInfo();
                        break;

                    case BanPlayerByIdCommand:
                        dataBase.BanPlayerById();
                        break;

                    case UnbanPlayerByIdCommand:
                        dataBase.UnBanPlayerById();
                        break;

                    case DeletePlayerCommand:
                        dataBase.DeletePlayer();
                        break;

                    case ExitCommand:
                        isWork = false;
                        break;

                    default:
                        Console.WriteLine(errorInput);
                        break;
                }
            }
            
            Console.WriteLine(exitText);
        }
    }

    class Player
    {
        public Player(string name, int level, bool isBanned)
        {
            Name = name;
            Level = level;
            IsBanned = isBanned;
        }

        public string Name { get; private set; }
        public int Level { get; private set; }
        public bool IsBanned { get; private set; }

        public void Ban()
        {
            IsBanned = true;
        }

        public void UnBan()
        {
            IsBanned = false;
        }
    }

    class Database
    {
        private Dictionary<int, Player> _players = new Dictionary<int, Player>();
        private int _playerID;

        public Database()
        {
            _playerID = 0;
        }

        public void AddPlayer()
        {
            string bannedTrue = "Да";
            string bannedFalse = "Нет";
            Console.Write("Введите имя игрока: ");
            string name = Console.ReadLine();
            Console.Write("Введите уровень игрока: ");
            bool isNumber = int.TryParse(Console.ReadLine(), out int level);

            if (isNumber == false)
            {
                Console.WriteLine("Неккоретный ввод. Уровень должен содержать только числа");
                Console.ReadKey();
                return;
            }

            Console.Write($"Игрок забанен? ({bannedTrue} или {bannedFalse}): ");
            string input = Console.ReadLine();
            bool isBanned;

            if (input == bannedTrue)
            {
                isBanned = true;
            }
            else if (input == bannedFalse)
            {
                isBanned = false;
            }
            else
            {
                Console.WriteLine("Неккоретный ввод. Попробуйте ещё раз");
                Console.ReadKey();
                return;
            }

            _players.Add(_playerID, new Player(name, level, isBanned));
            _playerID++;
            Console.WriteLine("Игрок успешно добавлен! Нажми любую кнопку для возврата в меню");
            Console.ReadKey();
        }

        public void ShowInfo()
        {
            if (_players.Count != 0)
            {
                for (int i = 0; i < _players.Count; i++)
                {
                    Console.WriteLine($"Имя игрока: {_players[i].Name}\nУровень игрока {_players[i].Level}");

                    if (_players[i].IsBanned)
                    {
                        Console.WriteLine("Есть у игрока бан: да");
                    }
                    else
                    {
                        Console.WriteLine("Есть у игрока бан: нет");
                    }

                    Console.WriteLine($"Id игрока: {i}");
                    Console.WriteLine();
                }
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("В базе ещё нет игроков");
                Console.ReadKey();
            }
        }

        public void BanPlayerById()
        {
            Console.Write("Введите Id игрока для бана: ");
            string input = Console.ReadLine();

            if (TryGetPlayer(out Player player, input))
            {
                if (player.IsBanned == false)
                {
                    player.Ban();
                    Console.WriteLine("Игрок забанен!");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("Игрок ранее уже был забанен");
                    Console.ReadKey();
                }
            }
            else
            {
                Console.WriteLine("Игрока с таким ID в базе нет!");
                Console.ReadKey();
            }
        }

        public void UnBanPlayerById()
        {
            Console.Write("Введите Id игрока для разбана: ");
            string input = Console.ReadLine();

            if (TryGetPlayer(out Player player, input))
            {
                if (player.IsBanned == true)
                {
                    player.UnBan();
                    Console.WriteLine("Игрок разабанен!");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("У игрока нет бана");
                    Console.ReadKey();
                }
            }
            else
            {
                Console.WriteLine("Игрока с таким ID нет в базе");
                Console.ReadKey();
            }
        }

        public void DeletePlayer()
        {
            Console.Write("Введите id игрока для удаления: ");
            string input = Console.ReadLine();

            if (TryGetPlayer(out Player player, input))
            {
                _players.Remove(Convert.ToInt32(input));
                Console.WriteLine("Игрок успешно удалён!");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Игрока с таким Id в базе нет");
                Console.ReadKey();
            }
        }

        private bool TryGetPlayer(out Player player, string id)
        {
            player = null;
            int.TryParse(id, out int number);

            for (int i = 0; i < _players.Count; i++)
            {
                if (i == number)
                {
                    player = _players[i];
                    return true;
                }
            }

            return false;
        }
    }
}
