using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageSchool.Models
{
    public enum Grade
    {
        Tenth = 0,
        Eleventh = 1,
        Twelfth = 2,
    }
    public class Student
    {
        public string FullName { get; set; } = default!;
        public Grade Grade { get; set; } = default!;
        public string? TeacherID { get; set; }
    }
}
