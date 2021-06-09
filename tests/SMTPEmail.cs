using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace ProbPotes.tests
{
    class SMTPEmail
    {
        public Boolean sendMail()
        {
            string from = "probpote@fifoot-bet.fr"; //https://mail.ovh.net/roundcube/?_task=login pour accéder au mail
            string mdp = "changethis";
            string title = "Mail Test";//OBJET DU MESSAGE
            string message = "message zebi";//MESSAGE
            string to = "hugo.schellinger@gmail.com";//DESTINATAIRE

            int Port = 465;
            string SMTP = "ssl0.ovh.net";

            try
            {
                MailMessage msg;

                SmtpClient client = new SmtpClient();


                //PARAMETRE DU MAIL
                msg = new MailMessage(from, to, title, message);
                client.Port = Port;
                client.Host = SMTP;
                client.EnableSsl = true;
                client.Timeout = 10000;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.Credentials = new NetworkCredential(from, mdp);
                msg.Priority = MailPriority.High;
                msg.BodyEncoding = Encoding.UTF8;
                msg.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;


                //ENVOIE DU MAIL
                client.Send(msg);

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
