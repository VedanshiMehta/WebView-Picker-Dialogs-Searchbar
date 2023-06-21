using C10_Exercises.ViewModel;
using System.Numerics;

namespace C10_Exercises.View.Exercise1;

public partial class Dashboard : ContentPage
{
	private LoginDashboardViewModel _loginDashboardViewModel;
	public Dashboard(LoginResponseModel loginResponse)
	{
		InitializeComponent();
		NavigationPage.SetHasBackButton(this, false);
		_loginDashboardViewModel=(LoginDashboardViewModel)BindingContext;
		_loginDashboardViewModel.LoginResponseModel=loginResponse;
	}
    protected override bool OnBackButtonPressed()
    {
		return true;
    }

    private async void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
		bool result = await DisplayAlert("Logout", "Are you sure you want to logout?", "Yes", "No");
		if (result)
		{
			await Navigation.PopAsync();
		}
    }
}