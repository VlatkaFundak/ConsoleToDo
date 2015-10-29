using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            do
            {
                string userInput = String.Empty;
                bool isValid = true;
                do
                {
                    if (isValid)
                    {
                        IOService.Print("Please enter your command: ");
                    }
                    else
                    {
                        IOService.Print("You have entered wrong command, please try again.");

                    }

                    userInput = Console.ReadLine();
                    isValid = CommandProcessingUnit.GetCommand(userInput, currentScreen, out userCommand);

                } while (!isValid);

                CommandProcessingUnit.ProcessCommand(userCommand, currentScreen);

                Console.ReadLine();

                isRunning = false;

                UIPresenter.ShowScreen(currentScreen);

            } while (isRunning);

            Console.ReadKey();
        }

        /// <summary>
        /// Sets the size of the console.
        /// </summary>
        private static void InitialSetup()
        {
            Console.SetWindowSize(Console.LargestWindowWidth - 40, Console.LargestWindowHeight - 20);
            Console.ForegroundColor = ConsoleColor.Magenta;
        }
    }
}
