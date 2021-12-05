using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using System.Configuration;
using System.Globalization;

namespace Homework
{
    public class BuildEmail
    {
        #region Properties

        private static string _to;
        public static string To
        {
            get { return _to; }
            set { _to = value; }
        }

        private static string _cc;
        public static string CC
        {
            get { return _cc; }
            set { _cc = value; }
        }

        private static string _bcc;
        public static string BCC
        {
            get { return _bcc; }
            set { _bcc = value; }
        }

        private static string _from;
        public static string From
        {
            get { return _from; }
            set { _from = value; }
        }

        private static string _userEmail;
        public static string UserEmail
        {
            get { return _userEmail; }
            set { _userEmail = value; }
        }

        private static string _pass;
        public static string Pass
        {
            get { return _pass; }
            set { _pass = value; }
        }

        private static string _subject;
        public static string Subject
        {
            get { return _subject; }
            set { _subject = value; }
        }
        //public int MyProperty { get; set; }
        private static string _body;
        public static string Body
        {
            get { return _body; }
            set { _body = value; }
        }

        private static string _attachment;
        public static string Attachment
        {
            get { return _attachment; }
            set { _attachment = value; }
        }

        #endregion

        #region Methods

        public static bool SendMailCustomBody()
        {
            bool isok = false;
            try
            {
                bool useSsl = true;

                if (ConfigurationManager.AppSettings["different.com.mk.UseSsl"] != null)
                {
                    useSsl = Convert.ToBoolean(ConfigurationManager.AppSettings["different.com.mk.UseSsl"]);
                }
                MailMessage message = new MailMessage();
                SmtpClient smtpClient = new SmtpClient();
                MailAddress fromAddress = new MailAddress(ConfigurationManager.AppSettings["different.com.mk.DefaultMailFromAddress"]);

                //MailAddress fromAddress = new MailAddress();

                message.From = fromAddress;
                message.To.Add(To);
                //Additional mails if requiered
                //message.To.Add("hello@different.com.mk");                
                if (!string.IsNullOrEmpty(CC))
                    message.CC.Add(CC);
                if (!string.IsNullOrEmpty(BCC))
                    message.Bcc.Add(BCC);
                message.Subject = Subject;
                message.IsBodyHtml = true;
                message.Body = Body;
                message.Priority = MailPriority.Normal;
                smtpClient.Host = ConfigurationManager.AppSettings["different.com.mk.DefaultSmtp"];   // We use gmail as our smtp client
                smtpClient.Port = Helper.TryParseInt(ConfigurationManager.AppSettings["different.com.mk.DefaultSmtpPort"]);
                smtpClient.EnableSsl = useSsl;
                smtpClient.UseDefaultCredentials = true;
                smtpClient.Credentials = new System.Net.NetworkCredential(ConfigurationManager.AppSettings["different.com.mk.SmtpInfoUserName"], ConfigurationManager.AppSettings["different.com.mk.SmtpInfoPassword"]);
                smtpClient.Send(message);
                isok = true;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
            return isok;
        }

        public static bool SendMailCustomBodyWithAttachment()
        {
            bool isok = false;
            try
            {
                MailMessage message = new MailMessage();
                SmtpClient smtpClient = new SmtpClient();

                MailAddress fromAddress = new MailAddress(ConfigurationManager.AppSettings["different.com.mk.SmtpInfoUserName"]);
                message.From = fromAddress;
                message.To.Add(To);

                message.Subject = Subject;
                message.IsBodyHtml = true;
                message.Body = Body;
                message.Priority = MailPriority.High;
                smtpClient.Host = ConfigurationManager.AppSettings["different.com.mk.DefaultSmtp"];   // We use gmail as our smtp client
                smtpClient.Port = Convert.ToInt32(ConfigurationManager.AppSettings["different.com.mk.DefaultSmtpPort"]);
                smtpClient.EnableSsl = false;
                smtpClient.UseDefaultCredentials = true;
                smtpClient.Credentials = new System.Net.NetworkCredential(ConfigurationManager.AppSettings["different.com.mk.SmtpInfoUserName"], ConfigurationManager.AppSettings["different.com.mk.SmtpInfoPassword"]);

                smtpClient.Send(message);

                isok = true;
            }
            catch
            {


            }
            return isok;
        }


        #endregion
    }



    
}