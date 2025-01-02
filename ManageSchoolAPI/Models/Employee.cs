using ManageSchoolAPI.Models.Roles;
using Microsoft.AspNetCore.Identity;

namespace ManageSchoolAPI.Models
{
    public abstract class Employee
    {
        public IEmployeeRole EmployeeRole { protected get; set; }
        public Employee(IEmployeeRole employeeRole)=>
            EmployeeRole = employeeRole;
        public void Work()
        {
            EmployeeRole.DoTheirDuties(); // whether its a Jenitor or a Teacher
        }
        public abstract void EarnMoney();
    }
}
