﻿using DatabaseAccess.Entities;
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
        public async Task SendEmail(ApplicationUser Recipient, JobPost Jobpost, JobApplication App) 
        {
            string fromMail = "csaplatform3412023@gmail.com";
            string fromPassword = "lgisywqyebvsniab";

            var sender = new SmtpSender(() => new SmtpClient("smtp.gmail.com")
            {
                EnableSsl = true,
                Credentials = new NetworkCredential(fromMail, fromPassword),
                Port = 587
            });
            Email.DefaultSender = sender;
            var email = await Email
                .From(fromMail)
                .To(Recipient.Email,Recipient.FirstName)
                .Subject("Notification on your application")
                .Body("We are happy to inform you ..")
                .SendAsync();
        }
    }
}
