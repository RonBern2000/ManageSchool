using ManageSchoolAPI.Models.Roles;

namespace ManageSchoolAPI.Models
{
    public class Jenitor : Employee
    {
        public Jenitor() { }
        public Jenitor(IEmployeeRole employeeRole, string name, string surname) : base(name, surname) 
        {
            EmployeeRole = employeeRole;
        }
        public override void EarnMoney()
        {
            //TODO service that updates salary by a setted rate in db
        }
    }
}
