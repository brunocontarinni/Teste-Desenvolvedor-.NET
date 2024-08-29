using System.Net;
using System.Text.Json.Serialization;
using lucas_gabriel_api.Resources.Exceptions;
using Microsoft.OpenApi.Any;

namespace lucas_gabriel_api.Resources.ExceptionsHandler;

public class ServiceExceptionHandler
{
    private readonly RequestDelegate _next;

    public ServiceExceptionHandler(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (ServiceException ex)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = ex.StatusCode;

            await context.Response.WriteAsJsonAsync(new Response<object>
            {
                Code = ex.StatusCode,
                Message = ex.Message,
            });
        }
        catch (Exception ex)
        {
            await HandleGeneralExceptionAsync(context, ex);
        }
    }

    private Task HandleGeneralExceptionAsync(HttpContext context, Exception ex)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

        return context.Response.WriteAsJsonAsync(new Response<AnyType>
        {
            Code = 500,
            Message = ex.Message
        });
    }
}
