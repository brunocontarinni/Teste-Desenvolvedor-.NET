using Microsoft.Extensions.Configuration;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;

namespace Inscricoes.Application.Interfaces;

public interface ITokenService
{
	JwtSecurityToken GenerateAccessToken(IEnumerable<Claim> claims,
										 IConfiguration _config);
	string GenerateRefreshToken();

	ClaimsPrincipal GetPrincipalFromExpiredToken(string token,
												 IConfiguration _config);
}
