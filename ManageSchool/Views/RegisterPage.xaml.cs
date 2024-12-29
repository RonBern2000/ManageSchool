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
        protected override void OnNavigatedTo(NavigatedToEventArgs args)
        {
            base.OnNavigatedTo(args);

			if(BindingContext is  RegisterViewModel registerViewModel)
			{
				registerViewModel.Reset();
			}
        }
    }
}