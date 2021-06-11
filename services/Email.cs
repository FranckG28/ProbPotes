using ProbPotes.managers;
using ProbPotes.models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace ProbPotes.services
{
    abstract class Email
    {
        public static Boolean SendMail(Participant p, EventClass e)
        {
            Participant Creator = DatabaseManager.Participants.GetParticipant(e.CreatorCode);

            string from = "probpote@fifoot-bet.fr"; //https://mail.ovh.net/roundcube/?_task=login pour accéder au mail
            string mdp = "changethis";
            string title = Creator.FirstName + " " + Creator.Name.ToUpper() + " vous invite à l'évènement " + e.Title + " sur ProbPotes";//OBJET DU MESSAGE
            string to = p.MailAddress;//DESTINATAIRE
            string message = @"<!doctype html>
    <html xmlns=""http://www.w3.org/1999/xhtml"" xmlns:v=""urn:schemas-microsoft-com:vml"" xmlns:o=""urn:schemas-microsoft-com:office:office"">
      <head>
        <title>
          
        </title>
        <!--[if !mso]><!-- -->
        <meta http-equiv=""X-UA-Compatible"" content=""IE=edge"">
        <!--<![endif]-->
        <meta http-equiv=""Content-Type"" content=""text/html; charset=UTF-8"">
        <meta name=""viewport"" content=""width=device-width, initial-scale=1"">
        <style type=""text/css"">
          #outlook a { padding:0; }
          body { margin:0;padding:0;-webkit-text-size-adjust:100%;-ms-text-size-adjust:100%; }
          table, td { border-collapse:collapse;mso-table-lspace:0pt;mso-table-rspace:0pt; }
          img { border:0;height:auto;line-height:100%; outline:none;text-decoration:none;-ms-interpolation-mode:bicubic; }
          p { display:block;margin:13px 0; }
        </style>
        <!--[if mso]>
        <xml>
        <o:OfficeDocumentSettings>
          <o:AllowPNG/>
          <o:PixelsPerInch>96</o:PixelsPerInch>
        </o:OfficeDocumentSettings>
        </xml>
        <![endif]-->
        <!--[if lte mso 11]>
        <style type=""text/css"">
          .outlook-group-fix { width:100% !important; }
        </style>
        <![endif]-->
        
      <!--[if !mso]><!-->
        <link href=""https://fonts.googleapis.com/css?family=Ubuntu:300,400,500,700"" rel=""stylesheet"" type=""text/css"">
<link href=""https://fonts.googleapis.com/css?family=Cabin:400,700"" rel=""stylesheet"" type=""text/css"">
<link href=""https://fonts.googleapis.com/css?family=Poppins:400,700"" rel=""stylesheet"" type=""text/css"">
        <style type=""text/css"">
          @import url(https://fonts.googleapis.com/css?family=Ubuntu:300,400,500,700);
@import url(https://fonts.googleapis.com/css?family=Cabin:400,700);
@import url(https://fonts.googleapis.com/css?family=Poppins:400,700);
        </style>
      <!--<![endif]-->

    
        
    <style type=""text/css"">
      @media only screen and (min-width:480px) {
        .mj-column-per-100 { width:100% !important; max-width: 100%; }
      }
    </style>
    
  
        <style type=""text/css"">
        
        

    @media only screen and (max-width:480px) {
      table.full-width-mobile { width: 100% !important; }
      td.full-width-mobile { width: auto !important; }
    }
  
        </style>
        <style type=""text/css"">.hide_on_mobile { display: none !important;} 
        @media only screen and (min-width: 480px) { .hide_on_mobile { display: block !important;} }
        .hide_section_on_mobile { display: none !important;} 
        @media only screen and (min-width: 480px) { 
            .hide_section_on_mobile { 
                display: table !important;
            } 

            div.hide_section_on_mobile { 
                display: block !important;
            }
        }
        .hide_on_desktop { display: block !important;} 
        @media only screen and (min-width: 480px) { .hide_on_desktop { display: none !important;} }
        .hide_section_on_desktop { display: table !important;} 
        @media only screen and (min-width: 480px) { .hide_section_on_desktop { display: none !important;} }
        [owa] .mj-column-per-100 {
            width: 100%!important;
          }
          [owa] .mj-column-per-50 {
            width: 50%!important;
          }
          [owa] .mj-column-per-33 {
            width: 33.333333333333336%!important;
          }
          p, h1, h2, h3 {
              margin: 0px;
          }

          a {
              text-decoration: none;
              color: inherit;
          }
        
          @media only print and (min-width:480px) {
            .mj-column-per-100 { width:100%!important; }
            .mj-column-per-40 { width:40%!important; }
            .mj-column-per-60 { width:60%!important; }
            .mj-column-per-50 { width: 50%!important; }
            mj-column-per-33 { width: 33.333333333333336%!important; }
            }</style>
        
      </head>
      <body style=""background-color:#FFFFFF;"">
        
        
      <div style=""background-color:#FFFFFF;"">
        
      
      <!--[if mso | IE]>
      <table
         align=""center"" border=""0"" cellpadding=""0"" cellspacing=""0"" class="""" style=""width:600px;"" width=""600""
      >
        <tr>
          <td style=""line-height:0px;font-size:0px;mso-line-height-rule:exactly;"">
      <![endif]-->
    
      
      <div style=""margin:0px auto;max-width:600px;"">
        
        <table align=""center"" border=""0"" cellpadding=""0"" cellspacing=""0"" role=""presentation"" style=""width:100%;"">
          <tbody>
            <tr>
              <td style=""direction:ltr;font-size:0px;padding:9px 0px 9px 0px;text-align:center;"">
                <!--[if mso | IE]>
                  <table role=""presentation"" border=""0"" cellpadding=""0"" cellspacing=""0"">
                
        <tr>
      
            <td
               class="""" style=""vertical-align:top;width:600px;""
            >
          <![endif]-->
            
      <div class=""mj-column-per-100 outlook-group-fix"" style=""font-size:0px;text-align:left;direction:ltr;display:inline-block;vertical-align:top;width:100%;"">
        
      <table border=""0"" cellpadding=""0"" cellspacing=""0"" role=""presentation"" style=""vertical-align:top;"" width=""100%"">
        
            <tr>
              <td align=""center"" style=""font-size:0px;padding:0px 0px 0px 0px;word-break:break-word;"">
                
      <table border=""0"" cellpadding=""0"" cellspacing=""0"" role=""presentation"" style=""border-collapse:collapse;border-spacing:0px;"">
        <tbody>
          <tr>
            <td style=""width:600px;"">
              
      <img height=""auto"" src=""https://i.ibb.co/qjZJC53/EmailBG.png"" style=""border:0;display:block;outline:none;text-decoration:none;height:auto;width:100%;font-size:13px;"" width=""600"">
    
            </td>
          </tr>
        </tbody>
      </table>
    
              </td>
            </tr>
          
            <tr>
              <td align=""left"" style=""font-size:0px;padding:27px 15px 15px 15px;word-break:break-word;"">
                
      <div style=""font-family:Ubuntu, Helvetica, Arial, sans-serif;font-size:11px;line-height:1.5;text-align:left;color:#000000;""><p><span style=""font-family: Poppins, sans-serif; font-size: 15px;"">Bonjour " + p.FirstName + " " + p.Name.ToUpper() + @",</span></p>
<p>&nbsp;</p>
<p><span style=""font-family: Poppins, sans-serif; font-size: 18px;"">" + Creator.FirstName + " " + Creator.Name.ToUpper() + @" vous &agrave; invit&eacute; &agrave; l'&eacute;v&egrave;nement " + e.Title + @" !</span></p>
<p>&nbsp;</p>
<p><span style=""font-family: Poppins, sans-serif; font-size: 18px;"">T&eacute;l&eacute;chargez ProbPotes d&egrave;s maitenant pour le rejoindre :</span></p></div>
    
              </td>
            </tr>
          
            <tr>
              <td align=""center"" vertical-align=""middle"" style=""font-size:0px;padding:0px 20px 0px 20px;word-break:break-word;"">
                
      <table border=""0"" cellpadding=""0"" cellspacing=""0"" role=""presentation"" style=""border-collapse:separate;width:auto;line-height:100%;"">
        <tr>
          <td align=""center"" bgcolor=""#3454D1"" role=""presentation"" style=""border:none;border-radius:0px;cursor:auto;mso-padding-alt:19px 60px 19px 60px;background:#3454D1;"" valign=""middle"">
            <a href=""https://franck-g.fr/probpotes/"" style=""display: inline-block; background: #3454D1; color: #ffffff; font-family: Ubuntu, Helvetica, Arial, sans-serif, Helvetica, Arial, sans-serif; font-size: 24px; font-weight: normal; line-height: 30px; margin: 0; text-decoration: none; text-transform: none; padding: 19px 60px 19px 60px; mso-padding-alt: 0px; border-radius: 0px;"" target=""_blank"">
              <span style=""font-family: Poppins, sans-serif; font-size: 24px;"">T&eacute;l&eacute;charger</span>
            </a>
          </td>
        </tr>
      </table>
    
              </td>
            </tr>
          
            <tr>
              <td align=""left"" style=""font-size:0px;padding:15px 15px 15px 15px;word-break:break-word;"">
                
      <div style=""font-family:Ubuntu, Helvetica, Arial, sans-serif;font-size:11px;line-height:1.5;text-align:left;color:#000000;""><p style=""text-align: right;""><span style=""font-family: Poppins, sans-serif;"">Cordialement,&nbsp;</span></p>
<p style=""text-align: right;""><span style=""font-family: Poppins, sans-serif; font-size: 16px;"">L'&eacute;quipe ProbPotes</span></p></div>
    
              </td>
            </tr>
          
      </table>
    
      </div>
    
          <!--[if mso | IE]>
            </td>
          
        </tr>
      
                  </table>
                <![endif]-->
              </td>
            </tr>
          </tbody>
        </table>
        
      </div>
    
      
      <!--[if mso | IE]>
          </td>
        </tr>
      </table>
      <![endif]-->
    
    
      </div>
    
      </body>
    </html>";//MESSAGE
            

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
                Debug.WriteLine("Mail Envoyé à " + p.MailAddress);
                return true;
            }
            catch (Exception exp)
            {
                Debug.WriteLine("Impossible d'envoyer le mail : " + exp.ToString());
                return false;
            }
        }
    }
}
