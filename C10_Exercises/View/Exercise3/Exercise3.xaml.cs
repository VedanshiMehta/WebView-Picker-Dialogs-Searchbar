using C10_Exercises.ViewModel;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;

namespace C10_Exercises.View.Exercise3;

public partial class Exercise3 : ContentPage
{
	private ChatDataViewModel _chatDataViewModel;
	public Exercise3()
	{
		InitializeComponent();
		NavigationPage.SetHasNavigationBar(this, false );
		_chatDataViewModel = (ChatDataViewModel)BindingContext;
        _chatDataViewModel.ResultEventHandler += ChatDataViewModel_ResultEventHandler;
	}
    protected override void OnAppearing()
    {
        base.OnAppearing();
        _chatDataViewModel.GetChatDetailsList();
    }

    private void ChatDataViewModel_ResultEventHandler(object sender, string e)
    {
        Toast.Make(e,ToastDuration.Short).Show();
    }
}