using Snake.Model.Enums;
using Snake.Services;
using System;
using System.Collections.Generic;
using System.Threading;

namespace Snake.Model
{
    public class Game
    {
        public Field Field { get; set; }
        public List<User> Users { get; set; }

        public Game()
        {
        }

        public bool LogIn(string login, string password)
        {
            foreach (var item in Users)
            {
                if (item.Login == login && item.Password == password)
                {
                    Console.WriteLine("Ви успiшно авторизувались");
                    return true;
                }
                else
                {
                    Console.WriteLine("Вас немає в базi даних, авторизуйтесь");
                }
            }
            return false;
        }

        public void SignUp(string firstName, string lastName, int age, string login, string password)
        {
            if (Users.Count == 0)
            {
                User user = new User(firstName, lastName, age, login, password);
                Users.Add(user);
                Console.WriteLine("Saving of User...");
                UserJsonService.SaveUsers(Users);
            }
            foreach (var item in Users)
            {
                if (item.Login != login)
                {
                    User user = new User(firstName, lastName, age, login, password);
                    Users.Add(user);
                    Console.WriteLine("Saving of User...");
                    UserJsonService.SaveUsers(Users);
                }
                else if (item.Login == login)
                {
                    Console.WriteLine("This name not available");
                }
            }
        }

        public void StartGame(int fieldHeight, int filedWidht)
        {
            Field = new Field(new Cell[fieldHeight, filedWidht]);
 

            bool snakeAlive = true;
            int foodXPoint = 0;
            int foodYPoint = 0;
            bool didSnakeEatFood = false;

            while (snakeAlive)
            { 
                (foodXPoint, foodYPoint) = Field.SpawnFood(foodXPoint, foodYPoint);

                Field.ShowField();
                



                if (Console.KeyAvailable)
                {
                    ConsoleKey userInput = Console.ReadKey(true).Key;
                            
                    if ((userInput == ConsoleKey.W || userInput == ConsoleKey.UpArrow) && Field.Snake.Direction != SnakeDirection.Down)
                    {
                        Field.Snake.Direction = SnakeDirection.Up;
                    }
                    else if ((userInput == ConsoleKey.D || userInput == ConsoleKey.RightArrow) && Field.Snake.Direction != SnakeDirection.Left)
                    {
                        Field.Snake.Direction = SnakeDirection.Right;
                    }
                    else if ((userInput == ConsoleKey.S || userInput == ConsoleKey.DownArrow) && Field.Snake.Direction != SnakeDirection.Up)
                    {
                        Field.Snake.Direction = SnakeDirection.Down;
                    }
                    else if ((userInput == ConsoleKey.A || userInput == ConsoleKey.LeftArrow) && Field.Snake.Direction != SnakeDirection.Right)
                    {
                        Field.Snake.Direction = SnakeDirection.Left;
                    }
                }

                if (Field.DidSnakeDie() == true)
                {
                    snakeAlive = false;
                    Console.WriteLine("Game Over! Snake died.");
                    break;
                }


                switch (Field.Snake.Direction)
                {
                    case SnakeDirection.Up:
                        {
                            Field.Move(Field.Snake.Direction);
                        }
                        break;
                    case SnakeDirection.Right:
                        {
                            Field.Move(Field.Snake.Direction);
                        }
                        break;
                    case SnakeDirection.Down:
                        {
                            Field.Move(Field.Snake.Direction);
                        }
                        break;
                    case SnakeDirection.Left:
                        {
                            Field.Move(Field.Snake.Direction);
                        }
                        break;
                }

                

                didSnakeEatFood = Field.DidSnakeEatFood(foodXPoint, foodYPoint);

                Field.UpdateSnake(didSnakeEatFood);

                

                Thread.Sleep(100);
            }
        }

    }

}
