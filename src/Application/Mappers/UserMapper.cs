using Application.DTO.Response;

namespace Application.Mappers;

public static class UserMapper
{
    public static UserResponseWithoutPassword ToResponse(this User user)
        => new UserResponseWithoutPassword()
        {
            Id = user.Id,
            Username = user.Username,
            Email = user.Email,
        };
}