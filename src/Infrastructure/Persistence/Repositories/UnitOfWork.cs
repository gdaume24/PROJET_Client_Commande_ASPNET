using Domain.Interfaces;

public class UnitOfWork : IUnitOfWork
{
    private readonly DbStoreContext _context;

    public IClientRepository Clients { get; }
    public ICommandeRepository Commandes { get; }

    public UnitOfWork(DbStoreContext context,
                      IClientRepository clientRepository,
                      ICommandeRepository commandeRepository)
    {
        _context = context;

        Clients = clientRepository;
        Commandes = commandeRepository;
    }

    public Task<int> SaveChangesAsync()
        => _context.SaveChangesAsync();
}
