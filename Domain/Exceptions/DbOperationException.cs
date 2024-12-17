using Domain.Models;

namespace Domain.Exceptions;

public class DbOperationException : Exception
{
    protected virtual EntityBase? Entity { get; set; }

    protected static string MakeMessage(string? message, EntityBase? entity)
    {
        message ??= string.Empty;
        if (entity is null) return message;
        if (message == string.Empty) return $"Entity: {entity.GetType()}\nId: {entity.Id}";
        return $"{message}\nEntity: {entity.GetType()}\nId: {entity.Id}";
    }

    public DbOperationException() : base() { }
    public DbOperationException(string? message, EntityBase? entity) : base(MakeMessage(message, entity))
    {
        Entity = entity;
    }
    public DbOperationException(string? message, EntityBase? entity, Exception? innerException) : base(MakeMessage(message, entity), innerException)
    {
        Entity = entity;
    }
}
