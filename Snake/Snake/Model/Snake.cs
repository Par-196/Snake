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
        public Queue<Point> Body { get; set; } = new Queue<Point>();

        public Snake()
        { 
            Body = new Queue<Point>();
            Body.Enqueue(new Point(1, 1));
            
        }
    }
}
