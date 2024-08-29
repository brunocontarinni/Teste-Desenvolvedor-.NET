using Microsoft.OpenApi.Any;

namespace lucas_gabriel_api.Resources;



public class Response<T>
{
    public int Code { get; set; } = 400;
    public string Message { get; set; } = string.Empty;
    public List<T> Data { get; set; } = new List<T>();

}

