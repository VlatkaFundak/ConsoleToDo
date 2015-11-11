using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleToDo
{
    /// <summary>
    /// Email service class.
    /// </summary>
    class EmailService: IEmailService
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
        public void SendEmail(string adressFrom, string adressTo, string password, string host, int portNumber, string subject, string body)
        {
            MailMessage mail = new MailMessage(adressFrom, adressTo);
            mail.Subject = subject;
            mail.Body = body;

            SmtpClient smtp = new SmtpClient(host, portNumber);
            smtp.Credentials = new NetworkCredential(adressFrom, password);
            smtp.EnableSsl = true;
            smtp.Send(mail);
        }
    }
}
