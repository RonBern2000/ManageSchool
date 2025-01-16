using ManageSchool.Models;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ManageSchool.Services
{
    public class ManageEmployeeAndStudentService : IAddEmployeeAndStudentService, IGetTeachers 
    {
        private readonly HttpClient _httpClient;
        private const string apiUrl = "http://10.0.2.2:5153/api/Manage";
        public ManageEmployeeAndStudentService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<HttpResponseMessage> AddJanitorAsync(Janitor j)
        {
            var jsonData = new StringContent(JsonSerializer.Serialize(j), Encoding.UTF8, "application/json");
            var res = await _httpClient.PostAsync($"{apiUrl}/AddJanitor", jsonData);
            return res;
        }

        public async Task<HttpResponseMessage> AddStudentAsync(Student s)
        {
            var jsonData = new StringContent(JsonSerializer.Serialize(s), Encoding.UTF8, "application/json");
            var res = await _httpClient.PostAsync($"{apiUrl}/AddStudent", jsonData);
            return res;
        }

        public async Task<HttpResponseMessage> AddTeacherAsync(Teacher t)
        {
            var jsonData = new StringContent(JsonSerializer.Serialize(t), Encoding.UTF8, "application/json");
            var res = await _httpClient.PostAsync($"{apiUrl}/AddTeacher", jsonData);
            return res;
        }

        public async Task<IList<Teacher>?> GetTeachersAsync()
        {
            var res = await _httpClient.GetAsync($"{apiUrl}/GetTeachers");
            if (res is null)
                return null;
            var teachers = await res.Content.ReadFromJsonAsync<IList<Teacher>>();
            return teachers;
        }
    }
}
