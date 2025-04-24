using Microsoft.EntityFrameworkCore;
using restomono.Models;

namespace restomono.Services;

public class PlatDbContext : DbContext
{
    public DbSet<Plat> Plats { get; set; }

    private string _dbPath;

    public PlatDbContext()
    {
        var folder = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        _dbPath = System.IO.Path.Combine(folder, "plats.db");
        Database.EnsureCreated(); // create db if not exists
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Filename={_dbPath}");
}
