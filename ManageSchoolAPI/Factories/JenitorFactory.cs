using ManageSchoolAPI.Models;
using ManageSchoolAPI.Models.Roles;

namespace ManageSchoolAPI.Factories
{
    public class JenitorFactory : IEmployeeFactory
    {
        public Employee CreateEmployee(EmployeeCreationParameters parameters)
        {
            return new Jenitor(parameters.EmployeeRole, parameters.Name, parameters.Surname) { EmployeeId = Guid.NewGuid().ToString() };
        }
    }
}
