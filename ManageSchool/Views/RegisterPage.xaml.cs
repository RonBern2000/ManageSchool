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
		private void UsernameEntryUnfocused(object sender, FocusEventArgs e)
		{
            if (BindingContext is RegisterViewModel registerViewModel)
            {
                registerViewModel.RegistrationForm.ValidatePropertyWrapper(registerViewModel.RegistrationForm.Username, nameof(registerViewModel.RegistrationForm.Username));
                registerViewModel.UpdateErrorMessages(registerViewModel.RegistrationForm.Username);
            }
        }
        private void PasswordEntryUnfocused(object sender, FocusEventArgs e)
        {
            if (BindingContext is RegisterViewModel registerViewModel)
            {
                registerViewModel.RegistrationForm.ValidatePropertyWrapper(registerViewModel.RegistrationForm.Password, nameof(registerViewModel.RegistrationForm.Password));
                registerViewModel.UpdateErrorMessages(registerViewModel.RegistrationForm.Password);
            }
        }
        private void ConfirmPasswordEntryUnfocused(object sender, FocusEventArgs e)
        {
            if (BindingContext is RegisterViewModel registerViewModel)
            {
                registerViewModel.RegistrationForm.ValidatePropertyWrapper(registerViewModel.RegistrationForm.ConfirmPassword, nameof(registerViewModel.RegistrationForm.ConfirmPassword));
                registerViewModel.UpdateErrorMessages(registerViewModel.RegistrationForm.ConfirmPassword);
            }
        }
        private void EmailEntryUnfocused(object sender, FocusEventArgs e)
        {
            if (BindingContext is RegisterViewModel registerViewModel)
            {
                registerViewModel.RegistrationForm.ValidatePropertyWrapper(registerViewModel.RegistrationForm.Email, nameof(registerViewModel.RegistrationForm.Email));
                registerViewModel.UpdateErrorMessages(registerViewModel.RegistrationForm.Email);
            }
        }
    }
}