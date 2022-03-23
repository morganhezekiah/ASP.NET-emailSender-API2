using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;
using OwerriJobHuntEmailSender.Models;
using System.Net;

namespace OwerriJobHuntEmailSender.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmailSenderController :ControllerBase
    {
        [HttpPost]
        [Route("send")]
        public string SendMail([FromBody] EmailSenderModel emailSender)
        {
            MailAddress senderAddress = new MailAddress("morganhezekiah11@gmail.com", "OwerriJobHunt");
            MailMessage mailMessage = new MailMessage()
            {
                From = senderAddress,
                IsBodyHtml = true,
                Subject = emailSender.Subject,
                Body = emailSender.TemplateBody

            };
            mailMessage.To.Add(emailSender.SendingTo);

            SmtpClient smtpClient = new SmtpClient()
            {
                UseDefaultCredentials = false,
                Host = "smtp.gmail.com",
                Port = 587,
                Credentials = new NetworkCredential("morganhezekiah11@gmail.com", "wmiixksozsqletoc"),
                EnableSsl = true
            };

            try
            {
                smtpClient.Send(mailMessage);
            }
            catch (Exception e)
            {
                return String.Format("Email Error: {0}", e.Message.ToString());
            }

            return "Message Sent";
        }
    }
}
