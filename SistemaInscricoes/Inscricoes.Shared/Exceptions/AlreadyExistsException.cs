using System.Net;

namespace Inscricoes.Shared.Exceptions;

public class InscricaoAlreadyExistsException : ExceptionBase
{
	public InscricaoAlreadyExistsException(string messageKey)
	{
		Status = HttpStatusCode.BadRequest;
		MessageKey = messageKey;
	}
}

public class LeadAlreadyExistsException : ExceptionBase
{
	public LeadAlreadyExistsException(string messageKey)
	{
		Status = HttpStatusCode.BadRequest;
		MessageKey = messageKey;
	}
}

public class OfertaAlreadyExistsException : ExceptionBase
{
	public OfertaAlreadyExistsException(string messageKey)
	{
		Status = HttpStatusCode.BadRequest;
		MessageKey = messageKey;
	}
}

public class ProcessoSeletivoAlreadyExistsException : ExceptionBase
{
	public ProcessoSeletivoAlreadyExistsException(string messageKey)
	{
		Status = HttpStatusCode.BadRequest;
		MessageKey = messageKey;
	}
}



