using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    /// <summary>
    /// Strings in the application.
    /// </summary>
    static class Settings
    {
        /// <summary>
        /// Title of the application.
        /// </summary>
        static public readonly string title = "Super ToDo Aplication";

        /// <summary>
        /// Start up message.
        /// </summary>
        static public readonly string startUpMessage = "Welcome and thank you for using our super cool application for managing todo lists. We really hope you will like it. Please log in or register using your email adress.";

        /// <summary>
        /// Log in message for further directions.
        /// </summary>
        static public readonly string toLogInMessage = "If you have an  account please enter command [Login] and press Enter.";

        /// <summary>
        /// Message for registration.
        /// </summary>
        static public readonly string toRegisterMessage = "You can create an account by entering keyword[Register] and press Enter.";

        /// <summary>
        /// Enter your choosing.
        /// </summary>
        static public readonly string enterYourCommand = "Please enter your command: ";

        /// <summary>
        /// Wrong command.
        /// </summary>
        static public readonly string wrongCommand = "You have entered wrong command, please try again.";

        /// <summary>
        /// Registration message.
        /// </summary>
        static public readonly string registrationMessage = "Thank you for registering. Please follow  the steps and you will be up in no time.";

        /// <summary>
        /// Registration email adress.
        /// </summary>
        static public readonly string inputEmail = "Input your email adress, type back to return, or exit:";

        /// <summary>
        /// Password for registration.
        /// </summary>
        static public readonly string passwordInput = "Input your password, type back to return, or exit:";

        /// <summary>
        /// Input activation code.
        /// </summary>
        static public readonly string activationCodeInput = "Please enter your activation code:";

        /// <summary>
        /// Login startup message.
        /// </summary>
        static public readonly string loginStartupMessage = "Enter your credentials to login.";

        /// <summary>
        /// Wrong credentials inputed.
        /// </summary>
        static public readonly string wrongCredentials = "Wrong credentials, please try again. Press any key to continue.";

        /// <summary>
        /// Commands for todo list.
        /// </summary>
        static public readonly string commandsForToDoList = "Commands: [Add]: add new todo, [Complete]: complete todo, [Remove]: remove todo, [History]: shows your completed todos";

        /// <summary>
        /// Adds new todo.
        /// </summary>
        static public readonly string addNewItemToList = "You are adding a new todo item, set the description and due date.";

        /// <summary>
        /// Input description of todo.
        /// </summary>
        static public readonly string inputDescriptionOfToDo = "Input a description for this todo:";

        /// <summary>
        /// Input due date of todo.
        /// </summary>
        static public readonly string inputDueDateOfToDo = "Input due date for this todo:";

        /// <summary>
        /// Index of todo to remove.
        /// </summary>
        static public readonly string removeToDo = "Index of todo to remove:";

        /// <summary>
        /// Index of todo to complete.
        /// </summary>
        static public readonly string completeToDo = "Index of todo to complete:";

        /// <summary>
        /// Items in history.
        /// </summary>
        static public readonly string historyToDo = "Items in history:";

        /// <summary>
        /// Email strings.
        /// </summary>
        static public class EmailSettings
        {
            /// <summary>
            /// Admin email.
            /// </summary>
            static public readonly string email = "vlatka.development@gmail.com";

            /// <summary>
            /// Admin password.
            /// </summary>
            static public readonly string password = "TestDevelop";

            /// <summary>
            /// Admin host.
            /// </summary>
            static public readonly string host = "smtp.gmail.com";

            /// <summary>
            /// Admin port number.
            /// </summary>
            static public readonly int portNumber = 587;

            /// <summary>
            /// Sending email for added todo.
            /// </summary>
            static public readonly string taskAddedEmail = "Task added, sending email...";

            /// <summary>
            /// Sending email for removed todo.
            /// </summary>
            static public readonly string removedTaskEmail = "Task removed. Sending email...";

            /// <summary>
            /// Sending email for completed todo.
            /// </summary>
            static public readonly string completedTaskEmail = "Task completed. Sending email...";

            /// <summary>
            /// Email not sent to user.
            /// </summary>
            static public readonly string sendEmailFail = "You have typed the wrong command. Please enter any key to return to startup screen:";
        }

    }
}

