using Domain.Interfaces;

public class ClientService : IClientService
{
    private readonly IClientRepository _repository;
    public ClientService(IClientRepository _repository)
    {
        _repository = repository;
    }

    public void CreateClient(CreateClientDto newClient)
    {
        Client client = ClientMapping.ToEntity(newClient);
        _context.Clients.Add(client);
        _context.SaveChanges();
    }   
    public List<ClientDto> GetAllClients()
    {
        var clientsDto = _context.Clients   
            .Select(c => c.ToDto())
                .ToList();
            return clientsDto;
    }

    public ClientDto? GetClientById(int id)
    {
        var client = _context.Clients
            .Include(c => c.Commandes)
                .FirstOrDefault(c => c.Id == id);
            return (client is null) ? null : client.ToDto();
    }

    public void UpdateClient(int id, UpdateClientDto updatedClient) 
    {
        var existingClient = _context.Clients.Find(id);
        if (existingClient == null)
            {
                throw new ClientNotFoundException($"Le client avec l'ID {id} n'existe pas.");
            }
            _context.Entry(existingClient).CurrentValues.SetValues(updatedClient.ToEntity(id));   
            _context.SaveChanges();
    }

    public void DeleteClient(int id)
    {
            var client = _context.Clients.First(c => c.Id == id);
            _context.Clients.Remove(client);
            _context.SaveChanges();
    }
}













