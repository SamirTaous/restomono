using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore;
using restomono.Models;
using restomono.Services;
using System.Collections.ObjectModel;

namespace restomono.ViewModels;

public partial class PlatCrudViewModel : ObservableObject
{
    public ObservableCollection<Plat> Plats { get; } = new();

    [ObservableProperty]
    private Plat newPlat = new();

    public PlatCrudViewModel()
    {
        LoadPlats();
    }

    private async void LoadPlats()
    {
        using var context = new PlatDbContext();
        var plats = await context.Plats.ToListAsync();
        Plats.Clear();
        foreach (var plat in plats)
            Plats.Add(plat);
    }

    [RelayCommand]
    async Task SavePlat()
    {
        using var context = new PlatDbContext();
        if (NewPlat.Id == 0)
        {
            context.Plats.Add(NewPlat);
        }
        else
        {
            context.Plats.Update(NewPlat);
        }
        await context.SaveChangesAsync();

        NewPlat = new Plat();
        LoadPlats();
    }

    [RelayCommand]
    void EditPlat(Plat plat)
    {
        NewPlat = new Plat
        {
            Id = plat.Id,
            Name = plat.Name,
            Description = plat.Description,
            Price = plat.Price
        };
    }

    [RelayCommand]
    async Task DeletePlat(Plat plat)
    {
        using var context = new PlatDbContext();
        context.Plats.Remove(plat);
        await context.SaveChangesAsync();
        LoadPlats();
    }
}
