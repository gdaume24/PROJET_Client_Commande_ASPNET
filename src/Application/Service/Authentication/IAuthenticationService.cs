using System.Security.Claims;
using Application.DTO.Response;

public interface IAuthenticationService
{
    Task<UserResponseWithoutPassword?> Authenticate(string email, string password);
    string GenerateToken(string secret, List<Claim> claims);
    public Task<bool> IsEmailAlreadyTaken(string email);
    public Task Register(User newUser);
    public Task<UserResponseWithoutPassword?> GetUserByEmail(string email);


}