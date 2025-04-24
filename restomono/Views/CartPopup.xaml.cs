using CommunityToolkit.Maui.Views;
using restomono.Models;
using System.Collections.ObjectModel;

namespace restomono.Views;

public partial class CartPopup : Popup
{
    public ObservableCollection<CartItem> CartItems { get; }
    public decimal Total { get; }

    public CartPopup(ObservableCollection<CartItem> items, decimal total)
    {
        InitializeComponent();
        CartItems = items;
        Total = total;
        BindingContext = this;
    }

    private async void OnProceedClicked(object sender, EventArgs e)
    {
        Close(); // Close the popup

        // ✅ Pass the total to PaymentPage
        await Shell.Current.Navigation.PushAsync(new PaymentPage(Total));
    }
}
