using ManageSchoolAPI.Data;
using ManageSchoolAPI.Models;
using ManageSchoolAPI.Models.DTO;
using ManageSchoolAPI.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ManageSchoolAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly JwtSettings _jwtSettings;
        private readonly IUserRepository _userRepository;

        public UserController(IOptions<JwtSettings> jwtSettings, IUserRepository userRepository)
        {
            _userRepository = userRepository;
            _jwtSettings = jwtSettings.Value;
        }

        // GET: api/User Just for testing
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            var users = await _userRepository.GetAllUsersAsync();
            return Ok(users);
        }

        // GET: api/User/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(string id)
        {
            var user = await _userRepository.GetUserAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(RegisterUserDTO userDto)
        {
            var newUser = new User
            {
                UserId = Guid.NewGuid().ToString(),
                Username = userDto.Username,
                Email = userDto.Email,
                Password = BCrypt.Net.BCrypt.HashPassword(userDto.Password),
            };
            await _userRepository.AddUserAsync(newUser);
            await _userRepository.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = newUser.UserId }, newUser);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            var user = await _userRepository.GetUserAsync(id);
            if (user is null)
            {
                return NotFound();
            }

            await _userRepository.DeleteAsync(user);
            await _userRepository.SaveChangesAsync();

            return NoContent();
        }

        private async Task <bool> UserExists(string id)
        {
            var user = await _userRepository.GetUserAsync(id);
            return true ? user is not null : false;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginUserDTO loginUser)
        {
            var user = await _userRepository.GetUserByUsernameAsync(loginUser.Username!);

            if (user is null)
                return Unauthorized("Invalid username or password");

            bool isPasswordValid = BCrypt.Net.BCrypt.Verify(loginUser.Password, user.Password);

            if (!isPasswordValid)
                return Unauthorized("Invalid username or password");

            var token = GenerateJwtToken(user);

            return Ok(new
            {
                Token = token,
                User = user,
            });
        }

        private string GenerateJwtToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtSettings.Key!);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(
                [
                    new Claim(ClaimTypes.Name, user.Username!),
                    new Claim(ClaimTypes.NameIdentifier, user.UserId!),
                ]),
                Expires = DateTime.UtcNow.AddMinutes(_jwtSettings.DurationInMinutes),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Issuer = _jwtSettings.Issuer,
                Audience = _jwtSettings.Audience
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
