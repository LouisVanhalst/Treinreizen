using Microsoft.AspNetCore.Identity.UI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Treinreizen.Services
{
    public class EmailSender 
    {
        private string host;
        private int port;
        private bool enableSSL;
        private string userName;
        private string password;
       
            
        public EmailSender(string host, int port, bool enableSSL, string userName, string password)
        {
            this.host = host;
            this.port = port;
            this.enableSSL = enableSSL;
            this.userName = userName;
            this.password = password;
        }
        public EmailSender()
        {
            
        }
        public async Task SendEmailAsync(string email, string subject, string message)
        {
            var mail = new MailMessage();
            mail.To.Add(new MailAddress(email));
            mail.From = new MailAddress("vanhalstLouis@gmail.com");
            mail.Subject = subject;
            mail.Body = message;
            mail.IsBodyHtml = true;

            try
            {
                using (var smtp = new SmtpClient("smtp.gmail.com"))
                {
                    smtp.Port = 587;
                    smtp.EnableSsl = true;
                    smtp.Credentials = new NetworkCredential("vanhalstLouis@gmail.com", "Jef-ken598");
                    await smtp.SendMailAsync(mail);

                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }

        }
        //public async Task GetEmailAsync(string email, string subject, string message)
        //{
        //    var mail = new MailMessage();
        //    mail.To.Add(new MailAddress(email));
        //    mail.From = new MailAddress("vanhalstLouis@gmail.com");
        //    mail.Subject = subject;
        //    mail.Body = message;
        //    mail.IsBodyHtml = true;

        //    try
        //    {
        //        using (var smtp = new SmtpClient("smtp.gmail.com"))
        //        {
        //            smtp.Port = 587;
        //            smtp.EnableSsl = true;
        //            smtp.Credentials = new NetworkCredential("vanhalstLouis@gmail.com", "Jef-ken598");
        //            await smtp.SendMailAsync(mail);

        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new InvalidOperationException(ex.Message);
        //    }
        //}

    }
}
            

