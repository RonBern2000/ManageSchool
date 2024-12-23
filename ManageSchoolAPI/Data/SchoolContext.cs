using ManageSchoolAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ManageSchoolAPI.Data
{
    public class SchoolContext : DbContext
    {
        public SchoolContext(DbContextOptions<SchoolContext> options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; } = default!;
    }
}
