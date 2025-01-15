using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageSchool.Models
{
    [Flags]
    public enum Profession
    {
        Biolegy = 1,
        Math = 2,
        History = 4,
        Geography = 8,
    }
    public class Teacher
    {
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public Profession Professions { get; set; }
        public string? UserId { get; set; }
    }
}
