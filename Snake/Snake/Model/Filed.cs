﻿using Snake.Model.Enums;
using System;
using System.Data.SqlTypes;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;

namespace Snake.Model
{
    public class Field
    {
        public Cell[,] Cells { get; set; }
        
        public Snake Snake { get; set; }

        public Field(Cell[,] cells) 
        {
            Random random = new Random();
            int snakeX = 0;
            int snakeY = 0;

            Cells = cells;

            for (int x = 0; x < Cells.GetLength(0); x++)
            {
                for (int y = 0; y < Cells.GetLength(1); y++)
                {
                    if (x == 0 || y == 0 || x + 1 == Cells.GetLength(0) || y + 1 == Cells.GetLength(1))
                    {
                        Cells[x, y] = new Cell(TypeCell.Border);
                    }
                    else
                    {
                        Cells[x, y] = new Cell(TypeCell.Empty);
                    }
                }
            }
            do
            {
                snakeX = random.Next(1, cells.GetLength(0) - 2);
                snakeY = random.Next(1, cells.GetLength(1) - 2);
            }
            while (Cells[snakeX, snakeY].Type != TypeCell.Empty);

            Snake = new Snake();

            Snake.Body.Enqueue(new Point(snakeX, snakeY));

            foreach (var item in Snake.Body)
            {
                if (item == Snake.Body.Peek())
                {
                    Cells[item.X, item.Y].Type = TypeCell.SnakeHead;
                    Console.SetCursorPosition(item.Y, item.X);
                    Console.Write(Cells[item.X, item.Y].ToString());
                    Console.ResetColor();
                }
                else 
                {
                    Cells[item.X, item.Y].Type = TypeCell.SnakeBody;
                    Console.SetCursorPosition(item.Y, item.X);
                    Console.Write(Cells[item.X, item.Y].ToString());
                    Console.ResetColor();
                }
            }
        }

        public void ShowField()
        {
            Console.SetWindowSize(Cells.GetLength(1), Cells.GetLength(0));
            for (int x = 0; x < Cells.GetLength(0); x++)
            {
                for (int y = 0; y < Cells.GetLength(1); y++)
                {
                    Console.Write(Cells[x ,y]);
                    Console.ResetColor();
                }
                Console.WriteLine();
            }
            Console.SetCursorPosition(0, 0);
        }


        public void Move(SnakeDirection snakeDirection)
        {
            switch (snakeDirection)
            {
                case SnakeDirection.Up:
                    {
                        Snake.Body.Enqueue(new Point(Snake.Body.Last().X - 1, Snake.Body.Last().Y));
                    }
                    break;
                case SnakeDirection.Right:
                    {
                        Snake.Body.Enqueue(new Point(Snake.Body.Last().X, Snake.Body.Last().Y + 1));
                    }
                    break;
                case SnakeDirection.Down:
                    {
                        Snake.Body.Enqueue(new Point(Snake.Body.Last().X + 1, Snake.Body.Last().Y));
                    }
                    break;
                case SnakeDirection.Left:
                    {
                        Snake.Body.Enqueue(new Point(Snake.Body.Last().X, Snake.Body.Last().Y - 1));
                    }
                    break;
            }
        }

        public (int, int) SpawnFood(bool didSnakeEatFood, int foodXPoint,int foodYPoint)
        {
            Random random = new Random();


            if (didSnakeEatFood == true)
            {
                do
                {
                    foodXPoint = random.Next(1, Cells.GetLength(0) - 2);
                    foodYPoint = random.Next(1, Cells.GetLength(0) - 2);
                }
                while (Cells[foodXPoint, foodYPoint].Type != TypeCell.Empty);


                Cells[foodXPoint, foodYPoint].Type = TypeCell.Food;
                Console.SetCursorPosition(foodYPoint, foodXPoint);
                Console.Write(Cells[foodXPoint, foodYPoint].ToString());
                Console.ResetColor();
                didSnakeEatFood = false;
                return (foodXPoint, foodYPoint);
            }
            return (foodXPoint, foodYPoint);
        }

        public bool DidSnakeEatFood(int foodXPoint, int foodYPoint)
        {
            var head = Snake.Body.Last();

            if (head.X == foodXPoint && head.Y == foodYPoint)
            {
                return true;
            }

            return false;
        }

        public bool DidSnakeDie()
        {
            if (Snake.Body.Last().X < 1 || Snake.Body.Last().Y < 1 || Snake.Body.Last().X > Cells.GetLength(0) - 2 || Snake.Body.Last().Y > Cells.GetLength(1) - 2)
            {
                Console.Clear();
                Console.SetCursorPosition(0, 0);
                Console.WriteLine("Ви в'єбались у стiну");
                return true;
            }
            foreach (var item in Snake.Body)
            {
                
                if ((Snake.Body.Last().X == item.X && Snake.Body.Last().Y == item.Y) && (item != Snake.Body.Last()))
                {
                    Console.Clear();
                    Console.SetCursorPosition(0, 0);
                    Console.WriteLine("Ви в'єбались у себе");
                    return true;
                }
            }
            
            return false;   
        }

        public void UpdateSnake(bool didSnakeEatFood)
        {
            
            if (didSnakeEatFood == false && Snake.Body.Count > 1)
            {
                var tail = Snake.Body.Peek();
                Cells[tail.X, tail.Y].Type = TypeCell.Empty;

                Console.SetCursorPosition(tail.Y, tail.X);
                Console.Write(Cells[tail.X, tail.Y].ToString());
                Console.ResetColor();

                Snake.Body.Dequeue();
            }

            foreach (var item in Snake.Body)
            {
                bool isHead = false;
                if (item == Snake.Body.Last())
                {
                    isHead = true;
                }
                var type = isHead ? TypeCell.SnakeHead : TypeCell.SnakeBody;
                Cells[item.X, item.Y].Type = type;
                Console.SetCursorPosition(item.Y, item.X);
                Console.Write(Cells[item.X, item.Y].ToString());
                Console.ResetColor();
            }
        }
    }
}
 