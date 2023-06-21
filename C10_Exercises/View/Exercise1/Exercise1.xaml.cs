using C10_Exercises.ViewModel;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;

namespace C10_Exercises.View.Exercise1;

public partial class Exercise1 : ContentPage
{
	private LoginViewModel _loginViewModel;
	public Exercise1()
	{
		InitializeComponent();
		NavigationPage.SetHasNavigationBar(this, false);
		_loginViewModel = (LoginViewModel)BindingContext;
        _loginViewModel.ResultEvent += LoginViewModel_ResultEvent;
	}
    protected override void OnAppearing()
    {
        base.OnAppearing();
		entryPassword.Text = string.Empty;
		entryUsername.Text = string.Empty;

    }
    private async void LoginViewModel_ResultEvent(object sender, Result e)
    {
        if(e.IsSuccess)
		{
			if (e.LoginResponse != null)
			{
				await Navigation.PushAsync(new Dashboard(e.LoginResponse));
			}
		}
		else if(!e.IsSuccess)
		{
			await Toast.Make(e.Message,ToastDuration.Short).Show();
		}
    }
}