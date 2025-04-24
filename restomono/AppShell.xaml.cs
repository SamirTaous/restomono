using restomono.Views;

namespace restomono;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        Routing.RegisterRoute("LoginPage", typeof(LoginPage));
        Routing.RegisterRoute("MenuPage", typeof(MenuPage));
        Routing.RegisterRoute("PaymentPage", typeof(PaymentPage));
        Routing.RegisterRoute("ProfilePage", typeof(ProfilePage));
        Routing.RegisterRoute("StatisticsPage", typeof(StatisticsPage));
        Routing.RegisterRoute("PlatCrudPage", typeof(PlatCrudPage));
        Routing.RegisterRoute("UserCrudPage", typeof(UserCrudPage));
    }
}
