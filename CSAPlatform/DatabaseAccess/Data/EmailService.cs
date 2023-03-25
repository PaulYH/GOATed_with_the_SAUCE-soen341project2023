using DatabaseAccess.Entities;
using FluentEmail.Core;
using FluentEmail.Smtp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccess.Data
{
    public class EmailService
    {
        public async Task SendEmail(ApplicationUser Recipient, JobPost Jobpost, JobApplication App) 
        {
            var sender = new SmtpSender(() => new SmtpClient("localhost")
            {
                EnableSsl = false, 
                DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory,
                PickupDirectoryLocation = @"C:\SOEN341Temp"
            }) ;
            Email.DefaultSender = sender;
            var email = await Email
                .From("test@testemail.ca")
                .To(Recipient.Email,Recipient.FirstName)
                .Subject("Notification on your application")
                .Body("We are happy to inform you ..")
                .SendAsync();
        }
    }
}
