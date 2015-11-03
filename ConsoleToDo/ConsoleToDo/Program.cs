using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Infrastructure;

namespace ConsoleToDo
{
    /// <summary>
    /// Program class.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            InitialSetup();

            var currentScreen = Screen.StartUp;
            var userCommand = UserCommand.None;
            bool isRunning = true;

            UIPresenter.ShowScreen(currentScreen);

            while (isRunning)
            {
                string userInput = String.Empty;
                bool isValid = true;
                do
                {
                    if (isValid)
                    {
                        IOService.Print(Settings.enterYourCommand);
                    }
                    else
                    {
                        IOService.Print(Settings.wrongCommand);

                    }

                    userInput = Console.ReadLine();
                    isValid = CommandProcessingUnit.GetCommand(userInput, currentScreen, out userCommand);

                } while (!isValid);

                CommandProcessingUnit.ProcessCommand(userCommand, currentScreen);

                Console.ReadLine();

                isRunning = false;

                UIPresenter.ShowScreen(currentScreen);

            }

            Console.ReadKey();
        }

        #region Private methods.

        /// <summary>
        /// Initial setup.
        /// </summary>
        private static void InitialSetup()
        {
            Console.SetWindowSize(Console.LargestWindowWidth - 40, Console.LargestWindowHeight - 20);
            Console.ForegroundColor = ConsoleColor.Green;

            Console.BackgroundColor = ConsoleColor.DarkGray;

            UsersDatabase.LoadUsers();
        }

        #endregion
    }
}
