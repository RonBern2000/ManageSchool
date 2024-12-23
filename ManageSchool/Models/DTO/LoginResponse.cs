using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageSchool.Models.DTO
{
    public class LoginResponse
    {
        public string ?Token { get; set; }
        public User? User { get; set; }
    }
}
