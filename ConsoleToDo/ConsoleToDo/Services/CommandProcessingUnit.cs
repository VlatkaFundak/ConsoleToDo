using Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ConsoleToDo.Code;
using Infrastructure.Code;
using System.Net.Mail;

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
        public static bool GetCommand(string userInput, Screen currentScreen, out UserCommand userCommand)
        {
            switch (userInput.ToLower())
            {
                case "register":
                    userCommand = UserCommand.GoToRegister;
                    return true;
                case "login":
                    userCommand = UserCommand.GoToLogin;
                    return true;
                case "add":
                    if (currentScreen == Screen.UserProfile)
                    {
                        userCommand = UserCommand.AddToDo;
                        return true;
                    }
                    else
                    {
                        IOService.Print(Resources.wrongCommand);
                        userCommand = UserCommand.None;
                        return false;
                    }
                case "remove":
                    if (currentScreen == Screen.UserProfile)
                    {
                        userCommand = UserCommand.RemoveToDo;
                        return true;
                    }
                    else
                    {
                        userCommand = UserCommand.None;
                        return false;
                    }
                case "complete":
                    if(currentScreen == Screen.UserProfile)
                    {
                        userCommand = UserCommand.CompleteToDo;
                        return true;
                    }
                    else
                    {
                        userCommand = UserCommand.None;
                        return false;
                    }
                case "history":
                    if (currentScreen == Screen.UserProfile)
                    {
                        userCommand = UserCommand.HistoryToDo;
                        return true;
                    }
                    else
                    {
                        userCommand = UserCommand.None;
                        return false;
                    }
                case "back":
                    if (currentScreen == Screen.UserProfile)
                    {
                        userCommand = UserCommand.GoToLogin;
                        return true;
                    }
                    else
                    {
                        IOService.Print(Resources.wrongCommand);
                        userCommand = UserCommand.None;
                        return false;
                    }
                case "exit":
                    userCommand = UserCommand.None;
                    Environment.Exit(-1);
                    return false;
                default:
                    userCommand = UserCommand.None;
                    return false;
            }
        }

        /// <summary>
        /// Back to start up screen or exit.
        /// </summary>
        /// <param name="userInput">User input.</param>
        /// <returns>True if user types back.</returns>
        public static bool CheckBackOrExit(string userInput)
        {
            switch (userInput.ToLower())
            {
                case "back":
                    return false;
                case "exit":
                    Environment.Exit(-1);
                    return false;
                default:
                    return true;
            }
        }

        /// <summary>
        /// Process inputed command.
        /// </summary>
        /// <param name="userCommand">User command.</param>
        /// <param name="currentScreen">Current screen.</param>
        /// <returns>Screen.</returns>
        public static Screen ProcessCommand(UserCommand userCommand, Screen currentScreen)
        {            
            Screen screen = currentScreen;

            switch (userCommand)
            {
                case UserCommand.GoToRegister:
                    screen = Screen.Register;
                    UIPresenter.ShowScreen(screen);

                    if (RegisterProcess())
                    {
                        screen = Screen.UserProfile;
                        UIPresenter.ShowScreen(screen);
                    }
                    else
                    {
                        screen = Screen.StartUp;
                        UIPresenter.ShowScreen(screen);
                    }
                    break;
                case UserCommand.GoToLogin:
                    screen = Screen.Login;
                    UIPresenter.ShowScreen(screen);

                    if (LogInProcess())
                        screen = Screen.UserProfile;
                    else
                        screen = Screen.StartUp;
                    break;
                case UserCommand.AddToDo:
                    screen = Screen.AddToDoScreen;
                    UIPresenter.ShowScreen(screen);

                    if (AddToList())
                        screen = Screen.UserProfile;
                    else
                        screen = Screen.UserProfile;
                    break;
                case UserCommand.RemoveToDo:
                    RemoveToDo();
                    screen = Screen.UserProfile;
                    break;
                case UserCommand.CompleteToDo:
                    CompleteToDo();
                    screen = Screen.UserProfile;
                    break;
                case UserCommand.HistoryToDo:
                    screen = Screen.HistoryScreen;
                    UIPresenter.ShowScreen(screen);
                    History();
                    screen = Screen.UserProfile;
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
        static bool RegisterProcess()
        {
            string uniqueCode = GetRandomCode();
            IOService.Print(Resources.inputEmail);
            string userInputEmail = Console.ReadLine();
            if (!CheckBackOrExit(userInputEmail))
                return false;

            IOService.Print(Resources.passwordInput);
            string userInputPassword = Console.ReadLine();
            if (!CheckBackOrExit(userInputPassword))
                return false;

            List<ToDoItem> toDoList = new List<ToDoItem>();

            User user = new User(userInputEmail, userInputPassword, uniqueCode, toDoList);

            if (!UserRepository.AddUser(user))
            {
                Console.WriteLine("The user already exsits. Press any key to go back to startup screen.");
                Console.ReadKey();
                return false;
            }           

            try
            {
                IEmailService sendEmail = new EmailService();
                MailMessage mail = new MailMessage(EmailSettings.email, userInputEmail, "Activation code for registering", 
                    "Please enter this activation code for further registration:" + uniqueCode);

                sendEmail.SendEmail(mail);

            }
            catch (Exception)
            {
                IOService.Print(Resources.EmailResources.sendEmailFail);
                Console.ReadKey();
                return false;
            }

            IOService.Print(Resources.activationCodeInput);

            bool isValid = false;

            do
            {
                string enterActivationCode = Console.ReadLine();
                if (!CheckBackOrExit(enterActivationCode))
                {
                    isValid = false;
                }                
                else if (!enterActivationCode.Equals(uniqueCode))
                {
                    IOService.Print(Resources.wrongCommand + enterActivationCode);
                    isValid = false;
                }
                else
                {
                    isValid = true;
                }

            } while (!isValid);

            return true;
        }

        /// <summary>
        /// Login process.
        /// </summary>
        /// <returns>True if user types the right input and is registered.</returns>
        static bool LogInProcess()
        {
            bool isValid = true;

            do
            {
                IOService.Print(Resources.inputEmail);
                string userInputEmail = Console.ReadLine();
                if (!CheckBackOrExit(userInputEmail))
                    return false;

                IOService.Print(Resources.passwordInput);
                string userInputPassword = Console.ReadLine();
                if (!CheckBackOrExit(userInputPassword))
                    return false;

                if (!UserRepository.LogInUser(userInputEmail, userInputPassword))
                {
                    IOService.Print(Resources.wrongCredentials);
                    Console.ReadKey();
                    return false;
                }
            }

            while (!isValid);

            return true;
        }
        
        /// <summary>
        /// Adds item to the list.
        /// </summary>
        /// <returns>True if successfully added to the list.</returns>
        static bool AddToList()
        {
            User logedInUser = UserRepository.GetLogedInUser();
            IOService.Print(Resources.inputDescriptionOfToDo, 1);
            string descriptionOfTheToDo = Console.ReadLine();
            if (!CheckBackOrExit(descriptionOfTheToDo))
                return false;

            IOService.Print(Resources.inputDueDateOfToDo);
            string dueDate = Console.ReadLine();
            if (!CheckBackOrExit(dueDate))
                return false;

            IOService.Print(Resources.EmailResources.taskAddedEmail);

            UserRepository.AddToDo(new ToDoItem(descriptionOfTheToDo, dueDate, false));

            IEmailService sendEmail = new EmailService();

            MailMessage mail = new MailMessage(EmailSettings.email, logedInUser.Email, "To do task", "To do description:\n"
                    + descriptionOfTheToDo + "Due date of to do:\n" + dueDate);

            try
            {
                sendEmail.SendEmail(mail);
            }
            catch (Exception)
            {
                IOService.Print(Resources.EmailResources.sendEmailFail);
                Console.ReadKey();
                return false;
            }

            return true;
        }

        /// <summary>
        /// Removes item from the list.
        /// </summary>
        /// <returns>True if successfully removed from the list.</returns>
        static bool RemoveToDo()
        {
            User logedInUser = UserRepository.GetLogedInUser();           
            IOService.Print(Resources.removeToDo);

            int indexOfToDoInt = 0;
            bool isValid = true;

            do
            {
                string indexOfToDo = Console.ReadLine();

                if (!CheckBackOrExit(indexOfToDo))
                    return false;
                else if (!Int32.TryParse(indexOfToDo, out indexOfToDoInt))
                {
                    IOService.Print(Resources.wrongCommand);
                    isValid = false;
                }
                else if (indexOfToDoInt - 1 > logedInUser.TodoList.Count || indexOfToDoInt < 1)
                {
                    IOService.Print(Resources.wrongCommand);
                    isValid = false;
                }
                else
                {
                    isValid = true;
                }

            } while (!isValid);

            IOService.Print(Resources.EmailResources.removedTaskEmail);

            IEmailService sendEmail = new EmailService();
            MailMessage mail = new MailMessage(EmailSettings.email, logedInUser.Email, "Removed task",
                "To do task removed:\n" + logedInUser.TodoList[indexOfToDoInt - 1].Description);

            try
            {
                sendEmail.SendEmail(mail);
            }
            catch (Exception)
            {
                IOService.Print(Resources.EmailResources.sendEmailFail);
                Console.ReadKey();
                return false;
            }

            indexOfToDoInt -= 1;

            UserRepository.RemoveToDo(indexOfToDoInt);

            return true;
        }

        /// <summary>
        /// Completes item from the list.
        /// </summary>
        /// <returns>True if successfully comlpleted item.</returns>
        static bool CompleteToDo()
        {
            User logedInUser = UserRepository.GetLogedInUser();
            IOService.Print(Resources.completeToDo);

            int indexOfToDoInt = 0;
            bool isValid = true;

            do
            {
                string indexOfToDo = Console.ReadLine();
                if (!CheckBackOrExit(indexOfToDo))
                    return false;

                if (!Int32.TryParse(indexOfToDo, out indexOfToDoInt))
                {
                    IOService.Print(Resources.wrongCommand);
                    isValid = false;
                }
                else if (indexOfToDoInt - 1 > logedInUser.TodoList.Count || indexOfToDoInt < 1)
                {
                    IOService.Print(Resources.wrongCommand);
                    isValid = false;
                }
                else
                    isValid = true;

            } while (!isValid);

            IEmailService sendEmail = new EmailService();
            MailMessage mail = new MailMessage(EmailSettings.email, logedInUser.Email, "Completed task", 
                "To do task completed:\n" + logedInUser.TodoList[indexOfToDoInt - 1].Description);
            try
            {
                sendEmail.SendEmail(mail);
            }
            catch (Exception)
            {
                IOService.Print(Resources.EmailResources.sendEmailFail);
                Console.ReadKey();
                return false;
            }

            UserRepository.MarkAsComplete(indexOfToDoInt - 1);

            return true;
        }

        /// <summary>
        /// List of completed items.
        /// </summary>
        static void History()
        {
            User logedInUser = UserRepository.GetLogedInUser();

            int i = 1;
            foreach (var item in logedInUser.TodoList)
            {
                if (item.IsCompleted == true)
                {
                    Console.WriteLine("{0}.\nDescription: {1}\nDue date: {2}\n", i, item.Description, item.DueDate);
                    i++;
                }
            }
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }

        /// <summary>
        /// Gets random activation code.
        /// </summary>
        /// <returns>Activation code.</returns>
        static string GetRandomCode()
        {
            Random randomNumbers = new Random();
            string activationCode = String.Empty;
              
            int random = randomNumbers.Next(10000,99999);
            activationCode = random.ToString();  

            return activationCode;
        }

        #endregion
    }
}
