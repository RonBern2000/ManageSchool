using ManageSchool.Models.DTO;

namespace ManageSchool.Services
{
    public interface IAuthService
    {
        Task<LoginResponse?> LoginAsync(string username, string password);
    }
}
