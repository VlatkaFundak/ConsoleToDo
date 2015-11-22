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
        #region Properties

        /// <summary>
        /// List of users.
        /// </summary>
        public static List<User> Users { get; set; }

        /// <summary>
        /// Loged in user.
        /// </summary>
        public static User LogedInUser { get; set; }

        #endregion

        #region Public methods

        /// <summary>
        /// Updates database with new input.
        /// </summary>
        public static void UpdateDatabase()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            path = Path.Combine(path, "List.txt");
            //users = new List<User>();

            string json = JsonConvert.SerializeObject(Users);
            File.WriteAllText(path, json);
        }

        /// <summary>
        /// Loads users.
        /// </summary>
        public static void LoadUsers()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            path = Path.Combine(path, "List.txt");
            Users = new List<User>();

            if (File.Exists(path))
            {
                string jsonText = File.ReadAllText(path);
                Users = JsonConvert.DeserializeObject<List<User>>(jsonText);

                if (Users == null)
                {
                    Users = new List<User>();
                }
            }
        }

        #endregion

    }
}
