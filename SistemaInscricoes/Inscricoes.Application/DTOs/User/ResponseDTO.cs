namespace Inscricoes.Application.DTOs.User;

public class ResponseDTO
{
	public string? Status { get; set; }
	public string? Message { get; set; }
	public List<string>? Errors { get; set; }
}
