using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleToDo
{
    /// <summary>
    /// Enum startup screen.
    /// </summary>
    enum Screen
    {
        /// <summary>
        /// Go to startup screen.
        /// </summary>
        StartUp,

        /// <summary>
        /// Go to register screen.
        /// </summary>
        Register
    }

    /// <summary>
    /// Enum user commands.
    /// </summary>
    enum UserCommand
    {
        /// <summary>
        /// Go to register command.
        /// </summary>
        GoToRegister,

        /// <summary>
        /// Do nothing.
        /// </summary>
        None
    }
}
