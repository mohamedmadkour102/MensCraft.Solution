using System.ComponentModel.DataAnnotations;

namespace MensCraft.Dto
{
	public class ForgotPasswordDto
	{
		[Required(ErrorMessage = "الإيميل مطلوب")]
		[EmailAddress(ErrorMessage = "الإيميل غير صالح")]
		public string Email { get; set; }
	}
}
