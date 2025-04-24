using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore;
using restomono.Services;
using restomono.Views;

namespace restomono.ViewModels;

public partial class StatisticsViewModel : ObservableObject
{
    [ObservableProperty] private int totalDishes;
    [ObservableProperty] private int totalUsers;

    public StatisticsViewModel()
    {
        LoadStats();
    }

    private async void LoadStats()
    {
        using var context = new PlatDbContext();
        totalDishes = await context.Plats.CountAsync();
        totalUsers = await context.Users.CountAsync(u => u.Name.ToLower() != "admin");
    }

    [RelayCommand]
    async Task GoToPlatCrud()
    {
        await Shell.Current.GoToAsync("PlatCrudPage");
    }

    [RelayCommand]
    async Task GoToUserCrud()
    {
        await Shell.Current.GoToAsync("UserCrudPage");
    }
}
