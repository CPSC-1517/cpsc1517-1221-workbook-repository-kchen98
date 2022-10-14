using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net;
using System.Net.Mail;

namespace WestwindWebApp.Pages
{
    public class SendMailModel : PageModel
    {
        [BindProperty]
        public string MailUsername { get; set; }

        [BindProperty]
        public string MailAppPassword { get; set; }

        [BindProperty]
        public string MailToAddress { get; set; }

        [BindProperty]
        public string MailSubject { get; set; }

        [BindProperty]
        public string MailMessage { get; set; }
        public void OnGet()
        {
            MailUsername = "chenkent98@gmail.com";
            MailAppPassword = "";
            MailToAddress = "kchen98@yahoo.com.ph";
            MailSubject = "CPSC1517 Send Mail Demo";
            MailMessage = "This email was sent from a Razor Page";

            var sendMailClient = new SmtpClient();
            sendMailClient.Host = "smpt.gmail.com";
            sendMailClient.Port = 587;
            sendMailClient.EnableSsl = true;
            var sendMailCredentials = new NetworkCredential();
            sendMailCredentials.UserName = MailUsername;
            sendMailCredentials.Password = MailAppPassword;
            sendMailClient.Credentials = sendMailCredentials;

            var sendFromAddress = new MailAddress(MailUsername);
            var sendToAddress = new MailAddress(MailToAddress);

            var mailMessage = new MailMessage(sendFromAddress, sendToAddress);
            mailMessage.Subject = MailSubject;
            mailMessage.Body = MailMessage;
            sendMailClient.Send(mailMessage);
        }
    }
}
