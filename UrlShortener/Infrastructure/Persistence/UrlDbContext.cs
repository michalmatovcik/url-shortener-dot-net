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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UrlMapping>()
            .HasKey(mapping => mapping.Id);

        modelBuilder.Entity<UrlMapping>()
            .Property(mapping => mapping.Url)
            .HasMaxLength(5000);
    }
}