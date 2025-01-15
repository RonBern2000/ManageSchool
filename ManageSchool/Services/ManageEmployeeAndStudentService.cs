using ManageSchool.Models;
using System.Text;
using System.Text.Json;

namespace ManageSchool.Services
{
    public class ManageEmployeeAndStudentService : IAddEmployeeAndStudentService
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
    }
}
