using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example3.Models
{
    public class Snake : Drawer
    {
        Point head = new Point();
        public void Eat() { }
        public Snake()
        {
            color = ConsoleColor.Yellow;
            sign = 'o';
        }

        public void Move(int dx, int dy)
        {

            for (int i = body.Count - 1; i > 0; --i)
            {
                body[i].x = body[i - 1].x;
                body[i].y = body[i - 1].y;
            }

            body[0].x = body[0].x + dx;
            body[0].y = body[0].y + dy;

            //проверка, можем ли скушать
            if (Game.snake.body[0].x == Game.food.body[0].x && Game.snake.body[0].y == Game.food.body[0].y)
            {
                //добавил к змейке новую точку. прирост
                Game.snake.body.Add(new Point { x = Game.food.body[0].x, y = Game.food.body[0].y });
                // переместил еду на новую позицию 
                Game.food.body[0].x = new Random().Next(0, 49);
                Game.food.body[0].y = new Random().Next(0, 49);
            }
            //проверка, есть ли столкновение со стеной
            for (int i = 0; i < Game.wall.body.Count; ++i)
            {
                if (Game.snake.body[0].x == Game.wall.body[i].x && Game.snake.body[0].y == Game.wall.body[i].y)
                {
                    Console.Clear();
                    Console.SetCursorPosition(35, 15);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Game Over!");
                    Game.inGame = false;
                }
            }
        }
    }

}
