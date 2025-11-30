using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        string connectionString)
    {
        services.AddDbContext<DbStoreContext>(options =>
            options.UseSqlServer(connectionString)
        );

        services.AddScoped<IAuthenticationRepository, AuthenticationRepository>();
        services.AddScoped<IClientRepository, ClientRepository>();
        services.AddScoped<ICommandeRepository, CommandeRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }


}




