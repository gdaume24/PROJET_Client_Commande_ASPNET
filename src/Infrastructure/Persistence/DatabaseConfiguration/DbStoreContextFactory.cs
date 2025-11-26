using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

public class DbStoreContextFactory : IDesignTimeDbContextFactory<DbStoreContext>
{
    public DbStoreContext CreateDbContext(string[] args)
    {
        // Path du projet WebApi
        var basePath = Path.Combine(
            Directory.GetCurrentDirectory(),
            "..",   // remonte d’un dossier
            "WebApi"
        );

        var configuration = new ConfigurationBuilder()
            .SetBasePath(basePath)
            .AddJsonFile("appsettings.json", optional: false)
            .Build();

        var builder = new DbContextOptionsBuilder<DbStoreContext>();
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        builder.UseSqlServer(connectionString);

        return new DbStoreContext(builder.Options);
    }
}
