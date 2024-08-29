using Microsoft.OpenApi.Any;

namespace lucas_gabriel_api.Resources.Exceptions;

public class ServiceException : Exception
{
    public ServiceException(int statusCode, string message)
    {
        StatusCode = statusCode;
        Message = message;
    }

    public int StatusCode { get; }
    public override string Message { get; }

}