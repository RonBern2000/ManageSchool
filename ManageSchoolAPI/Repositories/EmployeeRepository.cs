using ManageSchoolAPI.Data;
using ManageSchoolAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ManageSchoolAPI.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly SchoolContext _schoolContext;
        public EmployeeRepository(SchoolContext schoolContext)
        {
            _schoolContext = schoolContext;
        }
        public async Task AddEmployeeAsync(Employee employee)
        {
            if (employee is Teacher teacher) 
            {
                await _schoolContext.Teachers.AddAsync(teacher);
            }
            else if(employee is Janitor jenitor)
            {
                await _schoolContext.Jenitors.AddAsync(jenitor);
            }
            else
            {
                throw new ArgumentException("Unsupported employee type", nameof(employee));
            }
            await _schoolContext.SaveChangesAsync();
        }
        public async Task DeleteEmployeeAsync(Employee employee)
        {
            if (employee is Teacher teacher)
            {
                _schoolContext.Teachers.Remove(teacher);
            }
            else if (employee is Janitor jenitor)
            {
                _schoolContext.Jenitors.Remove(jenitor);
            }
            else
            {
                throw new ArgumentException("Unsupported employee type", nameof(employee));
            }
            await _schoolContext.SaveChangesAsync();
        }

        public async Task<Teacher?> ?GetTeacherAsync(string employeeId)
        {
            var t = await _schoolContext.Teachers.FindAsync(employeeId);
            return t is not null ? t : null;
        }

        public async Task<IList<Teacher>> GetTeachersAsync(string userId)
        {
            var teachers = await _schoolContext.Teachers
                .Include(x => x.Manager)
                .Where(x => x.Manager.UserId == userId)
                .ToListAsync();
            return teachers;
        }
    }
}
