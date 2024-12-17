using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Domain;

public class DataContext : DbContext
{
    public virtual DbSet<Todo> Todos { get; set; } = null!;

    public DataContext()
    {
        //Database.EnsureDeleted();
        Database.EnsureCreated();
    }

    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
        //Database.EnsureDeleted();
        Database.EnsureCreated();
    }
}
