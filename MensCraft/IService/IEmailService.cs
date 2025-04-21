using System.Net.Mail;
using System.Net;

namespace MensCraft.IService
{
	public interface IEmailService
	{
		Task SendEmailAsync(string toEmail, string subject, string body);
	}
}
