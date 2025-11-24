using Domain.Interfaces;

namespace Application.Commandes;

public class CommandeService(IUnitOfWork unitOfWork) : ICommandeService
{

    public async Task<Commande?> CreateCommande(CreateCommandeRequest request)
    {
        var client = await unitOfWork.Clients.GetById(request.ClientId);

        if (client is null)
            return null;

        Commande commande = new Commande
        {
            NumeroCommande = request.NumeroCommande,
            DateCommande = DateTime.Now,
            MontantTotal = request.MontantTotal,
            Statut = request.Statut,
            ClientId = request.ClientId
        };

        unitOfWork.Commandes.Add(commande);
        await unitOfWork.SaveChangesAsync();

        return commande;
    }

    public Task<IReadOnlyList<Commande>> GetAllCommandes() =>
        unitOfWork.Commandes.GetAll();

    public Task<Commande?> GetCommandeById(int id) =>
        unitOfWork.Commandes.GetById(id);

    public async Task<Commande?> UpdateCommande(int id, UpdateCommandeRequest request)
    {
        Commande? commandeFounded = await unitOfWork.Commandes.GetById(id);
        if (commandeFounded is null)
            return null;
        commandeFounded.NumeroCommande = request.NumeroCommande;
        commandeFounded.MontantTotal = request.MontantTotal;
        commandeFounded.Statut = request.Statut;
        commandeFounded.ClientId = request.ClientId;

        await unitOfWork.SaveChangesAsync();

        return commandeFounded;
    }
    
    public async Task<bool> DeleteCommande(int id)
    {
        Commande? commandeFounded = await unitOfWork.Commandes.GetById(id);
        if (commandeFounded is null)
            return false;
        unitOfWork.Commandes.Remove(commandeFounded);
        await unitOfWork.SaveChangesAsync();
        return true;
    }
}