using ManageSchool.ViewModels;

namespace ManageSchool.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage(LoginViewModel loginViewModel)
        {
            InitializeComponent();
            BindingContext = loginViewModel;
        }
    }

}
