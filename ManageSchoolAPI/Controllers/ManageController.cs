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
        public async Task<IActionResult> AddStudentAsync(StudentDTO s)
        {
            if (s.TeacherId is null)
                return BadRequest();
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userId is null)
                return BadRequest();
            var user = await _userRepository.GetUserAsync(userId);
            if (user is null)
                return BadRequest();

            var t = await _employeeRepository.GetTeacherAsync(s.TeacherId)!;
            if (t is null)
            {
                return BadRequest();
            }
            Student student = new Student()
            {
                StudentId = Guid.NewGuid().ToString(),
                FullName = s.FullName,
                Grade = (Grade)s.Grade,
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
                    EmployeeId = teacher.EmployeeId,
                    Name = teacher.Name,
                    Surname = teacher.Surname,
                    Professions = teacher.Professions,
                    UserId = userId,
                });
            }
            return Ok(dtoTeachers);
        }
        [HttpGet("GetEmployees")]
        public async Task<ActionResult<IList<EmployeeDto>>> GetEmployeesAsync()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userId is null)
                return BadRequest();
            var user = await _userRepository.GetUserAsync(userId);
            if (user is null)
                return BadRequest();

            var employeeDtos = await _employeeRepository.GetEmployeesAsync(userId);
            return Ok(employeeDtos);
        }
        [HttpGet("GetStudents")]
        public async Task<ActionResult<IList<StudentDTO>>> GetStudentsAsync()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userId is null)
                return BadRequest();
            var user = await _userRepository.GetUserAsync(userId);
            if (user is null)
                return BadRequest();

            var students = await _studentRepository.GetAllStudentsAsync(userId);
            return Ok(students);
        }
    }
}
