using ManageSchoolAPI.Enums;

namespace ManageSchoolAPI.Models.DTO
{
    public class TeacherDTO
    {
        public string Name { get; set; } = default!;
        public string Surname { get; set; } = default!;
        public Profession Professions { get; set; } = default!;
    }
}
