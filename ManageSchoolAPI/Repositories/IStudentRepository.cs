using ManageSchoolAPI.Models;

namespace ManageSchoolAPI.Repositories
{
    public interface IStudentRepository
    {
        Task AddStudentAsync(Student student);
    }
}
