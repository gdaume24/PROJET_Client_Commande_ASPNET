using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class CommandeRepository : ICommandeRepository
{
    private readonly AppDbContext _context;

    public CommandeRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task Add(Commande commande)
    {
        await _context.Commandes.AddAsync(commande);
    }

    public async Task<Commande?> GetById(int id)
    {
        return await _context.Commandes
            .Include(c => c.Client)
            .FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<IReadOnlyList<Commande>> GetAll()
    {
        return await _context.Commandes
            .Include(c => c.Client)
            .ToListAsync();
    }

    public void Remove(Commande commande)
    {
        _context.Commandes.Remove(commande);
    }
}
