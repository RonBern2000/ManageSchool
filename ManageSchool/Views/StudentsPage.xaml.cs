using ManageSchool.Services;

namespace ManageSchool.Views;

public partial class StudentsPage : ContentPage
{
    private readonly IGetEmployeesAndStudents _getEmployeesAndStudentsService;
	public StudentsPage(IGetEmployeesAndStudents getEmployeesAndStudents)
	{
		InitializeComponent();
        _getEmployeesAndStudentsService = getEmployeesAndStudents;
    }
    protected override async void OnAppearing()
    {
        var students = await _getEmployeesAndStudentsService.GetStudentsAsync();
        StudentsCollectionView.ItemsSource = students;
        base.OnAppearing();
    }
}