namespace TorrentBG.Helper
{
    using Microsoft.Extensions.Configuration;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Net.Mail;
    using System.Threading.Tasks;

    public class MailHelper
    {
        public static bool Send(string fromAddress,string toAddress,string subject,string content)
        {

            try
            {
                var builder = new ConfigurationBuilder()
                           .SetBasePath(Directory.GetCurrentDirectory())
                           .AddJsonFile("gmailsettings.json");

                var config = builder.Build();

                var host = config["Gmail:Host"];
                var port = int.Parse(config["Gmail:Port"]);
                var username = config["Gmail:Username"];
                var password = config["Gmail:Password"];
                var enable = bool.Parse(config["Gmail:SMTP:starttls:enable"]);

                var smtpClient = new SmtpClient()
                {
                    Host = host,
                    Port = port,
                    EnableSsl = enable,
                    Credentials = new NetworkCredential(username, password),
                };

                var message = new MailMessage(fromAddress, toAddress);

                message.Subject = subject;
                message.Body = content;
                message.IsBodyHtml = true;

                smtpClient.Send(message);

                return true;
            }
            catch (Exception)
            {

                return false;
            }
           


        }
    }
}
