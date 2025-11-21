using Domain.Interfaces;

public class UnitOfWork : IUnitOfWork
{
    private readonly DbStoreContext _context;

    public UnitOfWork(DbStoreContext context)
    {
        _context = context;
    }

    public Task SaveChangesAsync() => _context.SaveChangesAsync();
}