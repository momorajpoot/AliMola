using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;

namespace momii.Helper
{
    public class Email
    {
        public bool SendEmail(string ToAddress, string UserName)
        {
            bool Result = false;

            MailMessage oMailMessage = new MailMessage("FROM-EMAIL-HERE", ToAddress);
            //oMailMessage.From = new MailAddress("FROM-EMAIL-HERE");
            oMailMessage.Subject = "Welcome " + UserName + " to Our Webite";
            oMailMessage.SubjectEncoding = Encoding.UTF8;

            EmailTemplates oET = new EmailTemplates();

            //how to use template
            oMailMessage.Body = string.Format(oET.SignUpEmailTemplate, UserName, ToAddress);
            //oMailMessage.Attachments.Add();
            oMailMessage.IsBodyHtml = true;
            oMailMessage.BodyEncoding = System.Text.Encoding.UTF8;


            SmtpClient oSMTP = new SmtpClient();
            oSMTP.Credential = new System.Net.NetworkCredential("FROM-EMAIL-HERE", "EMAIL-PASSWORD-HERE");
            oSMTP.Host = "smtp.gmail.com";
            oSMTP.Port = 587;
            oSMTP.EnableSsl = true;

            try
            {
                oSMTP.Send(oMailMessage);
            }
            catch (Exception ex)
            {

            }

            return Result;
        }
    }

    internal class MailMessage
    {
        private string toAddress;
        private string v;

        public MailMessage(string v, string toAddress)
        {
            this.v = v;
            this.toAddress = toAddress;
        }

        public string Body { get; internal set; }
        public Encoding BodyEncoding { get; internal set; }
        public bool IsBodyHtml { get; internal set; }
        public string Subject { get; internal set; }
        public Encoding SubjectEncoding { get; internal set; }
    }

    internal class SmtpClient
    {
        public NetworkCredential Credential { get; internal set; }
        public bool EnableSsl { get; internal set; }
        public string Host { get; internal set; }
        public int Port { get; internal set; }
    }
}

  