using ManageSchool.ViewModels;

namespace ManageSchool.Views;

public partial class ManagePage : ContentPage
{
	public ManagePage(ManageViewModel manageViewModel)
	{
		InitializeComponent();
        BindingContext = manageViewModel;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        Shell.SetBackButtonBehavior(this, new BackButtonBehavior
        {
            IsEnabled = false,
            IsVisible = false
        });
    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();

        Shell.SetBackButtonBehavior(this, new BackButtonBehavior
        {
            IsEnabled = true,
            IsVisible = true
        });
    }
    protected async void OnItemClicked(object sender, EventArgs e)
    {
        ToolbarItem item = (ToolbarItem)sender;
        await Shell.Current.GoToAsync($"{item.Text}", true);
        return;
    }
}