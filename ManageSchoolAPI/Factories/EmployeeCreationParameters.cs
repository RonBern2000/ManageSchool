using ManageSchoolAPI.Models;
using ManageSchoolAPI.Models.Roles;
using ManageSchoolAPI.Enums;

namespace ManageSchoolAPI.Factories
{
    public class EmployeeCreationParameters
    {
        public IEmployeeRole EmployeeRole { get; set; } = default!;
        public string Name { get; set; } = default!;
        public string Surname { get; set; } = default!;
        public Profession? Professions { get; set; }
    }
}
