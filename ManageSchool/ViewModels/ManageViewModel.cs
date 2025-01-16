using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ManageSchool.Models;
using ManageSchool.Services;

namespace ManageSchool.ViewModels
{
    public partial class ManageViewModel: ObservableObject
    {
        private readonly IAddEmployeeAndStudentService _addEmployeeAndStudentService;
        private readonly IGetTeachers _getTeachersService;
        #region Props
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
        IList<Teacher> ?teachers = [];
        [ObservableProperty]
        Teacher selectedTeacher = new Teacher();
        [ObservableProperty]
        IList<string> professions = ["Biolegy", "Math", "History", "Geography"];
        [ObservableProperty]
        IList<string> selectedProfessions = [];
        #endregion
        public ManageViewModel(IAddEmployeeAndStudentService addEmployeeAndStudentService, IGetTeachers getTeachersService)
        {
            _addEmployeeAndStudentService = addEmployeeAndStudentService;
            _getTeachersService = getTeachersService;
        }
        [RelayCommand]
        public async Task SelectForm(string formType)
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
                    Teachers = await _getTeachersService.GetTeachersAsync();
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
                    Teacher.Professions = (Profession)GetProffessions();
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
        private int GetProffessions()
        {
            if (SelectedProfessions.Count == 0)
                return 0;
            var profs = Enum.GetNames(typeof(Profession));
            int professions = 0;
            foreach(var proffession in SelectedProfessions)
            {
                if (profs.Contains(proffession))
                {
                    var profession = (Profession)Enum.Parse(typeof(Profession), proffession);
                    professions += (int)profession;
                }
            }
            return professions;
        }
    }
}
