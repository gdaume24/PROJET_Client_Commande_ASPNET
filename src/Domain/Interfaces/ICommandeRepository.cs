namespace Domain.Interfaces;

public interface ICommandeRepository
{
    void Add(Commande commande);
    Task<IReadOnlyList<Commande>> GetAll();
    Task<Commande?> GetById(int id);
    void Remove(Commande commande);
}