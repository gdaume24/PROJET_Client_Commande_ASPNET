public interface IAuthenticationRepository
{
    public Task<User?> GetUserByEmailAndPasswordAsync(string email, string password);
    public Task<bool> IsEmailAlreadyTakenAsync(string email);
    public void Add(User newUser);
    public Task<User?> GetUserByEmailAsync(string email);

}