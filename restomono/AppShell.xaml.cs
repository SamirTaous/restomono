using restomono.Views;

namespace restomono;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        // ✅ Register all routable pages for navigation
        Routing.RegisterRoute("LoginPage", typeof(LoginPage));
        Routing.RegisterRoute("MenuPage", typeof(MenuPage));
        Routing.RegisterRoute("ProfilePage", typeof(ProfilePage));
        Routing.RegisterRoute("PaymentPage", typeof(PaymentPage));
    }
}
