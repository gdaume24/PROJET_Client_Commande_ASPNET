using System.Security.Claims;
using System.Text;
using Application.DTO.Response;
using Application.Mappers;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;

public class AuthenticationService(IUnitOfWork unitOfWork) : IAuthenticationService
{
    public async Task<UserResponseWithoutPassword?> Authenticate(string email, string password)
    {
        User user = await unitOfWork.Authentication.GetUserByEmailAndPasswordAsync(email, password);
        return user.ToResponse();
    }

    public string GenerateToken(string secret, List<Claim> claims)
    {
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddHours(2),
            SigningCredentials = new SigningCredentials(
                key,
                SecurityAlgorithms.HmacSha256Signature)

        };
        var tokenHandler = new JsonWebTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return token;
    }

    public Task<bool> IsEmailAlreadyTaken(string email)
    {
        return unitOfWork.Authentication.IsEmailAlreadyTakenAsync(email);
    }

    public Task Register(User newUser)
    {
        unitOfWork.Authentication.Add(newUser);
        return unitOfWork.SaveChangesAsync();
    }

    public async Task<UserResponseWithoutPassword?> GetUserByEmail(string email)
    {
        User? user = await unitOfWork.Authentication.GetUserByEmailAsync(email);
        return user?.ToResponse();
    }

}