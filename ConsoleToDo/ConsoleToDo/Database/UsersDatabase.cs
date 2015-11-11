using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;
using System.IO;
using Infrastructure;

namespace ConsoleToDo
{
    /// <summary>
    /// Users database.
    /// </summary>
    static class UsersDatabase
    {
        #region Fields

        /// <summary>
        /// List of users.
        /// </summary>
        static private List<User> users;

        #endregion

        #region Properties

        /// <summary>
        /// Loged in user.
        /// </summary>
        static public User LogedInUser { get; set; }

        #endregion

        #region Public methods

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
            LogedInUser = user;
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
        static public bool ExistingActivationCode(string activationCode)
        {
            foreach(var item in users)
            {
                if (item.ActivationCode == activationCode)
                    return false;
            }

            return true;
        }
        
        /// <summary>
        /// Updates database with new input.
        /// </summary>
        static public void UpdateDatabase()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            path = Path.Combine(path, "List.txt");
            //users = new List<User>();

            string json = JsonConvert.SerializeObject(users);
            File.WriteAllText(path, json);
        }

        /// <summary>
        /// Log in user.
        /// </summary>
        /// <param name="email">Email of the user.</param>
        /// <param name="password">Password of the user.</param>
        /// <returns></returns>
        static public bool LogInUser(string email, string password)
        {
            foreach(var user in users)
            {
                if(user.Email == email && user.Password == password)
                {
                    LogedInUser = user;
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Marks as complete todos.
        /// </summary>
        /// <param name="index">Index of todo.</param>
        static public void MarkAsComplete(int index)
        {
            int i = 0;
            foreach (var item in LogedInUser.TodoList)
            {
                if (item.IsCompleted == false)
                {
                    if (i == index)
                    {
                        item.IsCompleted = true;
                        break;
                    }
                    else
                    {
                        i++;
                    }
                }
            }
        }

        /// <summary>
        /// Number of uncompleted todos.
        /// </summary>
        /// <returns>Number of uncompleted todos.</returns>
        static public int NumberOfUncompletedToDos()
        {
            int i = 0;
            foreach (var item in LogedInUser.TodoList)
            {
                if (item.IsCompleted == false)
                    i++;
            }
            return i;
        }

        #endregion

    }
}
