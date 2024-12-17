using Domain.Models;
using TodoList.DTOs.Requests;
using TodoList.DTOs.Results;

namespace TodoList.Mappers;

public static class TodoMapper
{
    public static Todo FromRequest(this TodoRequest todoRequest)
    {
        var todo = new Todo()
        {
            Name = todoRequest.Name,
            IsCompleted = todoRequest.IsCompleted
        };
        return todo;
    }

    public static TodoResult ToResult(this Todo todo)
    {
        var todoResult = new TodoResult()
        {
            Id = todo.Id,
            Name = todo.Name,
            IsCompleted = todo.IsCompleted
        };
        return todoResult;
    }

    public static IList<TodoResult> ToResults(this ICollection<Todo> todos)
    {
        var todoResults = new List<TodoResult>(todos.Count);
        foreach (var todo in todos)
        {
            todoResults.Add(todo.ToResult());
        }
        return todoResults;
    }
}
