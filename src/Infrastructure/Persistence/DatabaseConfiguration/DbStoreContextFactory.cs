using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

public class DbStoreContextFactory : IDesignTimeDbContextFactory<DbStoreContext>
{
    public DbStoreContext CreateDbContext(string[] args)
    {
        // charge appsettings.json depuis WebApi
        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false)
            .Build();

        var optionsBuilder = new DbContextOptionsBuilder<DbStoreContext>();

        var connectionString = configuration.GetConnectionString("DefaultConnection");

        optionsBuilder.UseSqlServer(connectionString);

        return new DbStoreContext(optionsBuilder.Options);
    }
}
