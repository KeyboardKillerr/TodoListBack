namespace Domain.Models;

public class Todo : EntityBase
{
    public string Name { get; set; } = null!;
    public bool IsCompleted { get; set; } = false;
}
