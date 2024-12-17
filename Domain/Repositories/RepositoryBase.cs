using Domain.Exceptions;
using Domain.Helpers;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;

namespace Domain.Repositories;

public abstract class RepositoryBase<T>(DataContext context, IQueryable<T> items, IErrorHandler? errorHandler)
    : IRepository<T> where T : EntityBase
{
    protected readonly DataContext context = context ?? throw new ArgumentNullException(nameof(context));
    protected readonly IErrorHandler? errorHandler = errorHandler;
    public IQueryable<T> Items { get; init; } = items ?? throw new ArgumentNullException(nameof(items));

    public virtual async Task CreateAsync(T entity)
    {
        try
        {
            ArgumentNullException.ThrowIfNull(entity, nameof(entity));
            var item = await Items.FirstOrDefaultAsync(x => x.Id == entity.Id);
            if (item != default) throw new AlreadyExistsException(entity);
            await context.AddAsync(entity);
            await context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            if (errorHandler is null) throw;
            errorHandler.HandleError(ex);
        }
    }

    public virtual async Task<T?> GetItemByIdAsync(int id)
    {
        try
        {
            var item = await Items.FirstOrDefaultAsync(x => x.Id == id);
            if (item == default) throw new NotFoundException(new EntityBase() { Id = id });
            return item;
        }
        catch (Exception ex)
        {
            if (errorHandler is null) throw;
            errorHandler.HandleError(ex);
            return default;
        }
    }

    public virtual async Task<T> UpdateAsync(T entity, int id)
    {
        try
        {
            ArgumentNullException.ThrowIfNull(entity, nameof(entity));
            var item = await Items.FirstOrDefaultAsync(x => x.Id == id);
            if (item == default) throw new NotFoundException(entity);
            context.Entry(item).State = EntityState.Detached;
            entity.Id = id;
            context.Update(entity);
            await context.SaveChangesAsync();
            return entity;
        }
        catch (Exception ex)
        {
            if (errorHandler is null) throw;
            errorHandler.HandleError(ex);
            return entity;
        }
    }

    public virtual async Task DeleteAsync(int id)
    {
        try
        {
            var item = await Items.FirstOrDefaultAsync(x => x.Id == id);
            if (item == default) throw new NotFoundException(new EntityBase() { Id = id });
            context.Remove(item);
            await context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            if (errorHandler is null) throw;
            errorHandler.HandleError(ex);
        }
    }

    public abstract Task<ICollection<T>> GetAllAsync();
}
