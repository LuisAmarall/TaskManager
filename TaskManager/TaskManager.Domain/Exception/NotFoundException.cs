namespace TaskManager.Domain.Exception;

public sealed class NotFoundException : FormatException
{
    public NotFoundException(string message) : base(message) { }
}
