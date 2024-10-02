using System.Net;

namespace DepsMvp.Application.DTOs;

public class ResponseGeneric<T> where T : class
{
    public HttpStatusCode HttpCode { get; set; }
    public T? ReturnData { get; set; }
    public ErrorDetails? ErrorResponse { get; set; }

    public static ResponseGeneric<T> Success(T data, HttpStatusCode code = HttpStatusCode.OK)
    {
        return new ResponseGeneric<T>
        {
            HttpCode = code,
            ReturnData = data
        };
    }

    public static ResponseGeneric<T> Fail(HttpStatusCode code, string message)
    {
        return new ResponseGeneric<T>
        {
            HttpCode = code,
            ErrorResponse = new ErrorDetails { Message = message }
        };
    }
}

public class ErrorDetails
{
    public string Message { get; set; }
    public string? Details { get; set; }
}