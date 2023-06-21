using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;

namespace C10_Exercises.View.Exercise2;

public partial class Exercise2 : ContentPage
{
	public Exercise2()
	{
		InitializeComponent();
	}

    private async void ImageTap_Tapped(object sender, TappedEventArgs e)
    {
		var selectedName = await DisplayActionSheet("Change Profile", "Cancel", "Delete" , null, "Camera", "Gallery", "Avatar");
		await Toast.Make(selectedName,ToastDuration.Short).Show();
    }
}