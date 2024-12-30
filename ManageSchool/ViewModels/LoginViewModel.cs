using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ManageSchool.Models.DTO;
using ManageSchool.Services;
using ManageSchool.Views;

namespace ManageSchool.ViewModels
{
    public partial class LoginViewModel : ObservableObject
    {
        private readonly IAuthService _authService;
        [ObservableProperty]
        User user;
        [ObservableProperty]
        string username;
        [ObservableProperty]
        string password;
        public LoginViewModel(IAuthService authService)
        {
            user = new();
            username = string.Empty;
            password = string.Empty;
            _authService = authService;
        }

        [RelayCommand]
        public async Task LoginAsync()
        {
            if (string.IsNullOrEmpty(Username) || string.IsNullOrEmpty(Password))
                return;

            var loginResponse = await _authService.LoginAsync(Username, Password);

            if (loginResponse is not null)
            {
                await _authService.SaveTokenAsync(loginResponse.Token!);
                User = loginResponse.User!;

                await Shell.Current.GoToAsync($"{nameof(ManagePage)}", true);
                return;
            }
            await Shell.Current.DisplayAlert("Log in failed", "Please try again", "OK");
        }
        [RelayCommand]
        public async Task GoToRegisterAsync()
        {
            await Shell.Current.GoToAsync($"{nameof(RegisterPage)}",true);
        }
    }
}
