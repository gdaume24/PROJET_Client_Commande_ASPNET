using Domain.Interfaces;

public interface IUnitOfWork
{
    IAuthenticationRepository Authentication { get; }
    IClientRepository Clients { get; }
    ICommandeRepository Commandes { get; }

    Task<int> SaveChangesAsync();
}