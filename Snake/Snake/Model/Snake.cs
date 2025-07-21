using Snake.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake.Model
{
    public class Snake 
    {
        public Queue<Point> Body { get; set; }
        public SnakeDirection Direction { get; set; }

        public Snake()
        { 
            Body = new Queue<Point>();
        }
    }
}
