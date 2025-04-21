using System.ComponentModel.DataAnnotations;

namespace MensCraft.Dto
{
	public class CustomerRegisterDto
	{
		[Required(ErrorMessage = "الاسم مطلوب")]
		public string Name { get; set; }

		[Required(ErrorMessage = "الإيميل مطلوب")]
		[EmailAddress(ErrorMessage = "الإيميل غير صالح")]
		public string Email { get; set; }

		[Required(ErrorMessage = "رقم الهاتف مطلوب")]
		[Phone(ErrorMessage = "رقم الهاتف غير صالح")]
		public string PhoneNumber { get; set; }

		[Required(ErrorMessage = "كلمة المرور مطلوبة")]
		[MinLength(6, ErrorMessage = "كلمة المرور يجب أن تكون 6 أحرف على الأقل")]
		public string Password { get; set; }

		[Required(ErrorMessage = "تأكيد كلمة المرور مطلوب")]
		public string ConfirmPassword { get; set; }

		[Required(ErrorMessage = "موقع السكن مطلوب")]
		public int LocationId { get; set; }

		[Required(ErrorMessage = "الشقة مطلوبة")]
		public int ApartmentId { get; set; }
	}
}
