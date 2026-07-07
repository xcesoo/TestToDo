using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TestToDo.Infrastructure.Persistence;
using TestToDo.Infrastructure.Repositories;
using TestToDo.Interfaces;

namespace TestToDo.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ToDoContext>(o =>
        {
            o.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
        });
        services.AddScoped<IToDoItemRepository, ToDoItemRepository>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        return services;
    }
}