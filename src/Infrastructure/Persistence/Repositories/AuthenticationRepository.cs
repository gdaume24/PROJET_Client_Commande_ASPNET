using Microsoft.EntityFrameworkCore;

public class AuthenticationRepository : IAuthenticationRepository
{
    private readonly DbStoreContext _context;

    public AuthenticationRepository(DbStoreContext context)
    {
        _context = context;
    }
    public Task<User?> GetUserByEmailAndPasswordAsync(string email, string password)
    {
        return _context.Users.FirstOrDefaultAsync(u => u.Email == email && u.Password == password);
    }

    public Task<bool> IsEmailAlreadyTakenAsync(string email)
    {
        return _context.Users.AnyAsync(u => u.Email == email);
    }
    public void Add(User newUser)
        => _context.Users.Add(newUser);

    public Task<User?> GetUserByEmailAsync(string email)
    {
        return _context.Users.FirstOrDefaultAsync(u => u.Email == email);
    }

}