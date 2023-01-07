using System;

namespace ConsoleApp42
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Player player = new Player(10, 9);
            PlayerShow playerShow = new PlayerShow('$');
            playerShow.DrawSymbol(player._yPosition, player._xPosition);
        }
    }

    class Player
    {
        public int _xPosition { get; private set; }
        public int _yPosition { get; private set; }

        public Player(int xPosition, int yPosition)
        {
            _xPosition = xPosition;
            _yPosition = yPosition;
        }
    }

    class PlayerShow
    {
        private char _symbol;

        public PlayerShow(char symbol)
        {
            _symbol = symbol;
        }

        public void DrawSymbol(int _xPosition, int _yPosition)
        {
            Console.SetCursorPosition(_yPosition, _xPosition);
            Console.Write(_symbol);
        }
    }
}