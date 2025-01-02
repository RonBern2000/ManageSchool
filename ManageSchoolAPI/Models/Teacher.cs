using ManageSchoolAPI.Models.Roles;

namespace ManageSchoolAPI.Models
{
    public class Teacher : Employee
    {
        public Teacher(IEmployeeRole employeeRole): base(employeeRole) { }
        public override void EarnMoney()
        {
            //TODO: Service that updates salary(with a set rate) in db
        }
    }
}
