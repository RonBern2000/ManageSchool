using ManageSchoolAPI.Models;
using ManageSchoolAPI.Models.DTO;

namespace ManageSchoolAPI.Repositories
{
    public interface IStudentRepository
    {
        Task AddStudentAsync(Student student);
        Task <ICollection<StudentDTO>> GetAllStudentsAsync(string userId);
    }
}
