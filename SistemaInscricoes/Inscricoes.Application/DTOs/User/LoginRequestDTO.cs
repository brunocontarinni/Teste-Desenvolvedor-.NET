using System.ComponentModel.DataAnnotations;

namespace Inscricoes.Application.DTOs.User;

public class LoginRequestDTO
{
	[Required(ErrorMessage = "User name is required")]
	public string? UserName { get; set; }

	[Required(ErrorMessage = "Password is required")]
	public string? Password { get; set; }
}
