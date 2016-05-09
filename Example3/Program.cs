using Example3.Models;
using System;

namespace Example3
{ 
    class Program
    {
     
        static void Main(string[] args)
        {
           
            Game.inGame = true;

            Game.LoadLevel(1);
            Game.Init();

            Console.SetWindowSize(48, 48);
            
            while (Game.inGame)
            {
                Game.Redraw();

                ConsoleKeyInfo pressedKey = Console.ReadKey();

                switch (pressedKey.Key)
                {
                    case ConsoleKey.UpArrow:
                        Game.snake.Move(0,-1);
                        break;
                    case ConsoleKey.DownArrow:
                        Game.snake.Move(0, 1);
                        break;
                    case ConsoleKey.LeftArrow:
                        Game.snake.Move(-1, 0);
                        break;
                    case ConsoleKey.RightArrow:
                        Game.snake.Move(1, 0);
                        break;
                    case ConsoleKey.Escape:
                        Game.inGame = false;
                        break;
                    case ConsoleKey.F2:
                        Game.Save();
                        break;
                    case ConsoleKey.F3:
                        Game.Resume();
                        break;
                }
            }

            Console.ReadKey();
        }
    }
}
