using DatabaseAccess.Entities;
using DatabaseAccess.Enums;
using FluentEmail.Core;
using FluentEmail.Smtp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccess.Data
{
    public class EmailService
    {
        public async Task SendEmail(ApplicationUser Recipient, JobPost Jobpost, JobApplication App, AppStatusType status, DateTime intDate, string customMessage) 
        {
            if (customMessage == null)
            {
                customMessage = "";
            }
            if (!customMessage.Equals(""))
            {
                string msg = customMessage;
                customMessage = $"Message from recruiter:\n{msg}";
            }

            string fromMail = "csaplatform3412023@gmail.com";
            string fromPassword = "lgisywqyebvsniab";

            var sender = new SmtpSender(() => new SmtpClient("smtp.gmail.com")
            {
                EnableSsl = true,
                Credentials = new NetworkCredential(fromMail, fromPassword),
                Port = 587
            });
            Email.DefaultSender = sender;
            
            if (status == AppStatusType.Selected)
            {
                var email = await Email
                .From(fromMail)
                .To(Recipient.Email, Recipient.FirstName)
                .Subject($"Notification on your application - {Jobpost.JobTitle}")
                .Body($"We are happy to inform you that you have been selected for an interview!\n\nYour interview is scheduled on the following date:\n{intDate.ToString()}\n\n{customMessage}")
                .SendAsync();
            }

            if (status == AppStatusType.Rejected)
            {
                var email = await Email
                .From(fromMail)
                .To(Recipient.Email, Recipient.FirstName)
                .Subject($"Notification on your application - {Jobpost.JobTitle}")
                .Body($"We regret to inform you that the recruiter will not be moving forward with your application. Please feel free to continue applying through CSAPlatform!\n\n{customMessage}")
                .SendAsync();
            }

        }
    }
}
