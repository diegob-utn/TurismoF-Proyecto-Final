using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net;
using System.Net.Mail;

namespace TurismoF.Modelos.Observer
{
    public class EmailNotificationObserver:INotificationObserver
    {
        public void Notify(string subject, string message, string email)
        {
            // Configura tus credenciales SMTP aquí
            var smtpClient = new SmtpClient("smtp-relay.brevo.com")
            {
                Port = 587,
                Credentials = new NetworkCredential("90d7e6001@smtp-brevo.com", "4WXsgRkUIbNHQ263"),
                EnableSsl = true,
            };

            var mailMessage = new MailMessage
            {
                From = new MailAddress("90d7e6001@smtp-brevo.com"),
                Subject = subject,
                Body = message,
                IsBodyHtml = false,
            };
            mailMessage.To.Add(email);

            smtpClient.Send(mailMessage);
        }
    }
}
