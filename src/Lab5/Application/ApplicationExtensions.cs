using Application.PresentationPort;
using Microsoft.Extensions.DependencyInjection;

namespace BuisnessLogic;

public static class ApplicationExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection collection)
    {
        collection.AddScoped<IUserService, UserService>();
        collection.AddScoped<IAdminService, AdminService>();

        collection.AddScoped<CurrentRoleSession>();
        collection.AddScoped<ICurrentRoleSession>(
            p => p.GetRequiredService<CurrentRoleSession>());
        collection.AddScoped<CurrentUserSession>();
        collection.AddScoped<ICurrentUserSession>(
            p => p.GetRequiredService<CurrentUserSession>());

        return collection;
    }
}