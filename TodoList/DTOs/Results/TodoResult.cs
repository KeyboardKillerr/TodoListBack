using System.Diagnostics.CodeAnalysis;

namespace TodoList.DTOs.Results;

public class TodoResult
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public bool IsCompleted { get; set; } = false;
}
