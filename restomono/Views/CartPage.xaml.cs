using System.Collections.ObjectModel;
using restomono.Models;
using restomono.ViewModels;

namespace restomono.Views;

public partial class CartPage : ContentPage
{
    public CartPage(ObservableCollection<CartItem> cartItems)
    {
        InitializeComponent();
        BindingContext = new CartViewModel(cartItems);
    }
}
