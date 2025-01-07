using ManageSchoolAPI.Models;
using ManageSchoolAPI.Models.Roles;

namespace ManageSchoolAPI.Factories
{
    public interface IEmployeeFactory
    {
        public Employee CreateEmployee(EmployeeCreationParameters employeeCreationParameters);
    }
}
