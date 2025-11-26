using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
public class ClientControllerTests
{
    private readonly IClientService _clientService;

    public ClientControllerTests()
    {
        _clientService = Substitute.For<IClientService>();
    }
    [Fact]
    public async Task ClientController_CreateClient_ReturnOK()    
    {
        //Arrange
        var request = new CreateClientRequest
        {
            Nom = "John",
            Prenom = "Doe",
            Email = "john@example.com",
            Telephone = "0000000000",
            Adresse = "Paris"
        };
        var client = new ClientResponseWithoutCommands
        {
            Id = 1,
            Nom = "John",
            Prenom = "Doe",
            Email = "john@example.com",
            Telephone = "0000000000",
            Adresse = "Paris",
            DateCreation = DateTime.UtcNow
        };
        _clientService.CreateClient(request).Returns(client);
        var controller = new ClientController(_clientService);

        //Act
        var result = await controller.Create(request);
        
        //Assert
        result.Should().BeOfType<OkObjectResult>();
    }

    [Fact]
    public async Task ClientController_GetAllClients_ReturnOK()
    {
        //Arrange
        var clients = new List<ClientResponseWithoutCommands>
        {
            new ClientResponseWithoutCommands { 
                Id = 1, 
                Nom = "John" ,
                Prenom = "Doe",
                Email = "ge@hotmail.com", 
                Telephone = "0000000000",
                 Adresse = "Rue de Paris"
            },
            new ClientResponseWithoutCommands {                 Id = 1, 
                Nom = "Jane" ,
                Prenom = "Doe",
                Email = "geeee@hotmail.com", 
                Telephone = "0000000400",
                Adresse = "Rue de Paris 90000 Paris" }
        }.AsReadOnly();
        _clientService.GetAllClients().Returns(clients);
        var controller = new ClientController(_clientService);

        //Act
        var result = await controller.GetAllClients();
        
        //Assert
        result.Should().BeOfType<OkObjectResult>();
    }
}
