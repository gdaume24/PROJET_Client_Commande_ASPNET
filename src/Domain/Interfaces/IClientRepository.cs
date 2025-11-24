namespace Domain.Interfaces;

public interface IClientRepository
{
    void Add(Client client);
    Task<IReadOnlyList<Client>> GetAll();
    Task<Client?> GetById(Guid id);
    void Update(Client client);
    void Remove(Client client);
}
