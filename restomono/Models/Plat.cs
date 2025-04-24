using System.ComponentModel.DataAnnotations;

namespace restomono.Models;

public class Plat
{
    [Key]
    public int Id { get; set; }

    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
}
