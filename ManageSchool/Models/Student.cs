using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageSchool.Models
{
    public enum Grade
    {
        Tenth = 1,
        Eleventh = 2,
        Twelfth = 4,
    }
    public class Student
    {
        public string FullName { get; set; } = default!;
        public Grade Grade { get; set; } = default!;
        public string? TeacherID { get; set; }
    }
}
