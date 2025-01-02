using ManageSchoolAPI.Models.Roles;

namespace ManageSchoolAPI.Models
{
    public class Jenitor : Employee
    {
        public Jenitor(IEmployeeRole employeeRole): base(employeeRole) { }
        public override void EarnMoney()
        {
            //TODO service that updates salary by a setted rate in db
        }
    }
}
