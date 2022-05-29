using Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Context;

namespace Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSqlite<ApplicationDbContext>(configuration.GetConnectionString("DefaultConnection")!);
        services.AddScoped<IApplicationDbContext>(provider => provider.GetService<ApplicationDbContext>()!);

        return services;
    }
}
