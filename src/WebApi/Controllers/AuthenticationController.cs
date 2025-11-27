using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Application.DTO.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("auth")]
public class AuthenticationController(
    IAuthenticationService authenticationService,
    IConfiguration config) : ControllerBase
{
    [HttpPost]
    [Route("login")]
    public async Task<IActionResult> Login([FromBody] LoginModel model)
    {
        var user = await authenticationService.Authenticate(model.Email, model.Password);
        if (user != null)
        {
            var secret = config["Jwt:Key"];
            if (string.IsNullOrWhiteSpace(secret))
                throw new InvalidOperationException("JWT secret key is missing from configuration.");
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, user.Email),
            };

            var token = authenticationService.GenerateToken(secret, claims);
            return Ok(token);   
        }
        return Unauthorized();
    }

    [HttpPost]
    [Route("register")]
    public async Task<IActionResult> Register([FromBody] RegisterModel model)
    {
        var userExist = await authenticationService.IsEmailAlreadyTaken(model.Email);
        if (userExist)
        {
            return Conflict("User with this email already exists.");
        }

        var newUser = new User
        {
            Email = model.Email,
            Password = model.Password,
            Username = model.Username
        };

        await authenticationService.Register(newUser);
        return Ok("User registered successfully.");
    }

    [Authorize]
    [HttpGet("me")]
    public async Task<IActionResult> GetUserInformations()
    {
        var email = User.FindFirst(ClaimTypes.Email)?.Value;
        if (email is null)
            return Unauthorized();
        UserResponseWithoutPassword? user = await authenticationService.GetUserByEmail(email);
        if (user == null)
        {
            return Unauthorized();
        }
        return Ok(user);

    }
}