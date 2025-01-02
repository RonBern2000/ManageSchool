using ManageSchoolAPI.Models;
using ManageSchoolAPI.Models.Roles;

namespace ManageSchoolAPI.Factories
{
    public class TeacherFactory : IEmployeeFactory
    {
        public Employee CreateEmployee(IEmployeeRole employeeRole)
        {
            return new Teacher(employeeRole);
        }
    }
}
