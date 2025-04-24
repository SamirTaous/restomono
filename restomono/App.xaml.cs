namespace restomono;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();

        // Load the AppShell
        MainPage = new AppShell();

        // ✅ Navigate to LoginPage using relative routing
        Application.Current.Dispatcher.Dispatch(async () =>
        {
            await Shell.Current.GoToAsync("LoginPage");
        });
    }
}
