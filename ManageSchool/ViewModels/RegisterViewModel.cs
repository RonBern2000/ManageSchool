using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ManageSchool.Models.DTO;
using ManageSchool.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageSchool.ViewModels
{
    public partial class RegisterViewModel : ObservableObject
    {
        private readonly IAuthService _authService;
        [ObservableProperty]
        User user;
        [ObservableProperty]
        string username;
        [ObservableProperty]
        string password;
        [ObservableProperty]
        string email;
        public RegisterViewModel(IAuthService authService)
        {
            User = new();
            Username = string.Empty;
            Password = string.Empty;
            Email = string.Empty;
            _authService = authService;
        }
        [RelayCommand]
        public async Task RegisterAsync()
        {
            if (string.IsNullOrEmpty(Username) || string.IsNullOrEmpty(Password))
                return;

            var loginResponse = await _authService.LoginAsync(Username, Password);

            if (loginResponse is not null)
            {
                await _authService.SaveTokenAsync(loginResponse.Token!);
                User = loginResponse.User!;
                return;
                //TODO: Navigate to the next page
            }
            //TODO: Handle failure
        }
    }
}
