using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Threading.Tasks;

namespace restomono.ViewModels;

public partial class PaymentViewModel : ObservableObject
{
    [ObservableProperty] private string name;
    [ObservableProperty] private string cardNumber;
    [ObservableProperty] private string confirmationMessage;

    [RelayCommand]
    async Task ConfirmPayment()
    {
        await Task.Delay(1000); // Simulate processing

        await Shell.Current.DisplayAlert("Payment Confirmed", $"Thank you, {Name}! Your order has been placed.", "OK");

        // Clear form
        Name = string.Empty;
        CardNumber = string.Empty;
        ConfirmationMessage = string.Empty;

        // Clear cart
        AppData.MenuVM.CartItems.Clear();
        AppData.MenuVM.Total = 0;

        // Navigate back to MenuPage
        await Shell.Current.Navigation.PopToRootAsync(); // back to Menu
    }

}
