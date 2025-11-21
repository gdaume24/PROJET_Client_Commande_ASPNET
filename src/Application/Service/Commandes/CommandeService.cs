using Domain.Entities;
using Domain.Interfaces;

namespace Application.Commandes;

public class CommandeService : ICommandeService
{
    private readonly ICommandeRepository _commandeRepo;
    private readonly IClientRepository _clientRepo;
    private readonly IUnitOfWork _uow;

    public CommandeService(
        ICommandeRepository commandeRepo,
        IClientRepository clientRepo,
        IUnitOfWork uow)
    {
        _commandeRepo = commandeRepo;
        _clientRepo = clientRepo;
        _uow = uow;
    }

    public async Task<Commande> CreateAsync(
        int clientId,
        string numeroCommande,
        DateTime dateCommande,
        decimal montantTotal,
        string statut)
    {
        // Vérifier que le client existe
        var client = await _clientRepo.GetById(clientId);
        if (client is null)
            throw new Exception("Client introuvable pour cette commande.");

        var commande = new Commande
        {
            ClientId = clientId,
            NumeroCommande = numeroCommande,
            DateCommande = dateCommande,
            MontantTotal = montantTotal,
            Statut = statut
        };

        await _commandeRepo.Add(commande);
        await _uow.SaveChangesAsync();

        return commande;
    }

    public Task<Commande?> GetByIdAsync(int id) =>
        _commandeRepo.GetById(id);

    public Task<IReadOnlyList<Commande>> GetAllAsync() =>
        _commandeRepo.GetAll();

    public async Task DeleteAsync(int id)
    {
        var commande = await _commandeRepo.GetById(id);
        if (commande is null)
            throw new Exception("Commande introuvable.");

        _commandeRepo.Remove(commande);
        await _uow.SaveChangesAsync();
    }
}