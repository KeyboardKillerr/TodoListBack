using Domain.Models;

namespace Domain.Exceptions;

public class NotFoundException : DbOperationException
{
    private const string defaultMessage = "Item was not found in table.";

    public NotFoundException() : base() { }
    public NotFoundException(EntityBase? entity)
        : base(defaultMessage, entity) { }
    public NotFoundException(string? message, EntityBase? entity)
        : base(message ?? defaultMessage, entity) { }
    public NotFoundException(string? message, EntityBase? entity, Exception? innerException)
        : base(message ?? defaultMessage, entity, innerException) { }
}
