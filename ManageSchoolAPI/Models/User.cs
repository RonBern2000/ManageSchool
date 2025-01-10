namespace ManageSchoolAPI.Models
{
    public class User
    {
        public string UserId { get; set; } = default!;
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? Email { get; set; }
        public virtual ICollection<Teacher>? Teachers { get; set; } = [];
    }
}
