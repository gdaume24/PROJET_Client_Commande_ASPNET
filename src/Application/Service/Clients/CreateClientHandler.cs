using Domain.Entities;
using Domain.Interfaces;

namespace Application.Clients.Commands.CreateClient;

public class CreateClientHandler
{
    private readonly IClientRepository _repo;
    private readonly IUnitOfWork _uow;

    public CreateClientHandler(IClientRepository repo, IUnitOfWork uow)
    {
        _repo = repo;
        _uow = uow;
    }

    public async Task<int> Handle(CreateClientCommand cmd)
    {
        var client = new Client
        {
            Nom = cmd.Nom,
            Prenom = cmd.Prenom,
            Email = cmd.Email,
            Telephone = cmd.Telephone,
            Adresse = cmd.Adresse,
            DateCreation = DateTime.UtcNow
        };

        await _repo.Add(client);
        await _uow.SaveChangesAsync();

        return client.Id;
    }
}
