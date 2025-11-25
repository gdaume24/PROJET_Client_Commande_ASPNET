public interface IClientService
{
    public Task<ClientResponseWithoutCommands> CreateClient(CreateClientRequest clientRequest);
    public Task<IReadOnlyList<ClientResponseWithoutCommands>> GetAllClients();
    public Task<ClientResponseWithoutCommands?> GetClientById(int id);
    public Task<IReadOnlyList<Commande>?> GetClientCommandesById(int id);
    public Task<ClientResponseWithoutCommands?> UpdateClient(int id, UpdateClientRequest request);    
    public Task<bool> DeleteClient(int id);
}