using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ManageSchool.Models;
using ManageSchool.Services;

namespace ManageSchool.ViewModels
{
    public partial class ManageViewModel: ObservableObject
    {
        private readonly IAddEmployeeAndStudentService _addEmployeeAndStudentService;
        [ObservableProperty]
        bool isStudentForm;
        [ObservableProperty]
        bool isTeacherForm;
        [ObservableProperty]
        bool isJanitorForm;
        [ObservableProperty]
        Teacher teacher  = new Teacher();
        [ObservableProperty]
        Janitor janitor = new Janitor();
        [ObservableProperty] 
        Student student = new Student();
        [ObservableProperty]
        ICollection<Teacher> teachers = [];
        public ManageViewModel(IAddEmployeeAndStudentService addEmployeeAndStudentService)
        {
            _addEmployeeAndStudentService = addEmployeeAndStudentService;
        }
        [RelayCommand]
        public void SelectForm(string formType)
        {
            switch (formType)
            {
                case "Teacher":
                    Teacher = new Teacher();
                    IsTeacherForm = true;
                    return;
                case "Janitor":
                    Janitor = new Janitor();
                    IsJanitorForm = true;
                    return;
                case "Student":
                    //TODO: GET request to update the Teacher ICollection
                    Student = new Student();
                    IsStudentForm = true;
                    return;
            }
        }
        [RelayCommand]
        public async Task SubmitFormAsync(string modelType)
        {
            HttpResponseMessage? responseMessage = null;
            switch (modelType)
            {
                case "Teacher":
                    responseMessage = await _addEmployeeAndStudentService.AddTeacherAsync(Teacher);
                    break;
                case "Janitor":
                    responseMessage = await _addEmployeeAndStudentService.AddJanitorAsync(Janitor);
                    break;
                case "Student":
                    responseMessage = await _addEmployeeAndStudentService.AddStudentAsync(Student);
                    break;
            }
            if(responseMessage is not null && responseMessage.IsSuccessStatusCode)
            {
                // Toast msg for Success
                return;
            }
            // Toast msg for Error
        }
        [RelayCommand]
        public void CancelForm()
        {
            IsStudentForm = false;
            IsTeacherForm = false;
            IsJanitorForm= false;
        }
    }
}
