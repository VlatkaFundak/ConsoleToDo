using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleToDo
{
    /// <summary>
    /// Email service interface.
    /// </summary>
    public interface IEmailService
    {
        /// <summary>
        /// Sends an email with the activation code.
        /// </summary>
        /// <param name="adressFrom">Email adress from admin.</param>
        /// <param name="adressTo">Email adress to user.</param>
        /// <param name="password">Users password.</param>
        /// <param name="host">Host.</param>
        /// <param name="portNumber">Port number.</param>
        /// <param name="subject">Subject of the email.</param>
        /// <param name="body">Body of the email.</param>
        void SendEmail(string adressFrom, string adressTo, string password, string host, int portNumber, string subject, string body);
    }
}
