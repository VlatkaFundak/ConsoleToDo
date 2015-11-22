using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
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
        /// <param name="mail">Email adress from admin, to user, body and description of the email.</param>
        /// <param name="password">User's password.</param>
        /// <param name="host">Host.</param>
        /// <param name="portNumber">Port number.</param>
        void SendEmail(MailMessage mail, string password, string host, int portNumber);
    }
}
