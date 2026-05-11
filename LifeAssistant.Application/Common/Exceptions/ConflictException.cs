using System.Net;

namespace LifeAssistant.Application.Common.Exceptions;

public sealed class ConflictException : BaseException
{
    //Production Safe Message
    public ConflictException(string message) 
        : base(message, HttpStatusCode.Conflict)
    {
    }

    //For Internal Tracking
    public ConflictException(string resourceName, object key)
        : base($"{resourceName} with identifier '{key}' already exists.", HttpStatusCode.Conflict)
    {
    }
}