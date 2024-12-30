namespace ManageSchool.Views;

public partial class ManagePage : ContentPage
{
	public ManagePage()
	{
		InitializeComponent();
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

}