using FluentValidation;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class ClientController(IClientService clientService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Create(
        CreateClientRequest request
        )
    {
        ClientResponseWithoutCommands client = await clientService.CreateClient(request);
        return Ok(client);         
    }

    [HttpGet]
    public async Task<IActionResult> GetAllClients()
    {
        IReadOnlyList<ClientResponseWithoutCommands> clients = await clientService.GetAllClients();
        return Ok(clients);
    }

    [HttpGet("{clientId:int}")]
    public async Task<IActionResult> GetClientById(int clientId)
    {
        //invoking the use case 
        ClientResponseWithoutCommands? client = await clientService.GetClientById(clientId);
        // return 200 ok response
        if (client is null)
            return NotFound("Client introuvable.");
        return Ok(client);
    }

    [HttpGet("{clientId:int}/commandes")]
    public async Task<IActionResult> GetClientCommandesById(int clientId)
    {
        //invoking the use case 
        IReadOnlyList<Commande>? commandes = await clientService.GetClientCommandesById(clientId);
        // return 200 ok response
        return Ok(commandes);
    }

    [HttpPut("{clientId:int}")]
    public async Task<IActionResult> UpdateClient(
        int clientId, 
        [FromBody] UpdateClientRequest request
        )
    {
        ClientResponseWithoutCommands? client = await clientService.UpdateClient(clientId, request);
        if (client is null)
            return NotFound("Client introuvable.");
        return Ok(client);
    }

    [HttpDelete("{clientId:int}")]
    public async Task<IActionResult> DeleteClient(int clientId)
    {
        bool deleted = await clientService.DeleteClient(clientId);
        if (deleted)
        {
            return Ok();
        }
        else
        {
            return NotFound("Client introuvable.");
        }
    }
}