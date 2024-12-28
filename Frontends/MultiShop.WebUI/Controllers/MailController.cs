using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using MultiShop.WebUI.Models;
using MultiShop.WebUI.Services.Concrete;

namespace MultiShop.WebUI.Controllers
{
    public class MailController : Controller
    {
        private readonly NotificationService _notificationService;

        public MailController(NotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        [HttpGet]
        public IActionResult SendMail()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SendMail(MailRequest mailRequest)
        {
            MimeMessage mimeMessage = new MimeMessage();

            MailboxAddress mailboxAddressFrom = new MailboxAddress("user", "email");

            mimeMessage.From.Add(mailboxAddressFrom);

            MailboxAddress mailboxAddressTo = new MailboxAddress("user", mailRequest.ReciverMail);

            mimeMessage.To.Add(mailboxAddressTo);

            var bodybuilder = new BodyBuilder();

            bodybuilder.TextBody = mailRequest.MessageContent;

            mimeMessage.Body = bodybuilder.ToMessageBody();

            mimeMessage.Subject = mailRequest.Subject;

            SmtpClient smtpClient = new SmtpClient();

            smtpClient.Connect("smtp.gmail.com", 587, false);
            smtpClient.Authenticate("email", "password");

            var value = smtpClient.Send(mimeMessage);

            smtpClient.Disconnect(true);

            return View();
        }
    }
}
