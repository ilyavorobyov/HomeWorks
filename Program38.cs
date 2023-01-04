using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp42
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Player player = new Player(10, 5);
            PlayerShow playerShow = new PlayerShow('$');
            playerShow.DrawPlayer(player.GetYPosition, player.GetXPosition);
        }
    }

    class Player
    {
        private int _xPosition;
        private int _yPosition;

        public int GetXPosition
        {
            get { return _xPosition; }
        }

        public int GetYPosition
        {
            get { return _yPosition; }
        }

        public Player(int xPosition, int yPosition)
        {
            _xPosition = xPosition;
            _yPosition = yPosition;
        }
    }

    class PlayerShow
    {
        private char _playerSymbol;

        public PlayerShow(char playerSymbol)
        {
            _playerSymbol = playerSymbol;
        }

        public void DrawPlayer(int _xPlayerPosition, int _yPlayerPosition)
        {
            Console.SetCursorPosition(_yPlayerPosition, _xPlayerPosition);
            Console.Write(_playerSymbol);
        }
    }
}