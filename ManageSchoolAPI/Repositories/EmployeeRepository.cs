using ManageSchoolAPI.Data;
using ManageSchoolAPI.Models;

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
            else if(employee is Jenitor jenitor)
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
            else if (employee is Jenitor jenitor)
            {
                _schoolContext.Jenitors.Remove(jenitor);
            }
            else
            {
                throw new ArgumentException("Unsupported employee type", nameof(employee));
            }
            await _schoolContext.SaveChangesAsync();
        }
    }
}
