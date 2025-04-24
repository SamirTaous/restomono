using Microsoft.EntityFrameworkCore;
using restomono.Models;
using System.IO;

namespace restomono.Services;

public class PlatDbContext : DbContext
{
    public DbSet<Plat> Plats { get; set; }

    private readonly string _dbPath;

    public PlatDbContext()
    {
        var folder = Path.Combine(AppContext.BaseDirectory, "AppData");
        if (!Directory.Exists(folder))
            Directory.CreateDirectory(folder);

        _dbPath = Path.Combine(folder, "plats.db");
        Database.EnsureCreated(); // Create the database if it doesn't exist
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Filename={_dbPath}");
}
