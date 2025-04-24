using CommunityToolkit.Mvvm.ComponentModel;

namespace restomono.Models;

public partial class CartItem : ObservableObject
{
    [ObservableProperty]
    private Plat plat;

    [ObservableProperty]
    private int quantity;

    public decimal TotalPrice => quantity * plat.Price;
}
