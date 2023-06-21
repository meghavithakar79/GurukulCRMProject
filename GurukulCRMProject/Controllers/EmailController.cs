    using GurukulCRMProject.Models;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using System.Diagnostics;
    using MailKit.Net.Smtp;
    using MailKit.Security;
    using MimeKit;
    using System.Linq;
    using GurukulCRMProject.Areas.Identity.Pages.Account.Manage;
    using Org.BouncyCastle.Cms;
    using Microsoft.AspNetCore.Authorization;
    using Gurukul.Infrastructure.Constants;

    namespace GurukulCRMProject.Controllers
    {
        public class EmailController : Controller
        {
            private readonly GurukulDbContext _context;
            public EmailController(GurukulDbContext context)
            {
                _context = context;
            }
            [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
            public IActionResult Error()
            {
                return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }
            public IActionResult SendEmail()
            {
                Mail mail = new Mail();
                mail.contacts = GetUsers();
                return View(mail);
            }
            private List<Contact> GetUsers()
            {
                var con = _context.Contacts.Where(x => !x.IsDelete).ToList();
                return con;
            }
            [HttpPost]
            [Authorize(Permissions.Mail.Create)]
            [Authorize(Permissions.Mail.Edit)]
            public IActionResult SendEmail(List<string> selectedUsers, Mail emailModel)
            {
                var users = GetUsers();
                var selectedUserEmails = new List<string>();
                foreach (var user in users)
                {
                    if (selectedUsers.Contains(user.Email))
                    {
                        selectedUserEmails.Add(user.Email);
                    }
                }
                SendEmailToUsers(emailModel, selectedUserEmails);
                return RedirectToAction("EmailSent");
            }
            private void SendEmailToUsers(Mail emailModel, List<string> selectedUserEmails)
            {
                var message = new MimeMessage();
                message.From.Add(new MailboxAddress("Megha", "no-reply@girirajdigital.com"));
                /* message.To.Add(new MailboxAddress(emailModel.Title,""));*/
                foreach (var userEmail in selectedUserEmails)
                {
                    message.To.Add(new MailboxAddress(emailModel.Title, userEmail));
                    _context.Mails.Add(new Mail
                    {
                        RecipientEmail = userEmail,
                        SenderEmail = "no-reply@girirajdigital.com",
                        Title = emailModel.Title,
                        Body = emailModel.Body
                    });
                }
                _context.SaveChanges();
                message.Subject = emailModel.Title;

                var bodyBuilder = new BodyBuilder();
                bodyBuilder.HtmlBody = emailModel.Body;
                message.Body = bodyBuilder.ToMessageBody();

                using var client = new SmtpClient();
                client.Connect("smtp.office365.com", 587, SecureSocketOptions.StartTls);
                client.Authenticate("no-reply@girirajdigital.com", "GD@Dont2223");
                client.Send(message);
                client.Disconnect(true);
            }
            public IActionResult EmailSent()
            {
                return View();
            }
        }
    }
