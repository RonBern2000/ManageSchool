using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ManageSchool.Models.DTO;
using ManageSchool.Services;
using ManageSchool.Validations;
using ManageSchool.Views;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace ManageSchool.ViewModels
{
    public partial class RegisterViewModel : ObservableObject
    {
        public RegistrationForm RegistrationForm { get; }
        public ObservableCollection<string> Errors { get; } = [];
        readonly IAuthService _authService;
        [ObservableProperty] 
        string usernameErrorMessage; 
        [ObservableProperty] 
        string passwordErrorMessage; 
        [ObservableProperty] 
        string confirmPasswordErrorMessage; 
        [ObservableProperty] 
        string emailErrorMessage;
        public RegisterViewModel(IAuthService authService)
        {
            RegistrationForm = new RegistrationForm();
            RegistrationForm.ErrorsChanged += OnErrorsChanged;
            _authService = authService;
            usernameErrorMessage = string.Empty;
            passwordErrorMessage = string.Empty;
            emailErrorMessage = string.Empty;
            confirmPasswordErrorMessage = string.Empty;
        }
        public void Reset()
        {
            UsernameErrorMessage = string.Empty;
            PasswordErrorMessage = string.Empty;
            EmailErrorMessage = string.Empty;
            ConfirmPasswordErrorMessage = string.Empty;
            RegistrationForm.Clear();
            Errors.Clear();
        }
        private void OnErrorsChanged(object ?sender, DataErrorsChangedEventArgs e)
        {
            Errors.Clear();

            var allErrors = RegistrationForm.GetErrors(null);

            if (allErrors is not null)
            {
                foreach (var error in allErrors)
                    Errors.Add(error.ErrorMessage!);
            }
            UpdateErrorMessages(e.PropertyName);
        }
        public void UpdateErrorMessages(string? propertyName)
        {
            switch (propertyName)
            {
                case nameof(RegistrationForm.Username):
                    UsernameErrorMessage = GetErrorMessage(propertyName);
                    break;
                case nameof(RegistrationForm.Password):
                    PasswordErrorMessage = GetErrorMessage(propertyName);
                    break;
                case nameof(RegistrationForm.ConfirmPassword):
                    ConfirmPasswordErrorMessage = GetErrorMessage(propertyName);
                    break;
                case nameof(RegistrationForm.Email):
                    EmailErrorMessage = GetErrorMessage(propertyName);
                    break;
            }
        }
        private string GetErrorMessage(string propertyName)
        {
            var errors = RegistrationForm.GetErrors(propertyName);
            return errors?.FirstOrDefault()?.ErrorMessage ?? string.Empty;
        }

        [RelayCommand]
        public async Task RegisterAsync()
        {
            var errors = RegistrationForm.GetErrors(null);
            if (!RegistrationForm.GetErrors(null).Any())
            {
                var registration = await _authService.RegisterAsync(RegistrationForm.Username, RegistrationForm.Password, RegistrationForm.Email);

                if (registration is not null)
                {
                    await Shell.Current.GoToAsync($"{nameof(ManagePage)}", true);
                }
                return;
            }
            await Shell.Current.DisplayAlert("Error", "Please go over the form again", "OK");
        }
    }
}
