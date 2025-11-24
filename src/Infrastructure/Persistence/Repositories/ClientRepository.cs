using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

public class ClientRepository : IClientRepository
{
    private readonly DbStoreContext _context;

    public ClientRepository(DbStoreContext context)
    {
        _context = context;
    }
    public void Add(Client client) 
        => _context.Clients.Add(client);

    public async Task<IReadOnlyList<Client>> GetAll()
        => await _context.Clients.Include(x => x.Commandes).ToListAsync();

    public async Task<Client?> GetById(int id)
        => await _context.Clients.FirstOrDefaultAsync(x => x.Id == id);
    public async Task<Client?> GetByIdWithCommandes(int id)
        => await _context.Clients
            .Include(c => c.Commandes)
            .FirstOrDefaultAsync(c => c.Id == id);
    public void Update(Client client)
        => _context.Clients.Update(client);

    public void Remove(Client client)
        => _context.Clients.Remove(client);
}
