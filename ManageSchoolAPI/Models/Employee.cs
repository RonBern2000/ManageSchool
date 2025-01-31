using ManageSchoolAPI.Models.Roles;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ManageSchoolAPI.Models
{
    public abstract class Employee
    {
        [NotMapped]
        public IEmployeeRole EmployeeRole { protected get; set; } = default!;
        [Key]
        public string EmployeeId { get; set; } = default!;
        public string Name { get; set; } = default!;
        public string Surname { get; set; } = default!;
        public double Salary { get; set; }
        public virtual User Manager { get; set; } = default!;
        public Employee()
        { }
        public Employee(string name, string surename)
        {
            Name = name;
            Surname = surename;
        }
        public void Work()
        {
            EmployeeRole.DoTheirDuties(); // whether its a Jenitor or a Teacher. TODO: In a service we should save changes after work!
        }
        public abstract void EarnMoney();
    }
}
