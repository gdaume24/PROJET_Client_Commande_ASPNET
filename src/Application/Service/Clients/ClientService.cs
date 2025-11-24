using Domain.Interfaces;

public class ClientService(
    IClientRepository repository,
    IUnitOfWork unitOfWork
    ) : IClientService
{
    public async Task<Client> CreateClient(CreateClientRequest clientRequest)
    {
    Client client = new Client
    {
        Nom = clientRequest.Nom!,
        Prenom = clientRequest.Prenom!,
        Email = clientRequest.Email!,
        Telephone = clientRequest.Telephone!,
        Adresse = clientRequest.Adresse!
    };
        unitOfWork.Clients.Add(client);
        await unitOfWork.SaveChangesAsync();   

        return client; 
    }   
    public async Task<IReadOnlyList<Client>> GetAllClients()
        => await unitOfWork.Clients.GetAll();
    
    public async Task<Client?> GetClientById(Guid id)
        => await unitOfWork.Clients.GetById(id);

    public async Task<Client> UpdateClient(Guid id, UpdateClientRequest request)    
    {
        Client client = new Client
        {
            Id = id,
            Nom = request.Nom!,
            Prenom = request.Prenom!,
            Email = request.Email!,
            Telephone = request.Telephone!,
            Adresse = request.Adresse!
        };
        unitOfWork.Clients.Update(client);
        await unitOfWork.SaveChangesAsync();
        return client;
    }
    
    public async Task<bool> DeleteClient(Guid id)
    {
        Client? client = await unitOfWork.Clients.GetById(id);
        if (client is null) return false;
        unitOfWork.Clients.Remove(client);
        await unitOfWork.SaveChangesAsync();
        return true;
    }
}













