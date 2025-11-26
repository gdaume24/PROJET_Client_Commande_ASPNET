using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using FluentAssertions;
using Microsoft.IdentityModel.Tokens;
using NSubstitute;

namespace Application.Tests;

public class AuthenticationServiceTest
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IAuthenticationService _authenticationService;

    public AuthenticationServiceTest()
    {
        _unitOfWork = Substitute.For<IUnitOfWork>();
        _authenticationService = new AuthenticationService(_unitOfWork);
    }

    [Fact]
    public async Task AuthenticationService_GenerateToken_IsGeneratingGoodToken()
    {
        // Arrange
        var secret = "supersecretkey123supersecretkey123";
        var claims = new List<Claim>()
        {
            new Claim(ClaimTypes.Email, "Eliot59@yopmail.com"),
        };
        
        //Act
        var token = _authenticationService.GenerateToken(secret, claims);
        
        //Assert
        token.Should().NotBeNullOrWhiteSpace();
        // Vérifier que le JWT contient bien le claim email
        var handler = new JwtSecurityTokenHandler();
        var jwt = handler.ReadJwtToken(token);

        jwt.Claims.Should().Contain(c =>
            c.Type == ClaimTypes.Email &&
            c.Value == "Eliot59@yopmail.com");
    }
}