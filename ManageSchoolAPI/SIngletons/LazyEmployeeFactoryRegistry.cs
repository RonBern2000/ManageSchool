using ManageSchoolAPI.Factories;
using ManageSchoolAPI.Models;

namespace ManageSchoolAPI.SIngletons
{
    public sealed class LazyEmployeeFactoryRegistry
    {
        private static readonly Lazy<Dictionary<string, IEmployeeFactory>> instance = new Lazy<Dictionary<string, IEmployeeFactory>>(() => []);
        public static Dictionary<string, IEmployeeFactory> Instance => instance.Value;
        private LazyEmployeeFactoryRegistry() { }
        public void InitializeFactories()
        {
            Instance[nameof(Teacher)] = new TeacherFactory();
            Instance[nameof(Jenitor)] = new JenitorFactory();
        }
    }
}
