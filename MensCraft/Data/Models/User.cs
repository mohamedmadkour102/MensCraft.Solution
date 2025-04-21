using Microsoft.AspNetCore.Identity;

namespace MensCraft.Data.Models
{
	public class User : IdentityUser<int> 
	{
		public string Name { get; set; }
		public string? PasswordResetCode { get; set; }
		public DateTime? ResetCodeExpiry { get; set; }
	}
}
