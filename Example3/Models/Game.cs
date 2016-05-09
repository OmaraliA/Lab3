using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example3.Models
{
    public class Game
    {
        public static bool inGame;
        public static Snake snake = new Snake();
        public static Wall wall = new Wall();
        public static Food food = new Food();
        public static void Redraw()
        {
            Console.Clear();
            snake.Draw();
            food.Draw();
            wall.Draw();
        }

        public static void LoadLevel(int i)
        {
            FileStream fs = new FileStream(string.Format(@"Levels\LevelWall{0}.txt", i),
                FileMode.Open, FileAccess.Read);

            StreamReader reader = new StreamReader(fs);

            string line;
            int row = -1;
            int col = 0;

            while ((line = reader.ReadLine()) != null)
            {
                row++;
                col = -1;
                foreach (char c in line)
                {
                    col++;
                    if (c == '#')
                    {
                        Game.wall.body.Add(new Point { x = col, y = row });
                    }
                }
            }

            fs.Close();
        }

        public static void Resume()
        {
            wall.Resume();
            food.Resume();
            snake.Resume();
        }

        public static void Save()
        {
            wall.Save();
            food.Save();
            snake.Save();
        }

        public static void Init()
        {
            snake.body.Add(new Point { x = 10, y = 10 });
            food.body.Add(new Point { x = 20, y = 10 });
        }
    }

}
