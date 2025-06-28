using Snake.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Snake.Model
{
    public class Cell
    {
        public Point Point { get; set; }
        public TypeCell Type { get; set; } = TypeCell.Empty;

        public Cell(TypeCell type)
        {
            Type = type;
        }

        public override string ToString()
        {
            switch (Type)
            {
                case TypeCell.Empty:
                    { 
                        return " ";
                    }
                case TypeCell.SnakeBody:
                    { 
                        return "*";
                    }
                case TypeCell.Border:
                    { 
                        return "#";
                    }
                case TypeCell.Food:
                    { 
                        return "@";
                    }
                default:
                    break;
            }

            return "Error";
        }
        
    }
}
