using Domain.Interfaces;

public class ClientRepository : IClientRepository
{
    private readonly DbStoreContext _context;

    public ClientRepository(DbStoreContext context)
    {
        _context = context;
    }

    public async Task Add(Client client) => await _context.Clients.AddAsync(client);

    public async Task<Client?> GetById(int id)
        => await _context.Clients.Include(x => x.Commandes).FirstOrDefaultAsync(x => x.Id == id);

    public async Task<IReadOnlyList<Client>> GetAll()
        => await _context.Clients.Include(x => x.Commandes).ToListAsync();

    public void Remove(Client client) => _context.Clients.Remove(client);
}
