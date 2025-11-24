namespace Application.Commandes;

public interface ICommandeService
{
    public Task<Commande?> CreateCommande(CreateCommandeRequest commandeRequest);
    public Task<IReadOnlyList<Commande>> GetAllCommandes();
    public Task<Commande?> GetCommandeById(int id);
    public Task<Commande?> UpdateCommande(int id, UpdateCommandeRequest request);    
    public Task<bool> DeleteCommande(int id);
}
