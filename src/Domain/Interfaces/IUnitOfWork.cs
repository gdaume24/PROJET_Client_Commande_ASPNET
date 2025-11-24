using Domain.Interfaces;

public interface IUnitOfWork
{
    IClientRepository Clients { get; }
    ICommandeRepository Commandes { get; }

    Task<int> SaveChangesAsync();
}