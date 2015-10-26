using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleToDo
{
    /// <summary>
    /// Command processing unit.
    /// </summary>
    static class CommandProcessingUnit
    {
        /// <summary>
        /// Get command.
        /// </summary>
        /// <param name="userInput">User input.</param>
        /// <param name="currentScreen">Current screen.</param>
        /// <param name="register">User command.</param>
        /// <returns>Bool.</returns>
        static public bool GetCommand(string userInput, Screen currentScreen, out UserCommand register)
        {
            if (userInput == "Register".ToLower())
            {
                register = UserCommand.GoToRegister;
                return true;
            }
            else
            {
                register = UserCommand.None;
                return false;
            }
        }
    }
}
