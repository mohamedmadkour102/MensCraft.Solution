using System.ComponentModel.DataAnnotations;

namespace MensCraft.Dto
{
	public class LoginDto
	{
		[Required(ErrorMessage = "الإيميل مطلوب")]
		[EmailAddress(ErrorMessage = "الإيميل غير صالح")]
		public string Email { get; set; }

		[Required(ErrorMessage = "كلمة المرور مطلوبة")]
		public string Password { get; set; }
	}
}
