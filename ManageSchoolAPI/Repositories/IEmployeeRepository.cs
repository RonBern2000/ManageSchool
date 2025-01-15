using ManageSchoolAPI.Models;
namespace ManageSchoolAPI.Repositories
{
    public interface IEmployeeRepository
    {
        Task AddEmployeeAsync(Employee employee);
        Task DeleteEmployeeAsync(Employee employee);
        Task<Teacher?> ?GetTeacherAsync(string employeeId);
    }
}
