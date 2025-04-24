using restomono;
using restomono.Views;

namespace restomono.Views;

public partial class MenuPage : ContentPage
{
    public MenuPage()
    {
        InitializeComponent();
        BindingContext = AppData.MenuVM;
    }

    private async void OnCartClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new CartPage(AppData.MenuVM.CartItems));
    }
}
