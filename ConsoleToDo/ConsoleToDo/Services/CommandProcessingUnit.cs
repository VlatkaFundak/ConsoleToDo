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
        /// <param name="userCommand">User command.</param>
        /// <returns>True if user has entered existing command, Screen that should be shown next.</returns>
        static public bool GetCommand(string userInput, Screen currentScreen, out UserCommand userCommand)
        {
            if (userInput == "Register".ToLower())
            {
                userCommand = UserCommand.GoToRegister;
                return true;
            }
            else
            {
                userCommand = UserCommand.None;
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
