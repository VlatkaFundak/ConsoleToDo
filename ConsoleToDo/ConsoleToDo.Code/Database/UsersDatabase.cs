using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;
using System.IO;
using Infrastructure.Code;

namespace ConsoleToDo.Code
{
    /// <summary>
    /// Users database.
    /// </summary>
    public static class UsersDatabase
    {
        #region Fields

        /// <summary>
        /// Users.
        /// </summary>
        private static List<User> users;

        /// <summary>
        /// Loged in user.
        /// </summary>
        private static User logedInUser;

        #endregion

        #region Public methods

        /// <summary>
        /// Checks null user or no user and adds it.
        /// </summary>
        /// <param name="user">User.</param>
        /// <returns>True if there is no user with the same input or null user.</returns>
        public static bool AddUser(User user)
        {
            if (user != null)
            {
                foreach (var item in users)
                {
                    if (user.Email == item.Email)
                        return false;
                }

                users.Add(user);
                logedInUser = user;
                UpdateDatabase();
                return true;
            }

            return false;
        }

        /// <summary>
        /// Gets users.
        /// </summary>
        /// <returns>IEnumerable of users.</returns>
        public static IEnumerable<User> GetUsers()
        {
            IEnumerable<User> listOfUsers = (IEnumerable<User>)users;
            return listOfUsers;
        }

        /// <summary>
        /// User login.
        /// </summary>
        /// <param name="email">Email.</param>
        /// <param name="password">Password.</param>
        /// <returns>True if there is existing user.</returns>
        public static bool LoginUser(string email, string password)
        {
            foreach (var user in users)
            {
                if (user != null)
                {
                    if (user.Email == email && user.Password == password)
                    {
                        logedInUser = user;
                        UpdateDatabase();
                        return true;
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// Gets loged user.
        /// </summary>
        /// <returns>Loged user.</returns>
        public static User GetLogedInUser()
        {
            return logedInUser;
        }

        /// <summary>
        /// Updates database with new input.
        /// </summary>
        public static void UpdateDatabase()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            path = Path.Combine(path, "List.txt");
            //users = new List<User>();

            string json = JsonConvert.SerializeObject(users);
            File.WriteAllText(path, json);
        }

        /// <summary>
        /// Loads users.
        /// </summary>
        public static void LoadUsers()
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

        #endregion

    }
}
