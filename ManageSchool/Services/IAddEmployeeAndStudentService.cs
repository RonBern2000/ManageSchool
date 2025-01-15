using ManageSchool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageSchool.Services
{
    public interface IAddEmployeeAndStudentService
    {
        Task<HttpResponseMessage> AddTeacherAsync(Teacher t);
        Task<HttpResponseMessage> AddJanitorAsync(Janitor j);
        Task<HttpResponseMessage> AddStudentAsync(Student s);
    }
}
