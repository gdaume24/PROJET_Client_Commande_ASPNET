using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("auth")]
public class AuthenticationController(IAuthenticationService authenticationService) : ControllerBase
{
    public IActionResult Login(LoginModel model)
    {
        // Implement login logic here
        return Ok();
    }
}