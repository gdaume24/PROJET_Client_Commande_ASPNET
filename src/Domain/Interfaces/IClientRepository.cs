namespace Domain.Interfaces;

public interface IClientRepository
{
    void Add(Client client);
    Task<IReadOnlyList<Client>> GetAll();
    Task<Client?> GetById(int id);
    Task<Client?> GetByIdWithCommandes(int id);
    void Remove(Client client);
}
