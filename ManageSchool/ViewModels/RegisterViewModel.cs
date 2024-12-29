using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ManageSchool.Models.DTO;
using ManageSchool.Services;
using ManageSchool.Validations;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace ManageSchool.ViewModels
{
    public partial class RegisterViewModel : ObservableObject
    {
        public RegistrationForm RegistrationForm { get; }
        public ObservableCollection<string> Errors { get; } = [];
        private readonly IAuthService _authService;
        public RegisterViewModel(IAuthService authService)
        {
            RegistrationForm = new RegistrationForm();
            RegistrationForm.ErrorsChanged += OnErrorsChanged;
            _authService = authService;
        }
        public void Reset()
        {
            RegistrationForm.Clear();
            Errors.Clear();
        }
        private void OnErrorsChanged(object ?sender, DataErrorsChangedEventArgs e)
        {
            Errors.Clear();

            var allErrors = RegistrationForm.GetErrors(null);

            if(allErrors is not null)
            {
                foreach (var error in allErrors)
                    Errors.Add(error.ErrorMessage!);
            }
        }

        [RelayCommand]
        public async Task RegisterAsync()
        {
            Errors.Clear();

            if (!Errors.Any())
            {
                await _authService.RegisterAsync(RegistrationForm.Username, RegistrationForm.Password, RegistrationForm.Email);
            }
        }
    }
}
