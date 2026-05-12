using System.Net;

namespace LifeAssistant.Application.Common.Exceptions;

public sealed class NotFoundException : BaseException
{
    public NotFoundException(string message)
        : base(message, HttpStatusCode.NotFound) { }

    public NotFoundException(string resourceName, object key)
        : base($"{resourceName} with identifier '{key}' was not found.", HttpStatusCode.NotFound)
    { }
}
