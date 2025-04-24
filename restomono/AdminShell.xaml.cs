namespace restomono;

public partial class AdminShell : Shell
{
    public AdminShell()
    {
        InitializeComponent();

        Routing.RegisterRoute("StatisticsPage", typeof(Views.StatisticsPage));
        Routing.RegisterRoute("PlatCrudPage", typeof(Views.PlatCrudPage));
        Routing.RegisterRoute("UserCrudPage", typeof(Views.UserCrudPage));
    }
}
