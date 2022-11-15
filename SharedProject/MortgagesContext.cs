using Microsoft.EntityFrameworkCore;

namespace SharedProject;

public class MortgagesContext : DbContext
{
    public DbSet<Model> Mortgages { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string folder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        string path = Path.Join(folder, "database.db");
        optionsBuilder.UseSqlite($"Data Source={path}");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Model>().HasData(
            new Model(8000000.0, 6.0, 30) { Id = 1 },
            new Model(4000000.0, 5.0, 20) { Id = 2 },
            new Model(5000000.0, 4.0, 15) { Id = 3 });
    }
}