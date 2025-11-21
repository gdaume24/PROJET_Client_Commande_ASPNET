public interface IClientService
{
    void CreateClient(CreateClientDto newClient);
    List<ClientDto> GetAllClients();
    ClientDto? GetClientById(int id);
    void UpdateClient(int id, UpdateClientDto updatedClient);
    void DeleteClient(int id);
}