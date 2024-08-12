using System.Net;

namespace Inscricoes.Shared.Exceptions;

public class ExceptionBase : Exception
{
	public string MessageKey { get; set; } = string.Empty;
	public Dictionary<string, string> MessagesKeys { get; set; } = new Dictionary<string, string>();
	public HttpStatusCode Status { get; set; }
}
