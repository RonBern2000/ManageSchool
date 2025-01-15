using ManageSchoolAPI.Models;
using ManageSchoolAPI.Models.Roles;

namespace ManageSchoolAPI.Factories
{
    public class JanitorFactory : IEmployeeFactory<Janitor>
    {
        Janitor IEmployeeFactory<Janitor>.CreateEmployee(EmployeeCreationParameters parameters)
        {
            return new Janitor(parameters.EmployeeRole, parameters.Name, parameters.Surname) { EmployeeId = Guid.NewGuid().ToString(), Manager = parameters.Manager };
        }
    }
}
