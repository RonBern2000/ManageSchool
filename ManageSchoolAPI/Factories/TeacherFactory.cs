﻿using ManageSchoolAPI.Models;
using ManageSchoolAPI.Enums;

namespace ManageSchoolAPI.Factories
{
    public class TeacherFactory : IEmployeeFactory
    {
        public Employee CreateEmployee(EmployeeCreationParameters parameters)
        {
            return new Teacher(parameters.EmployeeRole, parameters.Name, parameters.Surname, (Profession)parameters.Professions!) { EmployeeId = Guid.NewGuid().ToString(), Manager = parameters.Manager };
        }
    }
}
