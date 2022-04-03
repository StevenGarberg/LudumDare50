namespace LudumDare50.API.Exceptions;

public abstract class ApiException : Exception
{
    public int? StatusCode { get; }

    protected ApiException() { }
    protected ApiException(string message, int? statusCode = null) : base(message)
    {
        StatusCode = statusCode ?? StatusCode;
    }
}