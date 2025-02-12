﻿using ManageSchoolAPI.Models.Roles;

namespace ManageSchoolAPI.Models
{
    public class Janitor : Employee
    {
        public Janitor() { }
        public Janitor(IEmployeeRole employeeRole, string name, string surname) : base(name, surname) 
        {
            EmployeeRole = employeeRole;
        }
        public override void EarnMoney()
        {
            Salary += 5;
        }
    }
}
