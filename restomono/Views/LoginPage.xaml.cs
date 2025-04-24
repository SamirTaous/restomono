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
        string username = usernameEntry.Text?.Trim();

        if (string.IsNullOrWhiteSpace(username))
        {
            await DisplayAlert("Error", "Please enter a username.", "OK");
            return;
        }

        var success = await AuthService.LoginAsync(username);

        if (success)
        {
            // Create shell dynamically based on role
            if (username.ToLower() == "admin")
                Application.Current.MainPage = new AdminShell();
            else
                Application.Current.MainPage = new AppShell();
        }
        else
        {
            await DisplayAlert("Login Failed", "User not found", "OK");
        }
    }
}
