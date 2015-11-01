using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;
using System.IO;

namespace ConsoleToDo
{
    /// <summary>
    /// Users database.
    /// </summary>
    static class UsersDatabase
    {
        static private List<User> users;

        /// <summary>
        /// Adds user.
        /// </summary>
        /// <param name="user">User.</param>
        /// <returns>Bool.</returns>
        static bool AddUser(User user)
        {
            foreach (var item in users )
            {
                if (user.Email == item.Email && user.ActivationCode == item.ActivationCode)
                    return false;
            }

            users.Add(user);
            return true;
        }

        /// <summary>
        /// Loads users.
        /// </summary>
        static public void LoadUsers()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            path = Path.Combine(path, "List.txt");
            users = new List<User>();

            if (File.Exists(path))
            {
                string jsonText = File.ReadAllText(path);
                users = JsonConvert.DeserializeObject<List<User>>(jsonText);

                if (users == null)
                {
                    users = new List<User>();
                }
            }

        }
    }
}
