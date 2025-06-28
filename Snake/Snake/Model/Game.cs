using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake.Model
{
    public class Game
    {
        public Field Field { get; set; }
        public Snake Snake { get; set; }
        public User User { get; set; }

        public Game()
        {
        }


        public void StartGame()
        {
            while (true)
            {
                var result = Console.ReadKey(true); // Wait for user input to start the game

                //switch (result.Key)
                //{
                //    case ConsoleKey.UpArrow:
                //        Snake.Direction = Direction.Up;
                //        break;
                //    case ConsoleKey.DownArrow:
                //        Snake.Direction = Direction.Down;
                //        break;
                //    case ConsoleKey.LeftArrow:
                //        Snake.Direction = Direction.Left;
                //        break;
                //    case ConsoleKey.RightArrow:
                //        Snake.Direction = Direction.Right;
                //        break;
                //}

                //Snake.Direction
                
            }
        }
    }
}
