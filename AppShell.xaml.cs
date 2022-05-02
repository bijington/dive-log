using DiveLog.Views;

namespace DiveLog;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        Routing.RegisterRoute("AddDiveLogPage", typeof(AddDiveLogPage));
    }
}
