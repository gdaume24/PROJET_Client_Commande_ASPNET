using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

public class CommandeRepository : ICommandeRepository
{
    private readonly DbStoreContext _context;

    public CommandeRepository(DbStoreContext context)
    {
        _context = context;
    }
    public void Add(Commande commande) 
        => _context.Commandes.Add(commande);

    public async Task<IReadOnlyList<Commande>> GetAll()
        => await _context.Commandes.Include(x => x.Client).ToListAsync();
    public async Task<Commande?> GetById(int id)
        => await _context.Commandes.Include(x => x.Client).FirstOrDefaultAsync(x => x.Id == id);

    public void Update(Commande commande)
        => _context.Commandes.Update(commande);

    public void Remove(Commande commande)
        => _context.Commandes.Remove(commande);
}
