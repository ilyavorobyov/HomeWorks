using System;
using System.Collections.Generic;

namespace CSharpLight
{
    class Program
    {
        static void Main(string[] args)
        {
            const string TakeCardCommand = "1";
            const string ShowAllCardsCommand = "2";
            const string ExitCommand = "3";

            Player player = new Player();
            Deck deck = new Deck();
            string userInput;
            bool isWork = true;

            while (isWork)
            {
                Console.WriteLine($"{TakeCardCommand} Вытянуть карту\n{ShowAllCardsCommand} Завершить игру и показать взятые карты \n{ExitCommand} Выход");
                Console.Write("Введите нужную команду: ");
                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case TakeCardCommand:
                        player.GetCard(deck);
                        break;

                    case ShowAllCardsCommand:
                        player.ShowWinPlayer();
                        player.ShowCard();
                        isWork = false;
                        break;

                    case ExitCommand:
                        Console.WriteLine("Выполнение программы завершено");
                        isWork = false;
                        break;

                    default:
                        Console.WriteLine("Такой команды нет, попробуй снова");
                        break;
                }

                Console.ReadKey();
                Console.Clear();
            }
        }
    }

    class Card
    {
        public string Name { get; private set; }
        public int PowerPoint { get; private set; }

        public Card(string name, int powerPoint)
        {
            Name = name;
            PowerPoint = powerPoint;
        }
    }

    class Deck
    {
        private List<Card> _cards = new List<Card>();
        private Random _random = new Random();

        public Deck()
        {
            _cards.Add(new Card("Card 1", GetPowerPoint()));
            _cards.Add(new Card("Card 2", GetPowerPoint()));
            _cards.Add(new Card("Card 3", GetPowerPoint()));
            _cards.Add(new Card("Card 4", GetPowerPoint()));
            _cards.Add(new Card("Card 5", GetPowerPoint()));
        }

        public bool TryGetCard(out Card card)
        {
            if (_cards.Count > 0)
            {
                card = _cards[GetNumberCard()];
                _cards.Remove(card);
                return true;
            }
            else
            {
                card = null;
                return false;
            }
        }

        private int GetPowerPoint()
        {
            int powerPoint;
            int minimalPowerPoint = 5;
            int maximumPowerPoint = 15;
            powerPoint = _random.Next(minimalPowerPoint, maximumPowerPoint);
            return powerPoint;
        }

        private int GetNumberCard()
        {
            int numberCard = 0;
            int minimalNumberCard = 0;
            int maximumNumberCard = 4;

            if (_cards.Count > maximumNumberCard)
            {
                numberCard = _random.Next(minimalNumberCard, maximumNumberCard);
                maximumNumberCard--;
            }

            return numberCard;
        }
    }

    class Player
    {
        private List<Card> _hand = new List<Card>();

        public void GetCard(Deck deck)
        {
            if (deck.TryGetCard(out Card card))
            {
                _hand.Add(card);
                Console.WriteLine("Ваши карты");
                ShowCard();
            }
            else
            {
                Console.WriteLine("В колоде больше нет карт");
            }
        }

        public void ShowCard()
        {
            for (int i = 0; i < _hand.Count; i++)
            {
                Console.WriteLine($"Карта: {_hand[i].Name}. Очков: {_hand[i].PowerPoint}");
            }
        }

        public void ShowWinPlayer()
        {
            int countPowerPoint = GetCountPoint();
            int scorePointToWin = 30;

            if (countPowerPoint >= scorePointToWin)
            {
                Console.WriteLine($"Вы победили, у вас {countPowerPoint} очков");
            }
            else
            {
                scorePointToWin -= countPowerPoint;
                Console.WriteLine($"Вы проиграли, не хватило {scorePointToWin} очков");
            }
        }

        private int GetCountPoint()
        {
            int countPowerPoint = 0;

            for (int i = 0; i < _hand.Count; i++)
            {
                countPowerPoint += _hand[i].PowerPoint;
            }

            return countPowerPoint;
        }
    }
}