using Domain.Helpers;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Domain.Repositories;

public class TodoRepository(DataContext context, IErrorHandler? errorHandler) :
    RepositoryBase<Todo>(context, context.Todos, errorHandler)
{
    public override async Task<ICollection<Todo>> GetAllAsync()
    {
        try
        {
            return await context.Todos.ToListAsync();
        }
        catch (Exception ex)
        {
            if (errorHandler is null) throw;
            errorHandler.HandleError(ex);
            return [];
        }
    }
}
