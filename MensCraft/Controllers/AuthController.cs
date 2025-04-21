using MensCraft.Data.Models;
using MensCraft.Dto;
using MensCraft.IService;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
	private readonly ApplicationDbContext _context;
	private readonly UserManager<User> _userManager;
	private readonly SignInManager<User> _signInManager;
	private readonly IJwtTokenService _jwtTokenService;
	private readonly IEmailService _emailService;

	public AuthController(
		ApplicationDbContext context,
		UserManager<User> userManager,
		SignInManager<User> signInManager,
		IJwtTokenService jwtTokenService,
		IEmailService emailService)
	{
		_context = context;
		_userManager = userManager;
		_signInManager = signInManager;
		_jwtTokenService = jwtTokenService;
		_emailService = emailService;
	}

	[HttpPost("register/craftsman")]
	public async Task<IActionResult> RegisterCraftsman([FromBody] CraftsmanRegisterDto dto)
	{
		if (dto.Password != dto.ConfirmPassword)
			return BadRequest("كلمة المرور وتأكيد كلمة المرور غير متطابقتين");

		var craftsman = new Craftsman
		{
			UserName = dto.Email,
			Email = dto.Email,
			Name = dto.Name,
			PhoneNumber = dto.PhoneNumber,
			CityId = dto.CityId,
			OccupationId = dto.OccupationId
		};

		var result = await _userManager.CreateAsync(craftsman, dto.Password);
		if (!result.Succeeded)
			return BadRequest(result.Errors);

		await _userManager.AddToRoleAsync(craftsman, "Craftsman");

		var roles = await _userManager.GetRolesAsync(craftsman);

		var token = _jwtTokenService.GenerateToken(craftsman, roles);

		return Ok(new { Token = token, Role = "Craftsman" });
	}


	[HttpPost("register/customer")]
	public async Task<IActionResult> RegisterCustomer([FromBody] CustomerRegisterDto dto)
	{
		if (dto.Password != dto.ConfirmPassword)
			return BadRequest("كلمة المرور وتأكيد كلمة المرور غير متطابقتين");

		var customer = new Customer
		{
			UserName = dto.Email,
			Email = dto.Email,
			Name = dto.Name,
			PhoneNumber = dto.PhoneNumber,
			LocationId = dto.LocationId,
			ApartmentId = dto.ApartmentId
		};

		var result = await _userManager.CreateAsync(customer, dto.Password);
		if (!result.Succeeded)
			return BadRequest(result.Errors);

		await _userManager.AddToRoleAsync(customer, "Customer");

		var roles = await _userManager.GetRolesAsync(customer);

		var token = _jwtTokenService.GenerateToken(customer, roles);

		return Ok(new { Token = token, Role = "Customer" });
	}


	// تسجيل الدخول
	[HttpPost("login")]
	public async Task<IActionResult> Login([FromBody] LoginDto dto)
	{
		var user = await _userManager.FindByEmailAsync(dto.Email);
		if (user == null)
			return Unauthorized("الإيميل غير موجود");

		var result = await _signInManager.CheckPasswordSignInAsync(user, dto.Password, false);
		if (!result.Succeeded)
			return Unauthorized("كلمة المرور غير صحيحة");

		var roles = await _userManager.GetRolesAsync(user);
		var token = _jwtTokenService.GenerateToken(user, roles);

		return Ok(new { Token = token, Role = roles.FirstOrDefault() });
	}

	// نسيان كلمة المرور
	[HttpPost("forgot-password")]
	public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordDto dto)
	{
		var user = await _userManager.FindByEmailAsync(dto.Email);
		if (user == null)
			return NotFound("الإيميل غير موجود");

		var resetCode = new Random().Next(100000, 999999).ToString();
		user.PasswordResetCode = resetCode;
		user.ResetCodeExpiry = DateTime.UtcNow.AddHours(1);
		await _context.SaveChangesAsync();

		await _emailService.SendEmailAsync(user.Email, "إعادة تعيين كلمة المرور", $"كود إعادة التعيين: {resetCode}");

		return Ok("تم إرسال كود إعادة التعيين إلى بريدك الإلكتروني");
	}

	// إعادة تعيين كلمة المرور
	[HttpPost("reset-password")]
	public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordDto dto)
	{
		var user = await _context.Users
			.FirstOrDefaultAsync(u => u.Email == dto.Email && u.PasswordResetCode == dto.ResetCode);

		if (user == null)
			return BadRequest("الكود غير صحيح");

		if (user.ResetCodeExpiry < DateTime.UtcNow)
			return BadRequest("الكود منتهي الصلاحية");

		var token = await _userManager.GeneratePasswordResetTokenAsync(user);
		var result = await _userManager.ResetPasswordAsync(user, token, dto.NewPassword);
		if (!result.Succeeded)
			return BadRequest(result.Errors);

		user.PasswordResetCode = null;
		user.ResetCodeExpiry = null;
		await _context.SaveChangesAsync();

		return Ok("تم تغيير كلمة المرور بنجاح");
	}

	// إندبوينت لجلب المدن
	[HttpGet("cities")]
	public async Task<IActionResult> GetCities()
	{
		var cities = await _context.Cities.ToListAsync();
		return Ok(cities);
	}

	// إندبوينت لجلب المهن
	[HttpGet("occupations")]
	public async Task<IActionResult> GetOccupations()
	{
		var occupations = await _context.Occupations.ToListAsync();
		return Ok(occupations);
	}

	// إندبوينت لجلب الشقق
	[HttpGet("apartments")]
	public async Task<IActionResult> GetApartments()
	{
		var apartments = await _context.Apartments.ToListAsync();
		return Ok(apartments);
	}
}