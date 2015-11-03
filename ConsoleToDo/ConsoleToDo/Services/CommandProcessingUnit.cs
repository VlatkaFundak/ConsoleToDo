using Infrastructure;
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
        /// Process inputed command, login or register.
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

        /// <summary>
        /// Register process.
        /// </summary>
        /// <returns>True if user enteres correct input.</returns>
        static private bool RegisterProcess()
        {
            string uniqueCode = GetRandomCode();
            IOService.Print(Settings.registrationInput);
            string userInputEmail = Console.ReadLine();

            IOService.Print(Settings.passwordInput);
            string userInputPassword = Console.ReadLine();

            EmailService sendEmail = new EmailService();

            try
            {
                sendEmail.SendEmail("vlatkaf@gmail.com", userInputEmail, "logika5", "smtp.gmail.com", 587, "Activation code for registering",
                    "Please enter this activation code for further registration:" + uniqueCode);
            }
            catch (Exception)
            {
                IOService.Print(Settings.sendEmailFail);
                Console.ReadKey();
                return false;
            }

            IOService.Print(Settings.activationCodeInput);

            bool isValid = false;

            do
            {
                string enterActivationCode = Console.ReadLine();
                if (!enterActivationCode.Equals(uniqueCode))
                {
                    IOService.Print(Settings.wrongCommand + enterActivationCode);
                    isValid = false;
                }
                else
                {
                    isValid = true;
                }

            } while (!isValid);

            List<ToDoItem> toDoList = new List<ToDoItem>();

            User userInputs = new User(userInputEmail, userInputPassword, uniqueCode, toDoList );

            if (!UsersDatabase.AddUser(userInputs))
            {
                Console.WriteLine("The user already exsits.");
                Console.ReadKey();
                return false;
            }

            return true;
        }

        /// <summary>
        /// Gets random activation code.
        /// </summary>
        /// <returns>Activation code.</returns>
        static private string GetRandomCode()
        {
            Random randomNumbers = new Random();

            do
            {
                string activationCode = String.Empty;
                int random = randomNumbers.Next(10000,99999);
                activationCode = random.ToString();

                UsersDatabase.ExistingActivationCode(activationCode);

                return activationCode;

            } while (true);
        }
        
    }
}
