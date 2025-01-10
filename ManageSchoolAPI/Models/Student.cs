using ManageSchoolAPI.Enums;

namespace ManageSchoolAPI.Models
{
    public class Student
    {
        public string StudentId { get; set; } = default!;
        public string FullName { get; set; } = default!;
        public Grade Grade { get; set; } = default!;
        public virtual Teacher? Teacher { get; set; }
    }
}
