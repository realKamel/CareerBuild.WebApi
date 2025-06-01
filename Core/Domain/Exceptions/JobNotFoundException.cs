namespace Domain.Exceptions;

public class JobNotFoundException(string message) : NotFoundException(message)
{
}