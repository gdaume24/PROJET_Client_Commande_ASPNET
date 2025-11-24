public interface IClientService
{
    public Task<ClientResponse> CreateClient(CreateClientRequest clientRequest);
    public Task<IReadOnlyList<ClientResponse>> GetAllClients();
    public Task<ClientResponse?> GetClientById(int id);
    public Task<IReadOnlyList<Commande>?> GetClientCommandesById(int id);
    public Task<ClientResponse?> UpdateClient(int id, UpdateClientRequest request);    
    public Task<bool> DeleteClient(int id);
}