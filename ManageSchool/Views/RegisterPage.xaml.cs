using ManageSchool.ViewModels;

namespace ManageSchool.Views
{
	public partial class RegisterPage : ContentPage
	{
		public RegisterPage(RegisterViewModel registerViewModel)
		{
			InitializeComponent();
			BindingContext = registerViewModel;
		}
	}
}