using Application.InfrastructurePort;
using Infrastructure.Database.Repositories;
using Itmo.Dev.Platform.Postgres.Extensions;
using Itmo.Dev.Platform.Postgres.Models;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Database;

public static class InfrastructureExtensions
{
    public static IServiceCollection AddInfrastructureDataAccess(
        this IServiceCollection collection,
        Action<PostgresConnectionConfiguration> configuration)
    {
        collection.AddPlatformPostgres(builder => builder.Configure(configuration));
        collection.AddPlatformMigrations(typeof(InfrastructureExtensions).Assembly);
        collection.AddScoped<IAccountRepository, AccountRepository>();
        collection.AddScoped<IAdminRepository, AdminRepository>();
        collection.AddScoped<IHistoryRepository, HistoryRepository>();

        return collection;
    }
}