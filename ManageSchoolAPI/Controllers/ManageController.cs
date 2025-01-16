using ManageSchoolAPI.Factories;
using ManageSchoolAPI.Models;
using ManageSchoolAPI.Models.DTO;
using ManageSchoolAPI.Models.Roles;
using ManageSchoolAPI.Repositories;
using ManageSchoolAPI.SIngletons;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using ManageSchoolAPI.Enums;
using System.Net.WebSockets;
using System.Collections.Immutable;

namespace ManageSchoolAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ManageController : ControllerBase
    {
        private readonly ImmutableDictionary<string, IEmployeeFactory<Employee>> _factoryRegistry;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IUserRepository _userRepository;
        private readonly IStudentRepository _studentRepository;
        public ManageController(IEmployeeRepository employeeRepository, IUserRepository userRepository, IStudentRepository studentRepository)
        {
            _factoryRegistry = LazyEmployeeFactoryRegistry.Instance;
            _employeeRepository = employeeRepository;
            _userRepository = userRepository;
            _studentRepository = studentRepository;
        }
        [HttpPost("AddTeacher")]
        public async Task<IActionResult> AddTeacherAsync(TeacherDTO newTeacher)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userId is null)
                return BadRequest();
            var user = await _userRepository.GetUserAsync(userId);
            if (user is null)
                return BadRequest();

            EmployeeCreationParameters parameters = new EmployeeCreationParameters
            {
                EmployeeRole = new TeacherRole(),
                Name = newTeacher.Name!,
                Surname = newTeacher.Surname!,
                Professions = newTeacher.Professions,
                Manager = user,
            };
            var t = FactoryHelper.CreateEmployee<Teacher>(nameof(Teacher), parameters);
            await _employeeRepository.AddEmployeeAsync(t);
            return Ok();
        }
        [HttpPost("AddJanitor")]
        public async Task<IActionResult> AddJanitorAsync(JenitorDTO newJenitor)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userId is null)
                return BadRequest();
            var user = await _userRepository.GetUserAsync(userId);
            if (user is null)
                return BadRequest();

            EmployeeCreationParameters parameters = new EmployeeCreationParameters
            {
                EmployeeRole = new JanitorRole(),
                Name = newJenitor.Name,
                Surname = newJenitor.Surname,
                Manager = user,
            };
            var j = FactoryHelper.CreateEmployee<Janitor>(nameof(Janitor), parameters);
            await _employeeRepository.AddEmployeeAsync(j);
            return Ok();
        }
        [HttpPost("AddStudent")]
        public async Task<IActionResult> AddStudentAsync(string fullName, int grade, string teacherId)
        {
            if (teacherId is null)
                return BadRequest();
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userId is null)
                return BadRequest();
            var user = await _userRepository.GetUserAsync(userId);
            if (user is null)
                return BadRequest();

            var t = await _employeeRepository.GetTeacherAsync(teacherId)!;
            if (t is null)
            {
                return BadRequest();
            }
            Student student = new Student()
            {
                FullName = fullName,
                Grade = (Grade)grade,
                Teacher = t,
            };
            await _studentRepository.AddStudentAsync(student);

            return Ok();
        }
        [HttpGet("GetTeachers")]
        public async Task<ActionResult<IList<Teacher>>> GetTeachersAsync()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userId is null)
                return BadRequest();
            var user = await _userRepository.GetUserAsync(userId);
            if (user is null)
                return BadRequest();

            var teachers = await _employeeRepository.GetTeachersAsync(userId);
            IList<TeacherDTO> dtoTeachers = [];
            foreach (var teacher in teachers)
            {
                dtoTeachers.Add(new TeacherDTO()
                {
                    Name = teacher.Name,
                    Surname = teacher.Surname,
                    Professions = teacher.Professions,
                    UserId = userId,
                });
            }
            return Ok(dtoTeachers);
        }
    }
}
