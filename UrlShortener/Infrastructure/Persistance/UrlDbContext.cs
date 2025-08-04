using Microsoft.EntityFrameworkCore;
using UrlShortener.Domain;

namespace UrlShortener.Infrastructure;

public class UrlDbContext(DbContextOptions<UrlDbContext> options, IConfiguration configuration)
    : DbContext(options)
{
    public DbSet<UrlMapping> UrlMappings { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
        }
    }
}