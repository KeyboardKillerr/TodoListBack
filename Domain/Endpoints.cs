using Domain.Helpers;
using Domain.Models;
using Domain.Repositories;

namespace Domain;

public class Endpoints
{
    public IRepository<Todo> Todos { get; private init; }

    public Endpoints(DataContext dataContext)
    {
        var errorHandler = new ErrorHandler();
        Todos = new TodoRepository(dataContext, errorHandler);
    }
}
