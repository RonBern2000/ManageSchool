using ManageSchool.Views;

namespace ManageSchool
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(RegisterPage), typeof(RegisterPage));

            Routing.RegisterRoute(nameof(ManagePage), typeof(ManagePage));
        }
    }
}
