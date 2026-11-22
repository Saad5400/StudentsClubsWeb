using Microsoft.AspNetCore.Identity.UI.Services;

namespace StudentsClubsWeb.Utilities
{
    /// <summary>
    /// The archived deployment sends no email. The previous implementation
    /// logged in to a personal Gmail account with a password hard-coded in
    /// this public repository; that credential must be treated as leaked.
    /// </summary>
    public class EmailSender : IEmailSender
    {
        private readonly ILogger<EmailSender> _logger;

        public EmailSender(ILogger<EmailSender> logger)
        {
            _logger = logger;
        }

        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            _logger.LogInformation("Email sending is disabled on the archive; dropped message \"{Subject}\".", subject);

            return Task.CompletedTask;
        }
    }
}
