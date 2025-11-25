using Microsoft.EntityFrameworkCore;

public class DbStoreContext : DbContext
{  
    public DbStoreContext(DbContextOptions<DbStoreContext> options)
        : base(options) {}

    public DbSet<User> Users { get; set; }
    public DbSet<Client> Clients { get; set; }
    public DbSet<Commande> Commandes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Relation 1 (Client) -> N (Commande)
        modelBuilder.Entity<Commande>()
            .HasOne(c => c.Client)
            .WithMany(c => c.Commandes)
            .HasForeignKey(c => c.ClientId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Commande>()
            .HasIndex(c => c.ClientId);

        base.OnModelCreating(modelBuilder);
    }
}
