using Newtonsoft.Json;
using Snake.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Snake.Services
{
    public class UserJsonService
    {
        public static void SaveUsers(List<User> user)
        {
            string json = JsonConvert.SerializeObject(user);

            using (Stream stream = new FileStream("users.json", FileMode.Create))
            {
                using (StreamWriter writer = new StreamWriter(stream, Encoding.UTF8))
                {
                    writer.Write(json);
                }
            }
        }
        public static List<User> LoadUsers()
        {
            string result = string.Empty;
            if (File.Exists("users.json"))
            {
                using (Stream stream = new FileStream("users.json", FileMode.Open))
                {
                    using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                    {
                        while (!reader.EndOfStream)
                        {
                            result += reader.ReadLine() + "\n";
                        }
                    }
                }
            }

            return !string.IsNullOrEmpty(result)
                ? JsonConvert.DeserializeObject<List<User>>(result)
                : new List<User>();
        }
    }
}
