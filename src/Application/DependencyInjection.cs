using Application.Commandes;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IClientService, ClientService>();
        services.AddScoped<ICommandeService, CommandeService>();
        services.AddValidatorsFromAssemblyContaining<CreateClientRequest>();
        services.AddValidatorsFromAssemblyContaining<UpdateClientRequest>();
        services.AddValidatorsFromAssemblyContaining<CreateCommandeRequest>();
        services.AddValidatorsFromAssemblyContaining<UpdateCommandeRequest>();

        return services;
    }
}