using ManageSchoolAPI.Models;
using ManageSchoolAPI.Models.Roles;

namespace ManageSchoolAPI.Factories
{
    public interface IEmployeeFactory<out T> where T : Employee
    {
        public T CreateEmployee(EmployeeCreationParameters employeeCreationParameters);
    }
}
