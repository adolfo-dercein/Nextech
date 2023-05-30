
using System.Net;

namespace Nextech.Core.Response;

public class Response<T> where T : new()
{
    public T Data { get; set; } = new T();

    public string Message { get; set; } = string.Empty;

    public HttpStatusCode StatusCode { get; set; }

    public bool Success { get; set; }
}
