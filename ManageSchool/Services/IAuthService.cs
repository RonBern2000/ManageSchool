using ManageSchool.Models.DTO;

namespace ManageSchool.Services
{
    public interface IAuthService
    {
        Task<LoginResponse?> LoginAsync(string username, string password);
        Task<LoginResponse?> RegisterAsync(string username, string password, string email);
        Task SaveTokenAsync(string token);
    }
}
