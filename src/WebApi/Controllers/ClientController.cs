using FluentValidation;
using Microsoft.AspNetCore.Mvc;

[ApiController]
public class ClientController : ControllerBase
{
    public RouteGroupBuilder MapClientEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("/clients");

        group.MapPost("/",
            async (CreateClientDto dto, IValidator<CreateClientDto> validator, IClientService service) =>
                {
                var validationResult = await validator.ValidateAsync(dto);

                if (!validationResult.IsValid)
                    return Results.ValidationProblem(validationResult.ToDictionary());

                return Results.Ok(await service.Create(dto));
                });


        group.MapGet("/", (IClientService clientService) =>
        {
            List<ClientDto> clients = clientService.GetAllClients();
            return Results.Ok(clients);
        });

        group.MapGet("/{id}", (int id) =>
        {
            ClientDto? client = ClientService.GetClientById(id);
            return (client is null) ? Results.NotFound() : Results.Ok(client);
        });
        group.MapPut("/{id}", (int id, UpdateClientDto updatedClient) =>
        {
            ClientService.UpdateClient(id, updatedClient);
            return Results.Ok($"PUT update client with ID: {id}");
        });

        group.MapDelete("/{id}", (int id) =>
        {
            ClientService.DeleteClient(id);
            return Results.Ok($"DELETE client with ID: {id}");
        });

        return group;
    }
}