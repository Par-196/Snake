using Snake.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();


            game.Field = new Field(new Cell[20, 70]);



            game.Field.ShowField();

        }
    }
}
