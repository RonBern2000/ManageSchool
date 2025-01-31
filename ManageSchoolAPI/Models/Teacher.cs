using ManageSchoolAPI.Models.Roles;
using ManageSchoolAPI.Enums;

namespace ManageSchoolAPI.Models
{
    public class Teacher : Employee
    {
        public Profession Professions { get; set; }
        public virtual ICollection<Student> Students { get; set; } = [];
        public Teacher() { }
        public Teacher(IEmployeeRole employeeRole, string name, string surname, Profession professions): base(name, surname) 
        {
            EmployeeRole = employeeRole;
            Professions = professions;
        }
        public override void EarnMoney()
        {
            Salary += 5;
        }
    }
}
