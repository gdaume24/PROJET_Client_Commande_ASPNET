using Domain.Interfaces;

public class UnitOfWork : IUnitOfWork
{
    private readonly DbStoreContext _context;

    public IAuthenticationRepository Authentication { get; }
    public IClientRepository Clients { get; }
    public ICommandeRepository Commandes { get; }

    public UnitOfWork(DbStoreContext context,
                      IAuthenticationRepository authenticationRepository,
                      IClientRepository clientRepository,
                      ICommandeRepository commandeRepository)
    {
        _context = context;

        Authentication = authenticationRepository;
        Clients = clientRepository;
        Commandes = commandeRepository;
    }

    public Task<int> SaveChangesAsync()
        => _context.SaveChangesAsync();
}
