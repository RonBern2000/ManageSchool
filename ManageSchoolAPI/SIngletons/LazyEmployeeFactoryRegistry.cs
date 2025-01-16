using ManageSchoolAPI.Factories;
using ManageSchoolAPI.Models;
using System.Collections.Immutable;

namespace ManageSchoolAPI.SIngletons
{
    public sealed class LazyEmployeeFactoryRegistry
    {
        private static readonly Lazy<ImmutableDictionary<string, IEmployeeFactory<Employee>>> instance = new Lazy<ImmutableDictionary<string, IEmployeeFactory<Employee>>>(() => InitializeFactories());
        public static ImmutableDictionary<string, IEmployeeFactory<Employee>> Instance => instance.Value;
        private LazyEmployeeFactoryRegistry() { }
        private static ImmutableDictionary<string, IEmployeeFactory<Employee>> InitializeFactories()
        {
            var factories = ImmutableDictionary<string, IEmployeeFactory<Employee>>.Empty.ToBuilder();
            factories[nameof(Teacher)] = new TeacherFactory();
            factories[nameof(Janitor)] = new JanitorFactory();
            return factories.ToImmutable();
        }
    }
}
