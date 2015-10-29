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

        /// <summary>
        /// Process command.
        /// </summary>
        /// <param name="userCommand">User command.</param>
        /// <param name="currentScreen">Current screen.</param>
        /// <returns>Screen.</returns>
        static public Screen ProcessCommand(UserCommand userCommand, Screen currentScreen)
        {
            Screen screen = currentScreen;
            if (userCommand == UserCommand.GoToRegister)
            {
                screen = Screen.StartUp;
                UIPresenter.PrintRegisterScreen();
            }
            return screen;
        }
    }
}
