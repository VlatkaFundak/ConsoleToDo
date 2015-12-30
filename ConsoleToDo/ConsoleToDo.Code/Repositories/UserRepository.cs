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
            return UsersDatabase.AddUser(user);            
        }

        /// <summary>
        /// Gets users.
        /// </summary>
        /// <returns>IEnumerable of the users.</returns>
        public static IEnumerable<User> GetUsers()
        {
            return UsersDatabase.GetUsers();
        }

        /// <summary>
        /// User login.
        /// </summary>
        /// <param name="email">Email.</param>
        /// <param name="password">Password.</param>
        /// <returns>True if there is existing user.</returns>
        public static bool LogInUser(string email, string password)
        {
            return UsersDatabase.LoginUser(email, password);
        }

        /// <summary>
        /// Gets loged in user.
        /// </summary>
        /// <returns>Loged user.</returns>
        public static User GetLogedInUser()
        {
            return UsersDatabase.GetLogedInUser();
        }        

        /// <summary>
        /// Loads users.
        /// </summary>
        public static void LoadUsers()
        {
            UsersDatabase.LoadUsers();
        }

        /// <summary>
        /// Adds todo.
        /// </summary>
        /// <param name="todo">Todo.</param>
        public static void AddToDo(ToDoItem todo)
        {
            User logedInUser = GetLogedInUser();
            logedInUser.TodoList.Add(todo);

            UsersDatabase.UpdateDatabase();
        }

        /// <summary>
        /// Removes todo.
        /// </summary>
        /// <param name="indexOfToDoInt">Index of todo.</param>
        public static void RemoveToDo(int indexOfToDoInt)
        {
            User logedInUser = GetLogedInUser();
            int j = 0;

            for (int i = 0; i < logedInUser.TodoList.Count; i++)
            {
                if (!logedInUser.TodoList[i].IsCompleted)
                {
                    if (j == indexOfToDoInt)
                    {
                        logedInUser.TodoList.RemoveAt(i);
                        break;
                    }
                    else
                        j++;
                }
            }

            UsersDatabase.UpdateDatabase();
        }

        /// <summary>
        /// Marks as complete todos.
        /// </summary>
        /// <param name="index">Index of todo.</param>
        public static void MarkAsComplete(int index)
        {
            User logedInUser = GetLogedInUser();
            int i = 0;
            foreach (var item in logedInUser.TodoList)
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

            UsersDatabase.UpdateDatabase();
        }

        /// <summary>
        /// Number of uncompleted todos.
        /// </summary>
        /// <returns>Number of uncompleted todos.</returns>
        public static int NumberOfUncompletedToDos()
        {
            User logedInUser = GetLogedInUser();
            int i = 0;
            foreach (var item in logedInUser.TodoList)
            {
                if (item.IsCompleted == false)
                    i++;
            }
            return i;
        }

        /// <summary>
        /// Checks whether the input code is equal to code given in email.
        /// </summary>
        /// <param name="activationCode">Activation code.</param>
        /// <returns>True if entered code is equal to the given code.</returns>
        public static bool ExistingActivationCode(string activationCode)
        {
            foreach (var item in GetUsers())
            {
                if (item.ActivationCode == activationCode)
                    return false;
            }

            return true;
        }
    }
}
