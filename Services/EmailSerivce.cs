namespace TASK_SYS.Services
{
    using SendGrid;
    using SendGrid.Helpers.Mail;
    using Microsoft.Extensions.Configuration;
    using TASK_SYS.Services.Interfaces;

    public class EmailService : IEmailService
    {
        private readonly IConfiguration _configuration;

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task SendTaskReminderEmailAsync(string userEmail, string taskTitle, DateTime dueDate)
        {
            var apiKey = _configuration[""];
            var client = new SendGridClient(apiKey);
            var msg = new SendGridMessage
            {
                From = new EmailAddress("email@example.com", "Task Management App"),
                Subject = "Task Reminder",
                PlainTextContent = $"Your task '{taskTitle}' is due on {dueDate:MMMM dd, yyyy}. Please complete it on time.",
                HtmlContent = $"<strong>Your task '{taskTitle}' is due on {dueDate:MMMM dd, yyyy}. Please complete it on time.</strong>"
            };
            msg.AddTo(new EmailAddress(userEmail));

            await client.SendEmailAsync(msg);
        }
    }
}
