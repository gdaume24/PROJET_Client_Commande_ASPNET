using Domain.Interfaces;
using FluentAssertions;
using NSubstitute;

namespace Application.Tests;

public class ClientServiceTests
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IClientService _clientService;

    public ClientServiceTests()
    {
        _unitOfWork = Substitute.For<IUnitOfWork>();
        _clientService = new ClientService(_unitOfWork);
    }
    [Fact]
    public async Task ClientService_CreateClient_checkClientAdded_SavedAndReturnClient()
    {
        // Arrange
        var request = new CreateClientRequest
        {
            Nom = "John",
            Prenom = "Doe",
            Email = "john@example.com",
            Telephone = "0000000000",
            Adresse = "Paris"
        };
        // Act
        var result = await _clientService.CreateClient(request);

        // Assert : vérifier que Add(entity) a été appelé
        await _unitOfWork.Received(1).SaveChangesAsync();
        _unitOfWork.Clients.Received(1).Add(Arg.Any<Client>());
        // Assert : vérifier que le résultat est cohérent
        result.Should().BeAssignableTo<ClientResponseWithoutCommands>();
        result.Nom.Should().Be("John");
        result.Prenom.Should().Be("Doe");
        result.Email.Should().Be("john@example.com");    
    }
    [Fact]
    public async Task ClientService_GetAllClients_CheckReturnClients()
    {
        // Arrange
        var clients = new List<Client>
        {
            new Client
            {
                Id = 1,
                Nom = "John",
                Prenom = "Doe",
                Email = "john@example.com",
                Telephone = "0000",
                Adresse = "Paris"
            },
            new Client
            {
                Id = 2,
                Nom = "Jane",
                Prenom = "Doe",
                Email = "jane@example.com",
                Telephone = "1111",
                Adresse = "Lyon"
            }
        }.AsReadOnly();

        // Le repository renvoie des entités
        _unitOfWork.Clients.GetAll().Returns(clients);

        // Act
        var result = await _clientService.GetAllClients();

        // Assert
        result.Should().BeAssignableTo<IReadOnlyList<ClientResponseWithoutCommands>>();
        result.Should().HaveCount(2);

        result[0].Nom.Should().Be("John");
        result[0].Email.Should().Be("john@example.com");

        result[1].Nom.Should().Be("Jane");
        result[1].Email.Should().Be("jane@example.com");
    }
    
    [Fact]
    public async Task ClientService_GetClientById_ReturnCorrectClient()
    {
        // Arrange
        Client client = new Client
        {
            Id = 1,
            Nom = "John",
            Prenom = "Doe",
            Email = "john@example.com",
            Telephone = "0000",
            Adresse = "Paris",
            DateCreation = DateTime.Now
        };
        _unitOfWork.Clients.GetById(1).Returns(client);
        var expected = new ClientResponseWithoutCommands
        {
            Id = client.Id,
            Nom = client.Nom,
            Prenom = client.Prenom,
            Email = client.Email,
            Telephone = client.Telephone,
            Adresse = client.Adresse,
            DateCreation = client.DateCreation
        };

        // Act
        var result = await _clientService.GetClientById(1);

        // Assert
        result.Should().BeAssignableTo<ClientResponseWithoutCommands>();
        result.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public async Task ClientService_GetClientCommandesById_ReturnCorrectCommandes()
    {
        //Arrange
        var client = new Client
        {
            Id = 1,
            Nom = "John",
            Prenom = "Doe",
            Email = "john@example.com",
            Telephone = "0000",
            Adresse = "Paris",
            Commandes = [
                new Commande {
                    Id = 100,
                    NumeroCommande = "CMD001",
                    MontantTotal = 150.50m,
                    Statut = "Payée",
                    ClientId = 1
                },
                new Commande
                {
                    Id = 101,
                    NumeroCommande = "CMD002",
                    MontantTotal = 89.99m,
                    Statut = "En cours",
                    ClientId = 1
                }
            ]
        };
        _unitOfWork.Clients.GetByIdWithCommandes(1).Returns(client);
        
        //Act
        var result = await _clientService.GetClientCommandesById(1);

        //Assert
        result.Should().BeAssignableTo<List<Commande>>();
        result.Should().BeEquivalentTo(client.Commandes);
    }

    [Fact]
    public async Task ClientService_UpdateClient_ClientIsModified()
    {
        // Arrange : client existant dans la base
        var existingClient = new Client
        {
            Id = 1,
            Nom = "OldName",
            Prenom = "OldPrenom",
            Email = "old@mail.com",
            Telephone = "123456",
            Adresse = "Old Street"
        };

        _unitOfWork.Clients.GetById(1).Returns(existingClient);

        // Les nouvelles valeurs envoyées par l'utilisateur
        var updateRequest = new UpdateClientRequest
        {
            Nom = "John",
            Prenom = "Doe",
            Email = "john@example.com",
            Telephone = "0000",
            Adresse = "Paris"
        };

        // Act
        var result = await _clientService.UpdateClient(1, updateRequest);

        // Assert : vérifier que SaveChanges a été appelé
        await _unitOfWork.Received(1).SaveChangesAsync();

        // Assert : vérifier que les propriétés du client ont été modifiées
        existingClient.Nom.Should().Be("John");
        existingClient.Prenom.Should().Be("Doe");
        existingClient.Email.Should().Be("john@example.com");
        existingClient.Telephone.Should().Be("0000");
        existingClient.Adresse.Should().Be("Paris");

        // Assert : vérifier que le retour correspond
        result.Should().NotBeNull();
        result.Should().BeAssignableTo<ClientResponseWithoutCommands>();
        result.Should().BeEquivalentTo(updateRequest, options => options
                .ExcludingMissingMembers() // permet d’ignorer les champs qui ne sont pas dans updateRequest
        );
    }

    [Fact]
    public async Task ClientService_DeleteClient_ReturnTrue()
    {
        // Arrange
        var existingClient = new Client
        {
            Id = 1,
            Nom = "John",
            Prenom = "Doe",
            Email = "john@example.com",
            Telephone = "0000",
            Adresse = "Paris"
        };
        _unitOfWork.Clients.GetById(1).Returns(existingClient);
        
        //Act 
        bool result = await _clientService.DeleteClient(1);
        
        //Assert
        result.Should().BeTrue();  
    }
}



