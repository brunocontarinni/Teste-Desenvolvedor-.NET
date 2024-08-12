using System.Net;

namespace Inscricoes.Shared.Exceptions;

public class InscricaoNotFoundException : ExceptionBase
{
	public InscricaoNotFoundException(string messageKey)
	{
		Status = HttpStatusCode.NotFound;
		MessageKey = messageKey;
	}
}

public class LeadNotFoundException : ExceptionBase
{
	public LeadNotFoundException(string messageKey)
	{
		Status = HttpStatusCode.NotFound;
		MessageKey = messageKey;
	}
}

public class OfertaNotFoundException : ExceptionBase
{
	public OfertaNotFoundException(string messageKey)
	{
		Status = HttpStatusCode.NotFound;
		MessageKey = messageKey;
	}
}

public class ProcessoSeletivoNotFoundException : ExceptionBase
{
	public ProcessoSeletivoNotFoundException(string messageKey)
	{
		Status = HttpStatusCode.NotFound;
		MessageKey = messageKey;
	}
}