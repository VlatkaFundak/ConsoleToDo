using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Code
{
    /// <summary>
    /// Strings in the application.
    /// </summary>
    public class Resources
    {
        /// <summary>
        /// Title of the application.
        /// </summary>
        public const string title = "Super ToDo Aplication";

        /// <summary>
        /// Start up message.
        /// </summary>
        public const string startUpMessage = "Welcome and thank you for using our super cool application for managing todo lists. We really hope you will like it. Please log in or register using your email adress.";

        /// <summary>
        /// Log in message for further directions.
        /// </summary>
        public const string toLogInMessage = "If you have an  account please enter command [Login] and press Enter.";

        /// <summary>
        /// Message for registration.
        /// </summary>
        public const string toRegisterMessage = "You can create an account by entering keyword[Register] and press Enter.";

        /// <summary>
        /// Enter your choosing.
        /// </summary>
        public const string enterYourCommand = "Please enter your command: ";

        /// <summary>
        /// Wrong command.
        /// </summary>
        public const string wrongCommand = "You have entered wrong command, please try again.";

        /// <summary>
        /// Registration message.
        /// </summary>
        public const string registrationMessage = "Thank you for registering. Please follow  the steps and you will be up in no time.";

        /// <summary>
        /// Registration email adress.
        /// </summary>
        public const string inputEmail = "Input your email adress, type back to return, or exit:";

        /// <summary>
        /// Password for registration.
        /// </summary>
        public const string passwordInput = "Input your password, type back to return, or exit:";

        /// <summary>
        /// Input activation code.
        /// </summary>
        public const string activationCodeInput = "Please enter your activation code:";

        /// <summary>
        /// Login startup message.
        /// </summary>
        public const string loginStartupMessage = "Enter your credentials to login.";

        /// <summary>
        /// Wrong credentials inputed.
        /// </summary>
        public const string wrongCredentials = "Wrong credentials, please try again. Press any key to continue.";

        /// <summary>
        /// Commands for todo list.
        /// </summary>
        public const string commandsForToDoList = "Commands: [Add]: add new todo, [Complete]: complete todo, [Remove]: remove todo, [History]: shows your completed todos";

        /// <summary>
        /// Adds new todo.
        /// </summary>
        public const string addNewItemToList = "You are adding a new todo item, set the description and due date.";

        /// <summary>
        /// Input description of todo.
        /// </summary>
        public const string inputDescriptionOfToDo = "Input a description for this todo:";

        /// <summary>
        /// Input due date of todo.
        /// </summary>
        public const string inputDueDateOfToDo = "Input due date for this todo:";

        /// <summary>
        /// Index of todo to remove.
        /// </summary>
        public const string removeToDo = "Index of todo to remove:";

        /// <summary>
        /// Index of todo to complete.
        /// </summary>
        public const string completeToDo = "Index of todo to complete:";

        /// <summary>
        /// Items in history.
        /// </summary>
        public const string historyToDo = "Items in history:";

        /// <summary>
        /// Email strings.
        /// </summary>
        public class EmailResources
        {
            /// <summary>
            /// Sending email for added todo.
            /// </summary>
            public const string taskAddedEmail = "Task added, sending email...";

            /// <summary>
            /// Sending email for removed todo.
            /// </summary>
            public const string removedTaskEmail = "Task removed. Sending email...";

            /// <summary>
            /// Sending email for completed todo.
            /// </summary>
            public const string completedTaskEmail = "Task completed. Sending email...";

            /// <summary>
            /// Email not sent to user.
            /// </summary>
            public const string sendEmailFail = "You have typed the wrong command. Please enter any key to return to startup screen:";
        }

    }
}

