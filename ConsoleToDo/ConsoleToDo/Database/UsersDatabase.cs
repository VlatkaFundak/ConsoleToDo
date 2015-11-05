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
        /// <summary>
        /// Adds user.
        /// </summary>
        /// <param name="user">User.</param>
        /// <returns>True if there is no user with the same input.</returns>
        static public bool AddUser(User user)
        {
            foreach (var item in users )
            {
                if (user.Email == item.Email)
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

        /// <summary>
        /// Checks whether the input code is equal to code given in email.
        /// </summary>
        /// <param name="activationCode">Activation code.</param>
        /// <returns>True if entered code is equal to the given code.</returns>
        public static bool ExistingActivationCode(string activationCode)
        {
            foreach(var item in users)
            {
                if (item.ActivationCode == activationCode)
                    return false;
            }

            return true;
        }

        /// <summary>
        /// List of users.
        /// </summary>
        private static List<User> users;

        /// <summary>
        /// Updates database with new input.
        /// </summary>
        public static void UpdateDatabase()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            path = Path.Combine(path, "List.txt");
            users = new List<User>();

            string json = JsonConvert.SerializeObject(users);
            File.WriteAllText(path, json);
        }

    }
}
