using restomono.Services;
using restomono.Views;

namespace restomono;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();

        // Default shell (user shell)
        MainPage = new AppShell();

        Application.Current.Dispatcher.Dispatch(async () =>
        {
            var user = AuthService.CurrentUser;

            if (user != null && user.Name.ToLower() == "admin")
                MainPage = new AdminShell();
            else
                MainPage = new AppShell();

            await Shell.Current.GoToAsync("LoginPage");
        });
    }
}
