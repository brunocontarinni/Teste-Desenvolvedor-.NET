using Microsoft.AspNetCore.Mvc;
using Inscricoes.Shared.Exceptions;
using Inscricoes.Shared.Constants;
using System.Net;
using System.Text.Json;

namespace Inscricoes.Api.Middleware;

public class ErrorHandlerMiddleware
{
	private readonly RequestDelegate _next;

	public ErrorHandlerMiddleware(RequestDelegate next)
	{
		_next = next;
	}

	public async Task Invoke(HttpContext context)
	{
		try
		{
			await _next(context);
		}
		catch (Exception ex)
		{
			await HandleExceptionAsync(context, ex);
		}
	}

	private static Task HandleExceptionAsync(HttpContext context, Exception exception)
	{
		var problemDetails = new CustomProblemDetails
		{
			Status = (int)HttpStatusCode.InternalServerError,
			Title = "Ocorreu um erro inesperado.",
			Type = exception.GetType().Name,
			Detail = exception.Message,
			Path = context.Request.Path,
			Method = context.Request.Method,
		};

		switch (exception)
		{
			case ExceptionBase customException:
				problemDetails.Status = (int)customException.Status;
				problemDetails.Title = "Erros de validação ocorreram.";

				if (customException.MessagesKeys.Any())
				{
					foreach (var error in customException.MessagesKeys)
					{
						problemDetails.Errors.Add(error.Key, error.Value);
					}
				}
				problemDetails.Errors.Add("_error", customException.MessageKey);
				break;

			default:
				problemDetails.Errors.Add("_error", MessageKeyConstants.MESSAGE_ERROR);
				break;
		}

		context.Response.ContentType = "application/json";
		context.Response.StatusCode = problemDetails.Status.Value;

		var result = JsonSerializer.Serialize(problemDetails);
		return context.Response.WriteAsync(result);
	}
}

public class CustomProblemDetails : ProblemDetails
{
	public IDictionary<string, string> Errors { get; set; } = new Dictionary<string, string>();
	public string Path { get; set; } = string.Empty;
	public string Method { get; set; } = string.Empty;
}
