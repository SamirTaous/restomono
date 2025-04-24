namespace restomono;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        // Register pages with routes here
        Routing.RegisterRoute("PaymentPage", typeof(Views.PaymentPage));
    }
}
