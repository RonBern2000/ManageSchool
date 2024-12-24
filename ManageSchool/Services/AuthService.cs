using ManageSchool.Models.DTO;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

namespace ManageSchool.Services
{
    public class AuthService : IAuthService
    {
        private readonly HttpClient _httpClient;
        private const string apiUrl = "http://10.0.2.2:5153/api/User";
        public AuthService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<LoginResponse?> LoginAsync(string username, string password)
        {
            var loginDto = new { Username = username, Password = password };
            var jsonContent = new StringContent(JsonSerializer.Serialize(loginDto), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync($"{apiUrl}/login", jsonContent);

            if (response.IsSuccessStatusCode)
            {
                var loginResponse = await response.Content.ReadFromJsonAsync<LoginResponse>();
                return loginResponse;
            }
            return null;
        }
        public async Task<LoginResponse?> RegisterAsync(string username, string password, string email)
        {
            var registerDto = new { Username = username, Password = password, Email = email };
            var jsonContent = new StringContent(JsonSerializer.Serialize(registerDto), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync($"{apiUrl}/register", jsonContent);

            if (response.IsSuccessStatusCode)
            {
                var loginResponse = await response.Content.ReadFromJsonAsync<LoginResponse>();
                return loginResponse;
            }
            return null;
        }
        public async Task SaveTokenAsync(string token)
        {
            try
            {
                await SecureStorage.SetAsync("jwt_token", token);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while saving the token, {ex.Message}");
            }
        }
    }
}
