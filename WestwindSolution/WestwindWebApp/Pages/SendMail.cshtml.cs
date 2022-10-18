using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net;
using System.Net.Mail;

namespace WestwindWebApp.Pages
{
    public class SendMailModel : PageModel
    {
        private readonly IConfiguration Configuration;

        public SendMailModel(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        [BindProperty]
        public string FeedbackMessage { get; set; } = null!;

        [BindProperty]
        public string MailUsername { get; set; } = null!;

        [BindProperty]
        public string MailAppPassword { get; set; } = null!;

        [BindProperty]
        public string MailToAddress { get; set; } = null!;

        [BindProperty]
        public string MailSubject { get; set; } = null!;

        [BindProperty]
        public string MailMessage { get; set; } = null!;

        public void OnPostSendMail()
        {
            FeedbackMessage = "<h2>Send Mail button clicked</h2>";
            var sendMailClient = new SmtpClient();
            sendMailClient.Host = "smtp.gmail.com";
            sendMailClient.Port = 587;
            sendMailClient.EnableSsl = true;
            var sendMailCredentials = new NetworkCredential();
            MailUsername = Configuration["GmailCredentials:Username"];
            MailAppPassword = Configuration["GmailCredentials:Password"];
            sendMailCredentials.UserName = MailUsername;
            sendMailCredentials.Password = MailAppPassword;
            sendMailClient.Credentials = sendMailCredentials;

            var sendFromAddress = new MailAddress(MailUsername);
            var sendToAddress = new MailAddress(MailToAddress);

            var mailMessage = new MailMessage(sendFromAddress, sendToAddress);
            mailMessage.Subject = MailSubject;
            mailMessage.Body = MailMessage;

            try
            {
                sendMailClient.Send(mailMessage);
                // Clear the form fields associated with the properties below
                MailSubject = "";
                MailMessage = "";
                MailToAddress = "";
                FeedbackMessage = "<div class='alert alert-primary'>Email Sent!</div>";
            }
            catch (Exception ex)
            {
                FeedbackMessage = $"<div class='alert alert-danger'>Error sending email {ex.Message}</div>";
            }
            
        }

        public void OnPostClearForm()
        {
            FeedbackMessage = "<h2>Clear Form button clicked</h2>";
        }
        public void OnGet()
        {
            // Dependency Injection
            //var gmailUsername = Configuration["GmailCredentials:Username"];
            //var gmailAppPassword = Configuration["GmailCredentials:Password"];
            //FeedbackMessage = $"Gmail username = {gmailUsername} </br>";
            //FeedbackMessage += $"Gmail app password = {gmailAppPassword} </br>";
        }
    }
}
