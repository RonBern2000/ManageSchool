using ManageSchoolAPI.Models;
using ManageSchoolAPI.Models.Roles;

namespace ManageSchoolAPI.Factories
{
    public class JenitorFactory : IEmployeeFactory
    {
        public Employee CreateEmployee(IEmployeeRole employeeRole)
        {
            return new Jenitor(employeeRole);
        }
    }
}
