using System.Net;

namespace LifeAssistant.Application.Common.Exceptions;

public sealed class ConflictException : BaseException
{
    public ConflictException(string message) 
        : base(message, HttpStatusCode.Conflict)
    {
    }
    
    public ConflictException(string resourceName, object key)
        : base($"{resourceName} with identifier '{key}' already exists.", HttpStatusCode.Conflict)
    {
    }
}