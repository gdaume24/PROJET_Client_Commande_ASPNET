// using Domain.Interfaces;
// using Microsoft.EntityFrameworkCore;
// using Microsoft.Extensions.Configuration;
// using Microsoft.Extensions.DependencyInjection;

// namespace Domain;

// public static class DependencyInjection
// {
//     public static IServiceCollection AddDomain(
//         this IServiceCollection services,
//         IConfiguration configuration)
//     {
//         services.AddScoped<IClientRepository, ClientRepository>();
//         // services.AddScoped<ICommandeRepository, CommandeRepository>();
//         services.AddScoped<IClientRepository, ClientRepository>();
//         services.AddScoped<IUnitOfWork, UnitOfWork>();
//         services.AddDbContext<DbStoreContext>(options =>
//     options.UseSqlServer(
//         configuration.GetConnectionString("DefaultConnection")
//     )
// );

//         return services;
//     }

// }



