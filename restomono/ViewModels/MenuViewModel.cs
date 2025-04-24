using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Views;
using restomono.Models;
using restomono.Services;
using restomono.Views;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using CommunityToolkit.Maui.Core;

namespace restomono.ViewModels;

public partial class MenuViewModel : ObservableObject
{
    private readonly DatabaseService _dbService = new();

    public ObservableCollection<Plat> VisiblePlats { get; } = new();
    public ObservableCollection<CartItem> CartItems { get; } = new();

    private List<Plat> _allPlats = new();
    private const int PageSize = 6;

    [ObservableProperty] private int currentPage = 1;
    [ObservableProperty] private decimal total;
    [ObservableProperty] private string promptMessage = "🍽️ Welcome! Choose the dishes you want to order.";

    public int TotalPages => (int)Math.Ceiling((double)_allPlats.Count / PageSize);

    public MenuViewModel()
    {
        LoadData();
    }

    private async void LoadData()
    {
        await _dbService.SeedAsync();
        _allPlats = await _dbService.GetPlatsAsync();
        ShowPage(1);
    }

    private void ShowPage(int page)
    {
        CurrentPage = page;
        VisiblePlats.Clear();
        var items = _allPlats.Skip((page - 1) * PageSize).Take(PageSize);
        foreach (var plat in items)
            VisiblePlats.Add(plat);
    }

    [RelayCommand]
    async Task AddToCart(Plat plat)
    {
        var existing = CartItems.FirstOrDefault(p => p.Plat.Id == plat.Id);
        if (existing == null)
            CartItems.Add(new CartItem { Plat = plat, Quantity = 1 });
        else
            existing.Quantity++;

        Total = CartItems.Sum(x => x.TotalPrice);
        try { await Toast.Make($"✅ {plat.Name} added!", ToastDuration.Short).Show(); }
        catch (Exception ex) { Console.WriteLine("Toast error: " + ex.Message); }
    }

    [RelayCommand]
    void RemoveFromCart(Plat plat)
    {
        var existing = CartItems.FirstOrDefault(p => p.Plat.Id == plat.Id);
        if (existing != null)
        {
            if (existing.Quantity == 1)
                CartItems.Remove(existing);
            else
                existing.Quantity--;
            Total = CartItems.Sum(x => x.TotalPrice);
        }
    }

    [RelayCommand]
    void NextPage()
    {
        if (CurrentPage < TotalPages)
            ShowPage(CurrentPage + 1);
    }

    [RelayCommand]
    void PreviousPage()
    {
        if (CurrentPage > 1)
            ShowPage(CurrentPage - 1);
    }

    [RelayCommand]
    async Task ShowCartPopup()
    {
        var popup = new CartPopup(CartItems, Total);
        var page = Shell.Current?.CurrentPage ?? Application.Current?.MainPage;
        if (page is not null)
            await page.ShowPopupAsync(popup);
    }

    [RelayCommand]
    async Task GoToProfile()
    {
        await Shell.Current.GoToAsync("ProfilePage");
    }
}
