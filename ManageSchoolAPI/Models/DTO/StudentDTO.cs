namespace ManageSchoolAPI.Models.DTO
{
    public class StudentDTO
    {
        public string FullName { get; set; } = default!;
        public int Grade { get; set; } = default!;
        public string? TeacherId { get; set; }
    }
}
