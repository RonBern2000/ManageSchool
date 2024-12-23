using ManageSchoolAPI.Models;
using ManageSchoolAPI.Models.DTO;
using System.Collections.ObjectModel;

namespace ManageSchoolAPI.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User?> GetUserAsync(string id);
        Task<User?> GetUserByUsernameAsync(string username);
        Task UpdateAsync(string id, User user);
        Task DeleteAsync(User userToDelete);
        Task AddUserAsync(User newUser);
        Task SaveChangesAsync();
    }
}
