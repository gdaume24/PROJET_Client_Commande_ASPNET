namespace Application.DTO.Response.Auth;

public record LoginResponse(
    string Token,
    DateTime ExpiresAt,
    UserResponseWithoutPassword User
);