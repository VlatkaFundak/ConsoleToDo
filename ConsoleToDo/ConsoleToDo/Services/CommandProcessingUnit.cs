﻿using Infrastructure;
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
                case "add":
                    if (currentScreen == Screen.UserProfile)
                    {
                        userCommand = UserCommand.AddToDo;
                        return true;
                    }
                    else
                    {
                        IOService.Print(Settings.wrongCommand);
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
                        IOService.Print(Settings.wrongCommand);
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
        static public bool CheckBackOrExit(string userInput)
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

                    if (LogInProcess() == true)
                        screen = Screen.UserProfile;
                    else
                        screen = Screen.StartUp;
                    break;
                case UserCommand.AddToDo:
                    screen = Screen.AddToDoScreen;
                    UIPresenter.ShowScreen(screen);

                    if (AddToList() == true)
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

            List<ToDoItem> toDoList = new List<ToDoItem>();

            User user = new User(userInputEmail, userInputPassword, uniqueCode, toDoList);

            if (UsersDatabase.AddUser(user) == false)
            {
                Console.WriteLine("The user already exsits. Press any key to go back to startup screen.");
                Console.ReadKey();
                return false;
            }

            try
            {
                EmailService sendEmail = new EmailService();

                sendEmail.SendEmail(EmailSettings.email, userInputEmail, EmailSettings.password, EmailSettings.host, EmailSettings.portNumber,
                    "Activation code for registering", "Please enter this activation code for further registration:" + uniqueCode);
            }
            catch (Exception)
            {
                IOService.Print(EmailSettings.sendEmailFail);
                Console.ReadKey();
                return false;
            }

            IOService.Print(Settings.activationCodeInput);

            bool isValid = false;

            do
            {
                string enterActivationCode = Console.ReadLine();
                if (CheckBackOrExit(enterActivationCode) == false)
                {
                    isValid = false;
                }                
                else if (enterActivationCode.Equals(uniqueCode) == false)
                {
                    IOService.Print(Settings.wrongCommand + enterActivationCode);
                    isValid = false;
                }
                else
                {
                    isValid = true;
                }

            } while (!isValid);

            UsersDatabase.UpdateDatabase();

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
                if (CheckBackOrExit(userInputEmail) == false)
                    return false;

                IOService.Print(Settings.passwordInput);
                string userInputPassword = Console.ReadLine();
                if (CheckBackOrExit(userInputPassword) == false)
                    return false;

                if (UsersDatabase.LogInUser(userInputEmail, userInputPassword) == false)
                {
                    IOService.Print(Settings.wrongCredentials);
                    Console.ReadKey();
                    return false;
                }

                UsersDatabase.UpdateDatabase();

                return true;
            }
            while (!isValid);
        }
        
        /// <summary>
        /// Adds item to the list.
        /// </summary>
        /// <returns>True if successfully added to the list.</returns>
        static private bool AddToList()
        {
            IOService.Print(Settings.inputDescriptionOfToDo, 1);
            string descriptionOfTheToDo = Console.ReadLine();
            if (CheckBackOrExit(descriptionOfTheToDo) == false)
                return false;

            IOService.Print(Settings.inputDueDateOfToDo);
            string dueDate = Console.ReadLine();
            if (CheckBackOrExit(dueDate) == false)
                return false;

            IOService.Print(EmailSettings.taskAddedEmail);

            UsersDatabase.LogedInUser.TodoList.Add(new ToDoItem(descriptionOfTheToDo, dueDate, false));
                        
            EmailService sendEmail = new EmailService();

            try
            {
                sendEmail.SendEmail(EmailSettings.email, UsersDatabase.LogedInUser.Email, EmailSettings.password, EmailSettings.host, EmailSettings.portNumber,
                    "To do task", "To do description:\n" + descriptionOfTheToDo + "Due date of to do:\n" + dueDate);
            }
            catch (Exception)
            {
                IOService.Print(EmailSettings.sendEmailFail);
                Console.ReadKey();
                return false;
            }

            UsersDatabase.UpdateDatabase();
            return true;
        }

        /// <summary>
        /// Removes item from the list.
        /// </summary>
        /// <returns>True if successfully removed from the list.</returns>
        static private bool RemoveToDo()
        {
            IOService.Print(Settings.removeToDo);

            int indexOfToDoInt = 0;
            bool isValid = true;

            do
            {
                string indexOfToDo = Console.ReadLine();

                if (CheckBackOrExit(indexOfToDo) == false)
                    return false;
                else if (!Int32.TryParse(indexOfToDo, out indexOfToDoInt))
                {
                    IOService.Print(Settings.wrongCommand);
                    isValid = false;
                }
                else if (indexOfToDoInt - 1 > UsersDatabase.LogedInUser.TodoList.Count || indexOfToDoInt < 1)
                {
                    IOService.Print(Settings.wrongCommand);
                    isValid = false;
                }
                else
                {
                    indexOfToDoInt -= 1;
                    isValid = true;
                }

            } while (!isValid);

            IOService.Print(EmailSettings.removedTaskEmail);

            EmailService sendEmail = new EmailService();
            try
            {
                sendEmail.SendEmail(EmailSettings.email, UsersDatabase.LogedInUser.Email, EmailSettings.password, EmailSettings.host, EmailSettings.portNumber,
                    "Removed task", "To do task removed:\n" + UsersDatabase.LogedInUser.TodoList[indexOfToDoInt].Description);
            }
            catch (Exception)
            {
                IOService.Print(EmailSettings.sendEmailFail);
                Console.ReadKey();
                return false;
            }

            if (UsersDatabase.LogedInUser.TodoList[indexOfToDoInt].IsCompleted == false)
                UsersDatabase.LogedInUser.TodoList.RemoveAt(indexOfToDoInt);

            UsersDatabase.UpdateDatabase();

            return true;
        }

        /// <summary>
        /// Completes item from the list.
        /// </summary>
        /// <returns>True if successfully comlpleted item.</returns>
        static private bool CompleteToDo()
        {
            IOService.Print(Settings.completeToDo);

            int indexOfToDoInt = 0;
            bool isValid = true;

            do
            {
                string indexOfToDo = Console.ReadLine();
                if (CheckBackOrExit(indexOfToDo) == false)
                    return false;

                if (!Int32.TryParse(indexOfToDo, out indexOfToDoInt))
                {
                    IOService.Print(Settings.wrongCommand);
                    isValid = false;
                }
                else if (indexOfToDoInt - 1 > UsersDatabase.LogedInUser.TodoList.Count || indexOfToDoInt < 1)
                {
                    IOService.Print(Settings.wrongCommand);
                    isValid = false;
                }
                else
                    isValid = true;

            } while (!isValid);

            EmailService sendEmail = new EmailService();
            try
            {
                sendEmail.SendEmail(EmailSettings.email, UsersDatabase.LogedInUser.Email, EmailSettings.password, EmailSettings.host, EmailSettings.portNumber,
                    "Completed task", "To do task completed:\n" + UsersDatabase.LogedInUser.TodoList[indexOfToDoInt - 1].Description);
            }
            catch (Exception)
            {
                IOService.Print(EmailSettings.sendEmailFail);
                Console.ReadKey();
                return false;
            }

            UsersDatabase.MarkAsComplete(indexOfToDoInt - 1);

            UsersDatabase.UpdateDatabase();

            return true;
        }

        /// <summary>
        /// List of completed items.
        /// </summary>
        static private void History()
        {
            int i = 1;
            foreach (var item in UsersDatabase.LogedInUser.TodoList)
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
        static private string GetRandomCode()
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
