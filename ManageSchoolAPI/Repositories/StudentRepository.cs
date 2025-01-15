using ManageSchoolAPI.Data;
using ManageSchoolAPI.Models;

namespace ManageSchoolAPI.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly SchoolContext _schoolContext;
        public StudentRepository(SchoolContext schoolContext)
        {
            _schoolContext = schoolContext;
        }
        public async Task AddStudentAsync(Student student)
        {
            await _schoolContext.Students.AddAsync(student);
        }
    }
}
