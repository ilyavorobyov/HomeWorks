using System;

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
            int positionUserX = 1;
            int positionUserY = 1;
            int directionX = 0;
            int directionY = 0;

            DrawMap(map);
            DrawUser(positionUserY, positionUserX);

            while (isPlaying)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                GetDirection(key, out directionX, out directionY);

                if (directionX != 0 || directionY != 0)
                {
                    if (map[positionUserX + directionX, positionUserY + directionY] != '#')
                    {
                        MoveUser(ref positionUserX, ref positionUserY, directionX, directionY);
                    }
                }

                if (key.Key == ConsoleKey.Escape)
                {
                    isPlaying = false;
                }
            }
        }

        static void DrawUser(int positionY, int positionX)
        {
            Console.SetCursorPosition(positionY, positionX);
            Console.Write('@');
        }

        static void MoveUser(ref int positionX, ref int positionY, int directionX, int directionY)
        {
            Console.SetCursorPosition(positionY, positionX);
            Console.Write(" ");
            positionX += directionX;
            positionY += directionY;
            Console.SetCursorPosition(positionY, positionX);
            Console.Write('@');
        }

        static void GetDirection(ConsoleKeyInfo key, out int directionX, out int directionY)
        {
            directionX = 0;
            directionY = 0;

            switch (key.Key)
            {
                case ConsoleKey.UpArrow:
                    directionX = -1;
                    break;

                case ConsoleKey.DownArrow:
                    directionX = 1;
                    break;

                case ConsoleKey.LeftArrow:
                    directionY = -1;
                    break;

                case ConsoleKey.RightArrow:
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