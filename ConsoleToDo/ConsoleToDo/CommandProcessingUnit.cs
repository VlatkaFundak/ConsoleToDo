using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleToDo
{
    static class CommandProcessingUnit
    {
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
