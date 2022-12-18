using System;
using System.Security.Cryptography;

namespace MyFirstApp
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.CursorVisible = false;

            bool isPlaying = true;
            char[,] map = new char[,]
                {
                {'#','#','#','#','#','#'},
                {'#',' ',' ',' ',' ','#'},
                {'#',' ','#',' ',' ','#'},
                {'#',' ','#',' ',' ','#'},
                {'#',' ','#',' ',' ','#'},
                {'#',' ','#',' ',' ','#'},
                {'#','#','#','#','#','#'}
                };
            char userSymbol = '@';
            char wallSymbol = '#';
            char spaceSymbol = ' ';
            int positionUserX = 1;
            int positionUserY = 1;
            int directionX = 0;
            int directionY = 0;

            DrawMap(map);
            DrawUserInStartPosition(positionUserY, positionUserX, userSymbol);

            while (isPlaying)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                GetDirection(key, out directionX, out directionY);

                if (directionX != 0 || directionY != 0)
                {
                    if (map[positionUserX + directionX, positionUserY + directionY] != wallSymbol)
                    {
                        MoveUser(ref positionUserX, ref positionUserY, directionX, directionY, userSymbol, spaceSymbol);
                    }
                }

                if (key.Key == ConsoleKey.Escape)
                {
                    isPlaying = false;
                }
            }
        }

        static void DrawUserInStartPosition(int positionY, int positionX, char userSymbol)
        {
            Console.SetCursorPosition(positionY, positionX);
            Console.Write(userSymbol);
        }

        static void MoveUser(ref int positionX, ref int positionY, int directionX, int directionY, char userSymbol, char spaceSymbol)
        {
            Console.SetCursorPosition(positionY, positionX);
            Console.Write(spaceSymbol);
            positionX += directionX;
            positionY += directionY;
            Console.SetCursorPosition(positionY, positionX);
            Console.Write(userSymbol);
        }

        static void GetDirection(ConsoleKeyInfo key, out int directionX, out int directionY)
        {
            const ConsoleKey MoveUp = ConsoleKey.UpArrow;
            const ConsoleKey MoveDown = ConsoleKey.DownArrow;
            const ConsoleKey MoveLeft = ConsoleKey.LeftArrow;
            const ConsoleKey MoveRight = ConsoleKey.RightArrow;

            directionX = 0;
            directionY = 0;

            switch (key.Key)
            {
                case MoveUp:
                    directionX = -1;
                    break;

                case MoveDown:
                    directionX = 1;
                    break;

                case MoveLeft:
                    directionY = -1;
                    break;

                case MoveRight:
                    directionY = 1;
                    break;
            }
        }

        static void DrawMap(char[,] map)
        {
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    Console.Write(map[i, j]);
                }

                Console.WriteLine();
            }
        }
    }
}