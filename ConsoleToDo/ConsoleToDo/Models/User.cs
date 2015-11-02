using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleToDo
{
    /// <summary>
    /// User model class.
    /// </summary>
    class User
    {
        #region Properties
        /// <summary>
        /// Email address of the user.
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Password of the user.
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// Activation code for registration.
        /// </summary>
        public string ActivationCode { get; set; }
        /// <summary>
        /// To do list.
        /// </summary>
        public List<ToDoItem> TodoList { get; set; }

        #endregion

        #region Constructor
        /// <summary>
        /// Constructor for the user.
        /// </summary>
        /// <param name="email">Users email.</param>
        /// <param name="password">Users password.</param>
        /// <param name="activationCode">Activation code for registration.</param>
        /// <param name="toDoList">To do list.</param>
        public User(string email, string password, string activationCode, List<ToDoItem> toDoList)
        {
            this.Email = email;
            this.ActivationCode = activationCode;
            this.Password = password;
            this.TodoList = toDoList;

        }

        #endregion

    }
}
