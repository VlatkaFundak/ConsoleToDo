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
    public class EmailService : IEmailService
    {
        /// <summary>
        /// Sends an email with the activation code.
        /// </summary>
        /// <param name="mail">Email adress from admin, to user, body and description of the email.</param>
        public void SendEmail(MailMessage mail)
        {
            SmtpClient smtp = new SmtpClient(EmailSettings.host, EmailSettings.portNumber);
            smtp.Credentials = new NetworkCredential(mail.From.Address, EmailSettings.password);
            smtp.EnableSsl = true;
            smtp.Send(mail);
        }
    }
}
