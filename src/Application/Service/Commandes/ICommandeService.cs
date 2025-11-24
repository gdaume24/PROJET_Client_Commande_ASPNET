namespace Application.Commandes;

public interface ICommandeService
{
    Task<Commande> CreateCommandeAsync(
        string numeroCommande,
        DateTime dateCommande,
        decimal montant,
        string statut,
        int clientId
    );

    Task<IReadOnlyList<Commande>> GetAllAsync();
    Task<Commande?> GetByIdAsync(int id);
    Task DeleteAsync(int id);
}
