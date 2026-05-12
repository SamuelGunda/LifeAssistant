using System.Net;

namespace LifeAssistant.Application.Common.Exceptions;

public abstract class BaseException(
    string message,
    HttpStatusCode statusCode = HttpStatusCode.InternalServerError
) : Exception(message)
{
    public HttpStatusCode StatusCode { get; } = statusCode;
}
