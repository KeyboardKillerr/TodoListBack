using Domain.Models;

namespace Domain.Exceptions;

public class AlreadyExistsException : DbOperationException
{
    private const string defaultMessage = "Item already exists in table.";


    public AlreadyExistsException() : base() { }
    public AlreadyExistsException(EntityBase? entity)
        : base(defaultMessage, entity) { }
    public AlreadyExistsException(string? message, EntityBase? entity)
        : base(message ?? defaultMessage, entity) { }
    public AlreadyExistsException(string? message, EntityBase? entity, Exception? innerException)
        : base(message ?? defaultMessage, entity, innerException) { }
}
