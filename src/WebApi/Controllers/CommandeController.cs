using Application.Commandes;
using Microsoft.AspNetCore.Mvc;
[ApiController]
[Route("[controller]")]
public class CommandeController(ICommandeService commandeService) : ControllerBase
{
    /// <summary>
    /// Create a new commande
    /// </summary>
    [HttpPost]
    public async Task<IActionResult> Create(CreateCommandeRequest request)
    {
        Commande? commande = await commandeService.CreateCommande(request);
        if (commande is null)
            return NotFound("Client introuvable.");
        return Ok(commande);         
    }

    /// <summary>
    /// Get all commandes
    /// </summary>
    [HttpGet]
    public async Task<IActionResult> GetAllCommandes()
    {
        IReadOnlyList<Commande> commandes = await commandeService.GetAllCommandes();
        return Ok(commandes);
    }

    /// <summary>
    /// Get a commande by its ID
    /// </summary>
    [HttpGet("{commandeId:int}")]
    public async Task<IActionResult> GetCommandeById(int commandeId)
    {
        Commande? commande = await commandeService.GetCommandeById(commandeId);
        if (commande is null)
            return NotFound("Commande introuvable.");
        return Ok(commande);
    }

    /// <summary>
    /// Modify a commande
    /// </summary>
    [HttpPut("{commandeId:int}")]
        public async Task<IActionResult> UpdateCommande(int commandeId, UpdateCommandeRequest request)
    {
        Commande? commande = await commandeService.UpdateCommande(commandeId, request);
        return Ok(commande);
    }

    /// <summary>
    /// Delete a commande by commande ID
    /// </summary>
    [HttpDelete("{commandeId:int}")]
    public async Task<IActionResult> DeleteCommande(int commandeId)
    {
        bool deleted = await commandeService.DeleteCommande(commandeId);
        if (deleted)
        {
            return Ok();
        }
        else
        {
            return NotFound("Commande introuvable.");
        }
    }
}




