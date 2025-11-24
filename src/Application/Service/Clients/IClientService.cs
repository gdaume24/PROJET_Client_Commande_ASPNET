public interface IClientService
{
    Task<ClientResponse> CreateClient(CreateClientRequest newClient);
    Task<List<ClientResponse>> GetAllClients();
    Task<ClientResponse?> GetClientById(Guid id);
    Task<ClientResponse> UpdateClient(Guid id, UpdateClientRequest updatedClient);
    Task<bool> DeleteClient(Guid id);
}