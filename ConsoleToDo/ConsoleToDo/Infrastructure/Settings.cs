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
        public static readonly string title = "Super ToDo Aplication";

        /// <summary>
        /// Start up message.
        /// </summary>
        public static readonly string startUpMessage = "Welcome and thank you for using our super cool application for managing todo lists. We really hope you will like it. Please log in or register using your email adress.";

        /// <summary>
        /// Log in message for further directions.
        /// </summary>
        public static readonly string toLogInMessage = "If you have an  account please enter command [Login] and press Enter.";

        /// <summary>
        /// Message for registration.
        /// </summary>
        public static readonly string toRegisterMessage = "You can create an account by entering keyword[Register] and press Enter.";

        /// <summary>
        /// Enter your choosing.
        /// </summary>
        public static readonly string enterYourCommand = "Please enter your command: ";

        /// <summary>
        /// Wrong command.
        /// </summary>
        public static readonly string wrongCommand = "You have entered wrong command, please try again.";

        /// <summary>
        /// Registration message.
        /// </summary>
        public static readonly string registrationMessage = "Thank you for registering. Please follow  the steps and you will be up in no time.";

        /// <summary>
        /// Registration email adress.
        /// </summary>
        public static readonly string inputEmail = "Input your email adress, back to return or exit:";

        /// <summary>
        /// Password for registration.
        /// </summary>
        public static readonly string passwordInput = "Input your password, back to return or exit:";

        /// <summary>
        /// Email not sent to user.
        /// </summary>
        public static readonly string sendEmailFail = "You have typed the wrong command. Please enter any key to return to start up screen:";

        /// <summary>
        /// Input activation code.
        /// </summary>
        public static readonly string activationCodeInput = "Please enter your activation code:";

        /// <summary>
        /// Login startup message.
        /// </summary>
        public static readonly string loginStartupMessage = "Enter your credentials to login.";

        /// <summary>
        /// Wrong credentials inputed.
        /// </summary>
        public static readonly string wrongCredentials = "Wrong credentials, please try again.";

    }
}
