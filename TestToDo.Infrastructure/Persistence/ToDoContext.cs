using Microsoft.EntityFrameworkCore;
using TestToDo.Entities;
using TestToDo.Infrastructure.Persistence.Configurations;

namespace TestToDo.Infrastructure.Persistence;

public class ToDoContext : DbContext
{
    public DbSet<ToDoItem>  ToDoItems { get; set; }
    public DbSet<Category> Categories { get; set; }
    
    public ToDoContext(DbContextOptions<ToDoContext> options) : base(options) {}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ToDoItemConfiguration).Assembly);
    }
}