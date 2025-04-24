using Microsoft.EntityFrameworkCore;
using restomono.Models;
using System.IO;

namespace restomono.Services;

public class PlatDbContext : DbContext
{
    // ✅ Tables
    public DbSet<Plat> Plats { get; set; }
    public DbSet<User> Users { get; set; }

    private readonly string _dbPath;

    public PlatDbContext()
    {
        // Create AppData folder in output directory
        var folder = Path.Combine(AppContext.BaseDirectory, "AppData");
        if (!Directory.Exists(folder))
            Directory.CreateDirectory(folder);

        _dbPath = Path.Combine(folder, "plats.db");

        // ✅ Create DB if it doesn't exist
        Database.EnsureCreated();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Filename={_dbPath}");
}
