using Newtonsoft.Json;
using Snake.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake.Model
{
    public class User
    {
        [JsonProperty("FirstName")]
        public string FirstName { get; set; }
        [JsonProperty("LastName")]
        public string LastName { get; set; }
        [JsonProperty("Age")]
        public int Age { get; set; }
        [JsonProperty("Login")]
        public string Login { get; set; }
        [JsonProperty("Password")]
        public string Password { get; set; }

        public User()
        {
        }

        public User(string firstName, string lastName, int age, string login, string password)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Login = login;
            Password = password;

        }
    }
}
