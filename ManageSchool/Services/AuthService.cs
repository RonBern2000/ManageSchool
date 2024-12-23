using ManageSchool.Models.DTO;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

namespace ManageSchool.Services
{
    public class AuthService : IAuthService
    {
        private readonly HttpClient _httpClient;
        private const string apiUrl = "http://10.0.2.2:5153/api/User/login";
        public AuthService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<LoginResponse?> LoginAsync(string username, string password)
        {
            var loginDto = new { Username = username, Password = password };
            var jsonContent = new StringContent(JsonSerializer.Serialize(loginDto), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(apiUrl, jsonContent);

            if (response.IsSuccessStatusCode)
            {
                var loginResponse = await response.Content.ReadFromJsonAsync<LoginResponse>();
                return loginResponse;
            }
            return null;
        }
    }
}
