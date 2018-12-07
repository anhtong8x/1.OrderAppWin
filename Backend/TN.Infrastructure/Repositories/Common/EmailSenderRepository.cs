﻿using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using TN.Domain.Model;
using TN.Infrastructure.Interfaces;

namespace TN.Infrastructure.Repositories
{
    public class EmailSenderRepository : IEmailSenderRepository
    {
        public async Task SendEmailAsync(EmailSettings st, string ToEmail, string Subject, string Body, string Add = null, string CC = null, string BC = null)
        {
            try
            {
                if (string.IsNullOrEmpty(ToEmail))
                {
                    ToEmail = Add.Split(',')[0].Trim();
                    Add = Add.Replace(ToEmail, "").Trim();
                }
                var fromAddress = new MailAddress(st.Email);
                var toAddress = new MailAddress(ToEmail);
                string fromPassword = st.Password;
                string subject = Subject;
                string body = Body;

                var smtp = new SmtpClient
                {
                    Host = st.Host,
                    Port = st.Port,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
                };
                using (var message = new MailMessage(fromAddress, toAddress)
                {
                    IsBodyHtml = true,
                    Subject = subject,
                    Body = body,

                })
                {
                    if (!string.IsNullOrEmpty(Add))
                    {
                        message.To.Add(Add);
                    }
                    if (!string.IsNullOrEmpty(CC))
                    {
                        message.CC.Add(CC);
                    }
                    if (!string.IsNullOrEmpty(BC))
                    {
                        message.Bcc.Add(BC);
                    }
                    await smtp.SendMailAsync(message);
                }
            }
            catch (Exception ex)
            {
                string a = ex.ToString();
            }
        }
        public async Task<bool> SendAsync(EmailSettings st, string ToEmail, string Subject, string Body)
        {
            try
            {
                var fromAddress = new MailAddress(st.Email);
                var toAddress = new MailAddress(ToEmail);
                string fromPassword = st.Password;
                string subject = Subject;
                string body = Body;

                var smtp = new SmtpClient
                {
                    Host = st.Host,
                    Port = st.Port,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
                };
                using (var message = new MailMessage(fromAddress, toAddress)
                {
                    IsBodyHtml = true,
                    Subject = subject,
                    Body = body,
                })
                {
                    await smtp.SendMailAsync(message);
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}