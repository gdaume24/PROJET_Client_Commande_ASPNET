using Domain.Interfaces;

public class ClientService(
    IUnitOfWork unitOfWork
    ) : IClientService
{
    public async Task<ClientResponse> CreateClient(CreateClientRequest clientRequest)
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

        return client.ToResponse();
    }   
    public async Task<IReadOnlyList<ClientResponse>> GetAllClients()
        => (await unitOfWork.Clients.GetAll()).Select(c => c.ToResponse()).ToList();
    
    public async Task<ClientResponse?> GetClientById(int id)
    {
        Client? client = await unitOfWork.Clients.GetById(id);
        return client?.ToResponse();
    }
    public async Task<IReadOnlyList<Commande>?> GetClientCommandesById(int id)
    {
        var client = await unitOfWork.Clients.GetByIdWithCommandes(id);

        if (client is null)
            return new List<Commande>();

        return client.Commandes.ToList();
    }

    public async Task<ClientResponse?> UpdateClient(int id, UpdateClientRequest request)    
    {
        Client? existingClient = await unitOfWork.Clients.GetById(id);
        if (existingClient is null) return null;
        existingClient.Nom = request.Nom!;
        existingClient.Prenom = request.Prenom!;
        existingClient.Email = request.Email!;
        existingClient.Telephone = request.Telephone!;
        existingClient.Adresse = request.Adresse!;
        await unitOfWork.SaveChangesAsync();
        return existingClient.ToResponse();
    }
    
    public async Task<bool> DeleteClient(int id)
    {
        Client? clientFounded = await unitOfWork.Clients.GetById(id);
        if (clientFounded is null)
            return false;
        unitOfWork.Clients.Remove(clientFounded);
        await unitOfWork.SaveChangesAsync();
        return true;
    }
}













