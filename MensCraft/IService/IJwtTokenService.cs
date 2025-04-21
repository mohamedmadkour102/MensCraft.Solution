using MensCraft.Data.Models;

namespace MensCraft.IService
{
	public interface IJwtTokenService
	{
		string GenerateToken(User user, IList<string> roles);
	}
}
