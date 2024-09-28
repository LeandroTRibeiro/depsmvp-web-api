using System.Dynamic;
using System.Net;

namespace DepsMvp.Application.DTOs;

public class ResponseGeneric<T> where T : class
{
    public HttpStatusCode HttpCode { get; set; }
    public T? ReturnData { get; set; }
    public ExpandoObject? ErrorResponse { get; set; }

}