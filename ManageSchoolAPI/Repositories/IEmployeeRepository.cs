using ManageSchoolAPI.Models;
using ManageSchoolAPI.Models.DTO;
namespace ManageSchoolAPI.Repositories
{
    public interface IEmployeeRepository
    {
        Task AddEmployeeAsync(Employee employee);
        Task DeleteEmployeeAsync(Employee employee);
        Task<Teacher?> ?GetTeacherAsync(string employeeId);
        Task<IList<Teacher>> GetTeachersAsync(string userId);
        Task <ICollection<EmployeeDto>> GetEmployeesAsync(string userId);
    }
}
