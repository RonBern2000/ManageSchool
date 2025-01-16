using ManageSchoolAPI.Enums;

namespace ManageSchoolAPI.Models.DTO
{
    public class TeacherDTO
    {
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public Profession Professions { get; set; }
        public string? UserId { get; set; }
    }
}
