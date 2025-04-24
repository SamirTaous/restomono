using System.ComponentModel.DataAnnotations;

namespace restomono.Models;

public class User
{
    [Key]
    public int Id { get; set; }

    public string Name { get; set; }

    public decimal Wallet { get; set; }
}
