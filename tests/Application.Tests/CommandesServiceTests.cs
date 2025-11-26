using Application.Commandes;
using FluentAssertions;
using NSubstitute;

namespace Application.Tests;

public class CommandesServiceTests
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ICommandeService _commandeService;

    public CommandesServiceTests()
    {
        _unitOfWork = Substitute.For<IUnitOfWork>();
        _commandeService = new CommandeService(_unitOfWork);
    }

    [Fact]
    public async Task CommandeService_CreateCommande_checkClientAdded_ReturnCommand()
    {
        //Arrange
        CreateCommandeRequest request = new CreateCommandeRequest
        {
            NumeroCommande = "blablabla",
            MontantTotal = 50,
            Statut = "En acheminement",
            ClientId = 1,
        };
        var existingClient = new Client
        {
            Id = 1,
            Nom = "Daumer",
            Prenom = "Geoffroy",
            Email = "geo@ds.com",
            Telephone = "0000000",
            Adresse = "132 rue de la Creme",
            DateCreation = DateTime.Now
        };
        _unitOfWork.Clients.GetById(1).Returns(existingClient);
        Commande commande = new Commande
        {
            NumeroCommande = "blablabla",
            MontantTotal = 50,
            Statut = "En acheminement",
            ClientId = 1,
        };
        
        //Act
        var result = await _commandeService.CreateCommande(request);
        
        //Assert
        await _unitOfWork.Received(1).SaveChangesAsync();
        _unitOfWork.Received(1).Commandes.Add(Arg.Any<Commande>());
        result.Should().BeEquivalentTo(commande, options => options
                .ExcludingMissingMembers() // permet d’ignorer les champs qui ne sont pas dans updateRequest
                .Excluding(c => c.DateCommande) // ⬅️ ajoute cette ligne
            );
    }

    [Fact]
    public async Task CommandeService_GetAllCommandes_checkReturnAllCommands()
    {
        var commands = new List<Commande>
        {
            new Commande
            {
                Id = 1,
                NumeroCommande = "CMD001",
                MontantTotal = 50,
                Statut = "Payée",
                ClientId = 1
            },
            new Commande
            {
                Id = 2,
                NumeroCommande = "CMD002",
                MontantTotal = 120,
                Statut = "En cours",
                ClientId = 2
            }
        }.AsReadOnly();
      
        _unitOfWork.Commandes.GetAll().Returns(commands);
        
        // Act
        var result = await _commandeService.GetAllCommandes();

        // Assert
        result.Should().NotBeNull();
        result.Should().HaveCount(2);
        result.Should().BeEquivalentTo(commands);
    }

    [Fact]
    public async Task CommandeService_GetCommandeById_checkCommand()
    {
        //Arrange
        var command = new Commande
        {
            Id = 2,
            NumeroCommande = "CMD002",
            MontantTotal = 120,
            Statut = "En cours",
            ClientId = 2
        };
        _unitOfWork.Commandes.GetById(Arg.Any<int>()).ReturnsForAnyArgs(command);
        //Act
        var result = await _commandeService.GetCommandeById(2);
        //Assert
        result.Should().BeEquivalentTo(command);
    }

    [Fact]
    public async Task CommandeService_UpdateCommande_CheckCommandeIsWellUpdated()
    {
        var request = new UpdateCommandeRequest()
        {
            NumeroCommande = "4203",
            MontantTotal = 50,
            Statut = "Acheminée",
            ClientId = 1,
        };
        var existingCommand = new Commande()
        {
            Id = 1,
            NumeroCommande = "4203",
            MontantTotal = 50,
            Statut = "En acheminement",
            ClientId = 1,
        };
        var existingClient = new Client
        {
            Id = 1,
            Nom = "John",
            Prenom = "Doe",
            Email = "john@example.com",
            Telephone = "0000",
            Adresse = "Paris"
        };
        _unitOfWork.Commandes.GetById(Arg.Any<int>()).ReturnsForAnyArgs(existingCommand);
        _unitOfWork.Clients.GetById(Arg.Any<int>()).ReturnsForAnyArgs(existingClient);
        
        //Act
        var result = await _commandeService.UpdateCommande(1, request);
        
        existingCommand.NumeroCommande.Should().Be(request.NumeroCommande);
        await _unitOfWork.Received(1).SaveChangesAsync();
    }

    [Fact]
    public async Task CommandeService_DeleteCommande_CheckCommandeIsWellUpdated()
    {
        var foundedCommand = new Commande()
        {
            Id = 1,
            NumeroCommande = "4203",
            MontantTotal = 50,
            Statut = "En acheminement",
            ClientId = 1,
        };
        _unitOfWork.Commandes.GetById(Arg.Any<int>()).ReturnsForAnyArgs(foundedCommand);
        //Act
        bool isDeleted = await _commandeService.DeleteCommande(1);
        //Assert
        _unitOfWork.Commandes.Received(1).Remove(Arg.Any<Commande>());
        await _unitOfWork.Received(1).SaveChangesAsync();
        isDeleted.Should().BeTrue();
    }
}








