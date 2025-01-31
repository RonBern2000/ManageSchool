using ManageSchoolAPI.Data;
using ManageSchoolAPI.Models;
using ManageSchoolAPI.Models.DTO;
using Microsoft.EntityFrameworkCore;

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
            await _schoolContext.SaveChangesAsync();
        }

        public async Task<ICollection<StudentDTO>> GetAllStudentsAsync(string userId)
        {
            var students = await _schoolContext.Students
                .Include(student => student.Teacher)
                .ThenInclude(teacher => teacher!.Manager)
                .Where(student => student.Teacher is Teacher && 
                                    student.Teacher.Manager != null && 
                                    student.Teacher.Manager.UserId == userId)
                .Select(student => new StudentDTO
                {
                    TeacherId = student.Teacher!.EmployeeId,
                    FullName = student.FullName,
                    Grade = (int)student.Grade,
                })
                .ToListAsync();
            return students;
        }
    }
}
