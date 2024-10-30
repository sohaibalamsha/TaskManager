namespace TASK_SYS.Services.Interfaces
{
    public interface IEmailService
    {
        Task SendTaskReminderEmailAsync(string userEmail, string taskTitle, DateTime dueDate);
    }
}
