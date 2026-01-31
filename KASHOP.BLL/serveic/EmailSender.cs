using Microsoft.AspNetCore.Identity.UI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace KASHOP.BLL.serveic
{
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var client = new SmtpClient("smtp.gmail.com", 587)
            {
                EnableSsl = true,
                UseDefaultCredentials = false,
                //password cant login 
                Credentials = new NetworkCredential("samahabuhantash10@gmail.com", "vqlc oeco jsim ksjv")
            };

            return client.SendMailAsync(
                new MailMessage(from: "samahabuhantash10@gmail.com",
                                to: email,
                                subject,
                                htmlMessage
                                )
                { IsBodyHtml=true}
                );


        }
    }
}