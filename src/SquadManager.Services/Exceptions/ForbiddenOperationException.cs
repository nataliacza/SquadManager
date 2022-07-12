namespace SquadManager.Services.Exceptions;

public class ForbiddenOperationException : Exception
{
    public ForbiddenOperationException()
    {
    }

    public ForbiddenOperationException(string message)
        : base(message)
    {
    }

    public ForbiddenOperationException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}
