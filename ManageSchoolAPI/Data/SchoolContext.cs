using ManageSchoolAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ManageSchoolAPI.Data
{
    public class SchoolContext : DbContext
    {
        public SchoolContext(DbContextOptions<SchoolContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .HasDiscriminator<string>("EmployeeType")
                .HasValue<Teacher>(nameof(Teacher))
                .HasValue<Janitor>(nameof(Janitor));

            base.OnModelCreating(modelBuilder);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
            base.OnConfiguring(optionsBuilder);
        }
        public DbSet<User> Users { get; set; } = default!;
        public DbSet<Teacher> Teachers { get; set; } = default!;
        public DbSet<Janitor> Jenitors { get; set; } = default!;
        public DbSet<Student> Students { get; set; }= default!;
    }
}
