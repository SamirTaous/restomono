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
        confirmationMessage = $"✅ Payment successful! Thank you, {Name}.";
    }
}
