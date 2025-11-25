public interface IAuthenticationRepository
{
    public Task<User?> GetUserByEmailAndPasswordAsync(string email, string password);
}