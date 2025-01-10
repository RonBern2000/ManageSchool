using ManageSchoolAPI.Factories;
using ManageSchoolAPI.Models;
using ManageSchoolAPI.Models.DTO;
using ManageSchoolAPI.Models.Roles;
using ManageSchoolAPI.Repositories;
using ManageSchoolAPI.SIngletons;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ManageSchoolAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ManageController : ControllerBase
    {
        private readonly LazyEmployeeFactoryRegistry _lazyEmployeeFactoryRegistry;
        private readonly IEmployeeRepository _employeeRepository;
        public ManageController(LazyEmployeeFactoryRegistry lazyEmployeeFactoryRegistry, IEmployeeRepository employeeRepository) 
        {
            _employeeRepository = employeeRepository;
            _lazyEmployeeFactoryRegistry = lazyEmployeeFactoryRegistry;
            _lazyEmployeeFactoryRegistry.InitializeFactories();
        }
        [HttpPost("AddTeacher")]
        public async Task<IActionResult> AddTeacherAsync(TeacherDTO newTeacher)
        {
            EmployeeCreationParameters parameters = new EmployeeCreationParameters 
            {
                EmployeeRole = new TeacherRole(),
                Name = newTeacher.Name,
                Surname = newTeacher.Surname,
                Professions = newTeacher.Professions,
            };
            Teacher t = (Teacher)LazyEmployeeFactoryRegistry.Instance[nameof(Teacher)].CreateEmployee(parameters);
            await _employeeRepository.AddEmployeeAsync(t);
            return Ok();
        }
        [HttpPost("AddJenitor")]
        public async Task<IActionResult> AddJenitorAsync(JenitorDTO newJenitor)
        {
            EmployeeCreationParameters parameters = new EmployeeCreationParameters
            {
                EmployeeRole = new JanitorRole(),
                Name = newJenitor.Name,
                Surname = newJenitor.Surname,
            };
            Teacher t = (Teacher)LazyEmployeeFactoryRegistry.Instance[nameof(Janitor)].CreateEmployee(parameters);
            await _employeeRepository.AddEmployeeAsync(t);
            return Ok();
        }
    }
}
