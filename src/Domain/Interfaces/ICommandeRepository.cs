using Domain.Entities;

namespace Domain.Interfaces;

public interface ICommandeRepository
{
    Task Add(Commande commande);
    Task<Commande?> GetById(int id);
    Task<IReadOnlyList<Commande>> GetAll();
    void Remove(Commande commande);
}