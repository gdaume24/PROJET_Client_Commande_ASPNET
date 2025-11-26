using System.Security.Claims;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using NSubstitute;
using NSubstitute.ReturnsExtensions;

namespace WebApi.Tests;

public class AuthenticationControllerTests
{
    private readonly IAuthenticationService _authenticationService;
    private readonly IConfiguration _configuration;
    private readonly AuthenticationController _controller;

    public AuthenticationControllerTests()
    {
        _authenticationService = Substitute.For<IAuthenticationService>();
        _configuration = Substitute.For<IConfiguration>();
        _controller = new AuthenticationController(_authenticationService, _configuration);
    }

    [Fact]
    public async Task AuthenticationController_Login_ReturnOKWithToken()
    {
        //Arrange
        var login = new LoginModel()
        {
            Email = "eleldkjfd@outlook.fr",
            Password = "password1234"
        };
        var fakeUser = new User()
        {
            Id = 105,
            Username = "Eliot",
            Email = login.Email,
            Password = login.Password
        };
        _authenticationService.Authenticate(login.Email, login.Password).Returns(fakeUser);
        _configuration["Jwt:Key"].Returns("supersecretkey123456");
        _authenticationService
            .GenerateToken(Arg.Any<string>(), Arg.Any<List<Claim>>())
            .Returns("FAKE_JWT_TOKEN");
        
        //Act
        var result = await _controller.Login(login);
        
        //Assert
        _authenticationService.Received(1).Authenticate(Arg.Any<string>(), Arg.Any<string>());
        result.Should().BeOfType<OkObjectResult>();
        var okResult = result.As<OkObjectResult>();
        okResult.Value.Should().Be("FAKE_JWT_TOKEN");
    } 
    
    [Fact]
    public async Task AuthenticationController_Login_ReturnsUnauthorized_WhenUserWrongCoupleEmailPassword()
    {
        // Arrange
        var login = new LoginModel
        {
            Email = "notfound@test.com",
            Password = "wrongpassword"
        };

        // Authenticate() renvoie null
        _authenticationService
            .Authenticate(login.Email, login.Password)
            .Returns((User?)null);

        // Act
        var result = await _controller.Login(login);    

        // Assert
        result.Should().BeOfType<UnauthorizedResult>();
    }

    [Fact]
    public async Task AuthenticationController_Register_ReturnOk()
    {
        //Arrange
        var registerForm = new RegisterModel()
        {
            Username = "Boula",
            Email = "12345@outlook.com",
            Password = "password1234"
        };
        _authenticationService.IsEmailAlreadyTaken(Arg.Any<string>()).Returns(false);

        //Act
        var result = await _controller.Register(registerForm);
        
        //Arrange
        _authenticationService.Received(1).Register(Arg.Any<User>());
        result.Should().BeOfType<OkObjectResult>();
    }

}