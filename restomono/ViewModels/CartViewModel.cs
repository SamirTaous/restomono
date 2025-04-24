using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using restomono.Models;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace restomono.ViewModels;

public partial class CartViewModel : ObservableObject
{
    public ObservableCollection<CartItem> CartItems { get; } = new();

    [ObservableProperty]
    private decimal total;

    public CartViewModel(ObservableCollection<CartItem> existingCart)
    {
        foreach (var item in existingCart)
            CartItems.Add(item);

        Total = CartItems.Sum(x => x.TotalPrice);
    }

    [RelayCommand]
    void IncreaseQuantity(CartItem item)
    {
        item.Quantity++;
        Total = CartItems.Sum(x => x.TotalPrice);
    }

    [RelayCommand]
    void DecreaseQuantity(CartItem item)
    {
        if (item.Quantity > 1)
            item.Quantity--;
        else
            CartItems.Remove(item);

        Total = CartItems.Sum(x => x.TotalPrice);
    }

    [RelayCommand]
    async Task ProceedToPayment()
    {
        await Shell.Current.GoToAsync("PaymentPage");
    }
}
