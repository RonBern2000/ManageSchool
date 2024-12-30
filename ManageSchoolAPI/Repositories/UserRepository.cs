using ManageSchoolAPI.Data;
using ManageSchoolAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ManageSchoolAPI.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly SchoolContext _schoolContext;
        public UserRepository(SchoolContext schoolContext)
        {
            _schoolContext = schoolContext;
        }

        public async Task AddUserAsync(User newUser)
        {
            await _schoolContext.Users.AddAsync(newUser);
            await _schoolContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(User userToDelete)
        {
            _schoolContext.Users.Remove(userToDelete);
            await _schoolContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            var users = await _schoolContext.Users.ToListAsync();
            return users;
        }

        public async Task<User?> GetUserAsync(string id)
           => await _schoolContext.Users.FindAsync(id);

        public async Task<User?> GetUserByUsernameAsync(string username)
            => await _schoolContext.Users.Where(x => x.Username == username).FirstOrDefaultAsync();
        public async Task<User?> GetUserByEmailAsync(string email)
            => await _schoolContext.Users.Where(x => x.Email == email).FirstOrDefaultAsync();

        public async Task SaveChangesAsync()
        {
            await _schoolContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(string id, User user)
        {
            var existingUser = await _schoolContext.Users.FindAsync(id);

            if (existingUser is null)
            {
                throw new KeyNotFoundException($"User with ID {id} not found.");
            }

            existingUser.Username = user.Username;
            existingUser.Email = user.Email;
            existingUser.Username = user.Password;

            await _schoolContext.SaveChangesAsync();
        }
    }
}
