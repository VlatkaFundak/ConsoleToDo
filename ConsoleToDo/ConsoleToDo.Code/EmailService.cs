using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

using Infrastructure.Code;

namespace ConsoleToDo.Code
{
    /// <summary>
    /// Email service class.
    /// </summary>
    public class EmailService: IEmailService
    {
        /// <summary>
        /// Sends an email with the activation code.
        /// </summary>
        /// <param name="mail">Email adress from admin, to user, body and description of the email.</param>
        /// <param name="password">Users password.</param>
        /// <param name="host">Host.</param>
        /// <param name="portNumber">Port number.</param>
        public void SendEmail(MailMessage mail, string password, string host, int portNumber)
        {
            SmtpClient smtp = new SmtpClient(host, portNumber);
            smtp.Credentials = new NetworkCredential(mail.From.Address, password);
            smtp.EnableSsl = true;
            smtp.Send(mail);
        }        
    }
}
