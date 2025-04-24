using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using restomono.Models;

namespace restomono.Services
{
    public class DataService
    {
        public List<Plat> GetMenu() => new()
    {
        new Plat { Id = 1, Name = "Pizza Margherita", Description = "Tomato, Mozzarella, Basil", Price = 50 },
        new Plat { Id = 2, Name = "Caesar Salad", Description = "Chicken, Romaine, Parmesan", Price = 40 },
        new Plat { Id = 3, Name = "Pasta Carbonara", Description = "Cream, Bacon, Parmesan", Price = 55 }
    };
    }
}
