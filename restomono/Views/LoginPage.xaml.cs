using restomono.Services;

namespace restomono.Views;

public partial class LoginPage : ContentPage
{
    public LoginPage()
    {
        InitializeComponent();
    }

    private async void OnLoginClicked(object sender, EventArgs e)
    {
        var success = await AuthService.LoginAsync(usernameEntry.Text);
        if (success)
        {
            await Shell.Current.GoToAsync("//MenuPage");
        }
        else
        {
            await DisplayAlert("Login Failed", "User not found", "OK");
        }
    }
}
