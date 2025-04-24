using CommunityToolkit.Mvvm.ComponentModel;
using restomono.Services;

namespace restomono.ViewModels;

public partial class ProfileViewModel : ObservableObject
{
    public string Name => AuthService.CurrentUser?.Name ?? "Guest";
    public decimal Wallet => AuthService.CurrentUser?.Wallet ?? 0;
}
