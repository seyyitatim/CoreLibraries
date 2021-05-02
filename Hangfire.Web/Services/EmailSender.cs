using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace Hangfire.Web.Services
{
    public class EmailSender:IEmailSender
    {
        private IConfiguration _configuration;

        public EmailSender(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task Sender(string userId, string message)
        {
            var apiKey = _configuration.GetSection("APIs")["SendGridKey"];
            var client = new SendGridClient("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");
            var from = new EmailAddress("seyyit3552@gmail.com", "Example User");
            var subject = "www.mysite.com bilgilendirme";
            var to = new EmailAddress("seyyit_52@outlook.com", "Example User");
            //var plainTextContent = "and easy to do anywhere, even with C#";
            var htmlContent = $"<strong>{message}</strong>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, null, htmlContent);
            await client.SendEmailAsync(msg);
        }
    }
}
