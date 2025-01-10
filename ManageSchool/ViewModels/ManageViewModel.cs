using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageSchool.ViewModels
{
    public partial class ManageViewModel: ObservableObject
    {
        [ObservableProperty]
        bool isFormVisible;

        [RelayCommand]
        public async Task AddTeacherAsync()
        {
            IsFormVisible = true;
        }
        [RelayCommand]
        public async Task AddJenitorAsync()
        {
            IsFormVisible = true;
        }
        [RelayCommand]
        public async Task AddStudentAsync()
        {
            IsFormVisible = true;
        }
        [RelayCommand]
        public void CancelFormAsync()=>
            IsFormVisible = false;
        [RelayCommand]
        public async Task SubmitFormAsync()
        {

        }
    }
}
