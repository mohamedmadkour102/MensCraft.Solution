using System.ComponentModel.DataAnnotations;

namespace MensCraft.Dto
{
	public class ResetPasswordDto
	{
		[Required(ErrorMessage = "الإيميل مطلوب")]
		[EmailAddress(ErrorMessage = "الإيميل غير صالح")]
		public string Email { get; set; }

		[Required(ErrorMessage = "الكود مطلوب")]
		public string ResetCode { get; set; }

		[Required(ErrorMessage = "كلمة المرور الجديدة مطلوبة")]
		[MinLength(6, ErrorMessage = "كلمة المرور يجب أن تكون 6 أحرف على الأقل")]
		public string NewPassword { get; set; }
	}
}
