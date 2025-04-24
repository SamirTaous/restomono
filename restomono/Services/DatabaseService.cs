using restomono.Models;
using Microsoft.EntityFrameworkCore;

namespace restomono.Services;

public class DatabaseService
{
    private readonly PlatDbContext _context = new();

    public async Task<List<Plat>> GetPlatsAsync()
    {
        return await _context.Plats.ToListAsync();
    }

    public async Task SeedAsync()
    {
        if (!_context.Plats.Any())
        {
            _context.Plats.AddRange(
                new Plat { Name = "Pizza Margherita", Description = "Tomato, Mozzarella", Price = 50 },
                new Plat { Name = "Caesar Salad", Description = "Chicken, Lettuce, Parmesan", Price = 40 },
                new Plat { Name = "Spaghetti Carbonara", Description = "Cream, Bacon, Parmesan", Price = 55 }
            );
            await _context.SaveChangesAsync();
        }
    }
}
