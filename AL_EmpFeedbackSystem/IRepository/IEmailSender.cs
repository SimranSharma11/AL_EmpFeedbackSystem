namespace AL_EmpFeedbackSystem.IRepository
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string body);
    }

}
