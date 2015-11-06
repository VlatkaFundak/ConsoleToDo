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
        #region Public methods.

        /// <summary>
        /// Get command.
        /// </summary>
        /// <param name="userInput">User input.</param>
        /// <param name="currentScreen">Current screen.</param>
        /// <param name="userCommand">User command.</param>
        /// <returns>True if user has entered existing command, Screen that should be shown next.</returns>
        static public bool GetCommand(string userInput, Screen currentScreen, out UserCommand userCommand)
        {
            switch (userInput.ToLower())
            {
                case "register":
                    userCommand = UserCommand.GoToRegister;
                    return true;
                case "login":
                    userCommand = UserCommand.GoToLogin;
                    return true; 
                default:
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

            switch (userCommand)
            {
                case UserCommand.GoToRegister:
                    screen = Screen.Register;
                    UIPresenter.ShowScreen(screen);

                    if (RegisterProcess() == true)
                    {
                        screen = Screen.StartUp;
                    }
                    else 
                        screen = Screen.StartUp;
                    break;
                case UserCommand.GoToLogin:
                    screen = Screen.Login;
                    UIPresenter.ShowScreen(screen);

                    if (LogInProcess() == true)
                        screen = Screen.StartUp;
                    else
                        screen = Screen.StartUp;
                    break;
                case UserCommand.None:
                    break;
            }

            return screen;
        }

        #endregion

        #region Private methods

        /// <summary>
        /// Register process.
        /// </summary>
        /// <returns>True if user enteres correct input.</returns>
        static private bool RegisterProcess()
        {
            string uniqueCode = GetRandomCode();
            IOService.Print(Settings.inputEmail);
            string userInputEmail = Console.ReadLine();
            if (CheckBackOrExit(userInputEmail) == false)
                return false;

            IOService.Print(Settings.passwordInput);
            string userInputPassword = Console.ReadLine();
            if (CheckBackOrExit(userInputPassword) == false)
                return false;

            try
            {
                EmailService sendEmail = new EmailService();

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

            User user = new User(userInputEmail, userInputPassword, uniqueCode, toDoList );

            if (!UsersDatabase.AddUser(user))
            {
                Console.WriteLine("The user already exsits.");
                Console.ReadKey();
                return false;
            }

            return true;
        }

        /// <summary>
        /// Login process.
        /// </summary>
        /// <returns>True if user types the right input and is registered.</returns>
        static private bool LogInProcess()
        {
            bool isValid = true;

            do
            {
                IOService.Print(Settings.inputEmail);
                string userInputEmail = Console.ReadLine();

                IOService.Print(Settings.passwordInput);
                string userInputPassword = Console.ReadLine();

                if (UsersDatabase.LogInUser(userInputEmail, userInputPassword) == false)
                {
                    IOService.Print(Settings.wrongCredentials);
                    return false;
                }
                return true;

            }
            while (!isValid);
        }

        /// <summary>
        /// Gets random activation code.
        /// </summary>
        /// <returns>Activation code.</returns>
        static private string GetRandomCode()
        {
            Random randomNumbers = new Random();
            string activationCode = String.Empty;

            do
            {                
                int random = randomNumbers.Next(10000,99999);
                activationCode = random.ToString();  
            }
            while (UsersDatabase.ExistingActivationCode(activationCode));

            return activationCode;
        }        

        /// <summary>
        /// Back to start up screen or exit.
        /// </summary>
        /// <param name="userInput">User input.</param>
        /// <returns>True if user types back.</returns>
        static private bool CheckBackOrExit(string userInput)
        {
            if (userInput.ToLower() == "back")
                return true;
            else if (userInput.ToLower() == "exit")
            {
                Environment.Exit(-1);
                return false;
            }

            else
                return false;

        }

        #endregion
    }
}
