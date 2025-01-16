using ManageSchool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageSchool.Services
{
    public interface IGetTeachers
    {
        Task<IList<Teacher>?> GetTeachersAsync();
    }
}
