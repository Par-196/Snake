using Snake.Model;
using Snake.Model.Enums;
using Snake.Services;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


namespace Snake
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();

            game.Users = UserJsonService.LoadUsers();

            try
            {
                bool exit = false;

                while (exit == false)
                {
                    Console.WriteLine("1.Log In\n" +
                    "2.Sign Up\n" +
                    "3.Exit");
                    Enum.TryParse(Console.ReadLine(), out LogOrSing logOrSing);
                    switch (logOrSing)
                    {
                        case LogOrSing.LogIn:
                            {
                                bool authorized = false;

                                Console.WriteLine("Enter your Login");
                                string userLogin = Console.ReadLine();
                                Console.WriteLine("Enter your Password");
                                string userPassword = Console.ReadLine();
                                authorized = game.LogIn(userLogin, userPassword);

                                if (authorized == true)
                                {
                                    Console.WriteLine("Enter Field height");
                                    int fieldHeight = int.Parse(Console.ReadLine());
                                    Console.WriteLine("Enter Field widht");
                                    int filedWidht = int.Parse(Console.ReadLine());
                                    
                                    game.StartGame(fieldHeight, filedWidht);
                                }
                            }
                            break;
                        case LogOrSing.SignUp:
                            {
                                Console.WriteLine("Enter your first name");
                                string firstName = Console.ReadLine();
                                Console.WriteLine("Enter your last name");
                                string lastName = Console.ReadLine();
                                Console.WriteLine("Enter your age");
                                int age = int.Parse(Console.ReadLine());
                                Console.WriteLine("Enter your Login");
                                string login = Console.ReadLine();
                                Console.WriteLine("Enter your Password");
                                string password = Console.ReadLine();

                                game.SignUp(firstName, lastName, age, login, password);
                            }
                            break;
                        case LogOrSing.Exit:
                            {
                                exit = true;
                                break;
                            }
                    }
                }
            }
            catch { }
            finally
            {
                Console.WriteLine("Saving of User...");
                UserJsonService.SaveUsers(game.Users);
            }
        }
    }
}
