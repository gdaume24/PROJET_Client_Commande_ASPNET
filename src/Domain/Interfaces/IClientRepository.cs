namespace Domain.Interfaces;

public interface IClientRepository
{
    Task Add(Client client);
    Task<Client?> GetById(int id);
    Task<IReadOnlyList<Client>> GetAll();
    void Remove(Client client);
}
