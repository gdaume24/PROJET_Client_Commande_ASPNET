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
        ClientResponse client = await clientService.CreateClient(request);
        return Ok(client);         
    }

    [HttpGet]
    public async Task<IActionResult> GetAllClients()
    {
        Task<List<ClientResponse>> clients = clientService.GetAllClients();

        return Ok(clients);
    }

    [HttpGet("{clientId:guid}")]
    public IActionResult GetClientById(Guid clientId)
    {
        //invoking the use case 
        Task<ClientResponse?> client = clientService.GetClientById(clientId);
        // return 200 ok response
        return Ok(client);
    }

    [HttpPut("{clientId:guid}")]
    public IActionResult UpdateClient(
        Guid clientId, 
        [FromBody] UpdateClientRequest request,
        [FromServices] IValidator<UpdateClientRequest> validator
        )
    {
        var validation = validator.Validate(request);
        if (!validation.IsValid)
        {
            return BadRequest(validation.Errors);
        }
        Task<ClientResponse> client = clientService.UpdateClient(clientId, request);
        return Ok(client);
    }

    [HttpDelete("{clientId:guid}")]
    public IActionResult DeleteClient(Guid clientId)
    {
        clientService.DeleteClient(clientId);
        return Ok($"DELETE client with ID: {clientId}");
    }
}