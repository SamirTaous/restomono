using restomono.Services;
using restomono.Models;

namespace restomono.Views;

public partial class PaymentPage : ContentPage
{
    private readonly decimal _totalAmount;

    public PaymentPage(decimal total)
    {
        InitializeComponent();
        _totalAmount = total;

        if (AuthService.CurrentUser != null)
        {
            nameEntry.Text = AuthService.CurrentUser.Name;
        }
    }

    private async void OnConfirmPaymentClicked(object sender, EventArgs e)
    {
        var user = AuthService.CurrentUser;

        if (user == null)
        {
            await DisplayAlert("Not Logged In", "Please login to complete your purchase.", "OK");
            return;
        }

        using var context = new PlatDbContext();
        var dbUser = await context.Users.FindAsync(user.Id);

        if (dbUser == null)
        {
            await DisplayAlert("Error", "User not found in database.", "OK");
            return;
        }

        if (dbUser.Wallet >= _totalAmount)
        {
            dbUser.Wallet -= _totalAmount;
            await context.SaveChangesAsync();

            // Update current session user
            AuthService.CurrentUser = dbUser;

            // ✅ Clear the cart
            AppData.MenuVM.CartItems.Clear();
            AppData.MenuVM.Total = 0;

            await DisplayAlert("Payment Successful", $"Thank you, {dbUser.Name}! Remaining Wallet: {dbUser.Wallet} DH", "OK");

            // ✅ Navigate back to MenuPage
            await Shell.Current.GoToAsync("///MenuPage");
        }
        else
        {
            await DisplayAlert("Insufficient Funds", "You do not have enough balance to complete this payment.", "OK");
        }
    }
}
