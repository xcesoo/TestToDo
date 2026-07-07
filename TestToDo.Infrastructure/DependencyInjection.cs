using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TestToDo.Infrastructure.Persistence;

namespace TestToDo.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ToDoContext>(o =>
        {
            o.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
        });
        return services;
    }
}