using System.Net.Mail;
using Microsoft.AspNet.Identity;
using System.Threading.Tasks;

namespace CDK.BusinessLogic.Core.ApplicationServices.Client
{
    public class EmailService : IIdentityMessageService
    {
        public Task SendAsync(IdentityMessage message)
        {

            var client = new SmtpClient();
            var mailMessage = new MailMessage();
            mailMessage.To.Add(message.Destination);
            mailMessage.IsBodyHtml = true;
            mailMessage.Body = message.Body;
            mailMessage.Subject = message.Subject;
            
            return client.SendMailAsync(mailMessage);
        }
    }
}