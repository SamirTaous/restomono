using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore;
using restomono.Models;
using restomono.Services;
using System.Collections.ObjectModel;

namespace restomono.ViewModels;

public partial class UserCrudViewModel : ObservableObject
{
    public ObservableCollection<User> Users { get; } = new();

    [ObservableProperty]
    private User newUser = new();

    public UserCrudViewModel()
    {
        LoadUsers();
    }

    private async void LoadUsers()
    {
        using var context = new PlatDbContext();
        var users = await context.Users.Where(u => u.Name.ToLower() != "admin").ToListAsync();
        Users.Clear();
        foreach (var user in users)
            Users.Add(user);
    }

    [RelayCommand]
    async Task SaveUser()
    {
        using var context = new PlatDbContext();
        if (NewUser.Id == 0)
        {
            context.Users.Add(NewUser);
        }
        else
        {
            context.Users.Update(NewUser);
        }
        await context.SaveChangesAsync();

        NewUser = new User();
        LoadUsers();
    }

    [RelayCommand]
    void EditUser(User user)
    {
        NewUser = new User
        {
            Id = user.Id,
            Name = user.Name,
            Wallet = user.Wallet
        };
    }

    [RelayCommand]
    async Task DeleteUser(User user)
    {
        using var context = new PlatDbContext();
        context.Users.Remove(user);
        await context.SaveChangesAsync();
        LoadUsers();
    }
}
