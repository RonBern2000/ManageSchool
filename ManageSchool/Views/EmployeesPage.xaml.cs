using ManageSchool.Services;

namespace ManageSchool.Views;

public partial class EmployeesPage : ContentPage
{
	private readonly IGetEmployeesAndStudents _getEmployeesAndStudentsService;
	public EmployeesPage(IGetEmployeesAndStudents getEmployeesAndStudents)
	{
		InitializeComponent();
		_getEmployeesAndStudentsService = getEmployeesAndStudents;
	}
    protected override async void OnAppearing()
    {
		var employees = await _getEmployeesAndStudentsService.GetEmployeesAsync();
        EmployeesCollectionView.ItemsSource = employees;
        base.OnAppearing();
    }
}