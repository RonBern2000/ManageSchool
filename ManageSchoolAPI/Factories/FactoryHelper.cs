using ManageSchoolAPI.Models;
using ManageSchoolAPI.SIngletons;

namespace ManageSchoolAPI.Factories
{
    public static class FactoryHelper
    {
        public static TEmployee CreateEmployee<TEmployee>(string typeName, EmployeeCreationParameters parameters) where TEmployee: Employee
        {
            var factory = (IEmployeeFactory<TEmployee>)LazyEmployeeFactoryRegistry.Instance[typeName];
            return factory.CreateEmployee(parameters);
        }
    }
}
