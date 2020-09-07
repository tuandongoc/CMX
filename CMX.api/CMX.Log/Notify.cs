using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace CMX.Logging
{
    public class Notify
    {
        private static string _smtp;
        private static string _port;
        private static string _user;
        private static string _pass;
        private static bool _enableSsl;
        private static string _from;
        private static string _errorMailTo;
        static bool _canSend = false;

        static public void SetConfig(IConfiguration configuration)
        {
            if (configuration == null)
                _canSend = false;
            _smtp = configuration["Email:SmtpServer"];
            _port = configuration["Email:Port"];
            _user = configuration["Email:UserSmtpServer"];
            _pass = configuration["Email:PasswordSmtpServer"];
            _enableSsl = (configuration["Email:EnableSsl"] + "").ToLower() == "true";
            _from = configuration["Email:SendEmail"];
            _errorMailTo = configuration["Email:ErrorTo"];

            if (string.IsNullOrWhiteSpace(_smtp)
                || string.IsNullOrWhiteSpace(_from))
            {
                _canSend = false;
            }
            else
                _canSend = true;
        }

        public static async Task SendEmailAsync(string subject, string message, string to, object attachment = null, string attachmentName = null, string attachmentContentType = null)
        {
            if (_canSend == false)
                return;
            var client = new SmtpClient(_smtp);
            if (!string.IsNullOrWhiteSpace(_port) && int.TryParse(_port, out int port))
            {
                client.Port = port;
            };
            if (_enableSsl)
            {
                client.EnableSsl = _enableSsl;
            };
            if (!string.IsNullOrWhiteSpace(_user) && !string.IsNullOrWhiteSpace(_pass))
            {
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential(_user, _pass);
            };
            var mailMessage = new MailMessage(_from, to);

            mailMessage.IsBodyHtml = true;
            mailMessage.Subject = subject;
            mailMessage.Body = message.Replace(Environment.NewLine, "<br />").Replace("\n", "<br />");

            if (attachment != null)
            {
                if (attachment is string)
                {
                    mailMessage.Attachments.Add(new Attachment((string)attachment));
                }
                else if (attachment is System.IO.Stream)
                {
                    var attName = attachmentName ?? "ines_attachment";
                    mailMessage.Attachments.Add(new Attachment((System.IO.Stream)attachment, attName));
                }
            }

            await client.SendMailAsync(mailMessage);
        }
    }
}
