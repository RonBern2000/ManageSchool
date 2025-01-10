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
        private void EntryUnfocused(object sender, FocusEventArgs e)
        {
            if (BindingContext is RegisterViewModel registerViewModel)
            {
                var propertyName = (string)((Entry)sender).ReturnCommandParameter;
                registerViewModel.RegistrationForm.ValidatePropertyWrapper($"{registerViewModel.RegistrationForm.GetPropByString(propertyName)}", propertyName);
                registerViewModel.UpdateErrorMessages(propertyName);
            }
        }
    }
}