using System.Diagnostics.CodeAnalysis;

namespace TodoList.DTOs.Requests;

public class TodoRequest
{
    public string Name { get; set; } = null!;
    public bool IsCompleted { get; set; } = false;
}
