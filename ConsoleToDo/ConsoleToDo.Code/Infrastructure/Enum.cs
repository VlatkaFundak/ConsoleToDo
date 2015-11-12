using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleToDo.Code
{
    /// <summary>
    /// Enum startup screen.
    /// </summary>
    public enum Screen
    {
        /// <summary>
        /// Go to startup screen.
        /// </summary>
        StartUp,

        /// <summary>
        /// Go to register screen.
        /// </summary>
        Register,

        /// <summary>
        /// Go to login screen.
        /// </summary>
        Login,

        /// <summary>
        /// User profile (todo list) screen.
        /// </summary>
        UserProfile,

        /// <summary>
        /// Go to add to do screen.
        /// </summary>
        AddToDoScreen,

        /// <summary>
        /// Shows history.
        /// </summary>
        HistoryScreen
    }

    /// <summary>
    /// Enum user commands.
    /// </summary>
    public enum UserCommand
    {
        /// <summary>
        /// Go to register command.
        /// </summary>
        GoToRegister,

        /// <summary>
        /// Go to login command.
        /// </summary>
        GoToLogin,

        /// <summary>
        /// Adds todo.
        /// </summary>
        AddToDo,

        /// <summary>
        /// Removes todo.
        /// </summary>
        RemoveToDo,

        /// <summary>
        /// Completes todo.
        /// </summary>
        CompleteToDo,

        /// <summary>
        /// Completed todos.
        /// </summary>
        HistoryToDo,

        /// <summary>
        /// Do nothing.
        /// </summary>
        None
    }
}
