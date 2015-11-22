using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleToDo.Code
{
    /// <summary>
    /// User's repository.
    /// </summary>
    public static class UserRepository
    {
        /// <summary>
        /// Adds user.
        /// </summary>
        /// <param name="user">User.</param>
        /// <returns>True if there is no user with the same input.</returns>
        public static bool AddUser(User user)
        {
            foreach (var item in UsersDatabase.Users)
            {
                if (user.Email == item.Email)
                    return false;
            }

            UsersDatabase.Users.Add(user);
            UsersDatabase.LogedInUser = user;
            return true;
        }

        /// <summary>
        /// Log in user.
        /// </summary>
        /// <param name="email">Email of the user.</param>
        /// <param name="password">Password of the user.</param>
        /// <returns></returns>
        public static bool LogInUser(string email, string password)
        {
            foreach (var user in UsersDatabase.Users)
            {
                if (user.Email == email && user.Password == password)
                {
                    UsersDatabase.LogedInUser = user;
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Checks whether the input code is equal to code given in email.
        /// </summary>
        /// <param name="activationCode">Activation code.</param>
        /// <returns>True if entered code is equal to the given code.</returns>
        public static bool ExistingActivationCode(string activationCode)
        {
            foreach (var item in UsersDatabase.Users)
            {
                if (item.ActivationCode == activationCode)
                    return false;
            }

            return true;
        }

        /// <summary>
        /// Marks as complete todos.
        /// </summary>
        /// <param name="index">Index of todo.</param>
        public static void MarkAsComplete(int index)
        {
            int i = 0;
            foreach (var item in UsersDatabase.LogedInUser.TodoList)
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
        public static int NumberOfUncompletedToDos()
        {
            int i = 0;
            foreach (var item in UsersDatabase.LogedInUser.TodoList)
            {
                if (item.IsCompleted == false)
                    i++;
            }
            return i;
        }
    }
}
