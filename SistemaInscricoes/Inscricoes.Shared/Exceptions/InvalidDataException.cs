using System.Net;

namespace Inscricoes.Shared.Exceptions;

public class InscricaoException : ExceptionBase
{
	public InscricaoException(string messageKey)
	{
		Status = HttpStatusCode.BadRequest;
		MessageKey = messageKey;
	}
}

public class OfertaException : ExceptionBase
{
	public OfertaException(string messageKey)
	{
		Status = HttpStatusCode.BadRequest;
		MessageKey = messageKey;
	}
}

public class LeadException : ExceptionBase
{
	public LeadException(string messageKey)
	{
		Status = HttpStatusCode.BadRequest;
		MessageKey = messageKey;
	}
}

public class ProcessoSeletivoException : ExceptionBase
{
	public ProcessoSeletivoException(string messageKey)
	{
		Status = HttpStatusCode.BadRequest;
		MessageKey = messageKey;
	}
}
