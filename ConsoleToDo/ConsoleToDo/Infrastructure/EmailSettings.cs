using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleToDo
{
    static class EmailSettings
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
