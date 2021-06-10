using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace ProbPotes.services
{
    class Email
    {
        public Boolean sendMail(string dest, string objet, string msg)
        {
            string from = "probpote@fifoot-bet.fr"; //https://mail.ovh.net/roundcube/?_task=login pour accéder au mail
            string mdp = "changethis";
            string title = objet;//OBJET DU MESSAGE
            string message = msg;//MESSAGE
            string to = dest;//DESTINATAIRE

            int Port = 587;
            string SMTP = "ssl0.ovh.net";

            try
            {
                MailMessage mail;

                SmtpClient client = new SmtpClient();


                //PARAMETRE DU MAIL
                mail = new MailMessage(from, to, title, message);
                client.Port = Port;
                client.Host = SMTP;
                client.EnableSsl = true;
                client.Timeout = 10000;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.Credentials = new NetworkCredential(from, mdp);
                mail.Priority = MailPriority.High;
                mail.BodyEncoding = Encoding.UTF8;
                mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;


                //ENVOIE DU MAIL
                client.Send(mail);

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
