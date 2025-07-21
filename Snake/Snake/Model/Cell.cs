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
                        ConsoleColor color = ConsoleColor.Black;
                        Console.BackgroundColor = color;
                        return " ";
                    }
                case TypeCell.SnakeHead:
                    {
                        ConsoleColor color = ConsoleColor.Yellow;
                        Console.BackgroundColor = color;
                        return " ";
                    }
                case TypeCell.SnakeBody:
                    {
                        ConsoleColor color = ConsoleColor.Green;
                        Console.BackgroundColor = color;
                        return " ";
                    }
                case TypeCell.Border:
                    { 
                        ConsoleColor color = ConsoleColor.White;
                        Console.BackgroundColor = color;    
                        return " ";
                    }
                case TypeCell.Food:
                    { 
                        ConsoleColor color = ConsoleColor.Red;
                        Console.BackgroundColor = color;
                        return " ";
                    }
                default:
                    break;
            }

            return "Error";
        }
        
    }
}
