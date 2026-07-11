using Microsoft.EntityFrameworkCore;
using TestToDo.Entities;
using TestToDo.Infrastructure.Persistence.Configurations;

namespace TestToDo.Infrastructure.Persistence;

public class ToDoContext : DbContext
{
    public DbSet<ToDoItem>  ToDoItems { get; set; }
    public DbSet<Category> Categories { get; set; }
    
    public DbSet<User> Users { get; set; }
    public DbSet<RefreshToken> RefreshTokens { get; set; }
    public ToDoContext(DbContextOptions<ToDoContext> options) : base(options) {}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder); 
        modelBuilder.HasPostgresExtension("pg_trgm");
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ToDoItemConfiguration).Assembly);
    }
}