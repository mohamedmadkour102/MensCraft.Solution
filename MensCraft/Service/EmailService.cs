using System.Net.Mail;
using System.Net;
using MensCraft.IService;
public class EmailService : IEmailService
{
	private readonly IConfiguration _configuration;

	public EmailService(IConfiguration configuration)
	{
		_configuration = configuration;
	}

	public async Task SendEmailAsync(string toEmail, string subject, string body)
	{
		var smtpClient = new SmtpClient(_configuration["Email:SmtpHost"], int.Parse(_configuration["Email:SmtpPort"]))
		{
			Credentials = new NetworkCredential(_configuration["Email:SmtpUser"], _configuration["Email:SmtpPass"]),
			EnableSsl = true
		};

		var mailMessage = new MailMessage
		{
			From = new MailAddress(_configuration["Email:SmtpUser"]),
			Subject = subject,
			Body = body,
			IsBodyHtml = false
		};
		mailMessage.To.Add(toEmail);

		await smtpClient.SendMailAsync(mailMessage);
	}
}