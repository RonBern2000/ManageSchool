using ManageSchool.Models;
using ManageSchool.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageSchool.Services
{
    public interface IGetEmployeesAndStudents
    {
        Task<ICollection<Employee>?> GetEmployeesAsync();
        Task<ICollection<Student>?> GetStudentsAsync();
    }
}
