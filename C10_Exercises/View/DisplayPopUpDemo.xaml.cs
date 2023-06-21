namespace C10_Exercises;

public partial class MainPage : ContentPage
{
	

	public MainPage()
	{
		InitializeComponent();
	}


    private async void ButtonDisplayAlert_Clicked(object sender, EventArgs e)
    {
		bool result =  await DisplayAlert("Delete", "Are you sure you want to delete ? ", "Yes", "No");
    }

    private async void ButtonDisplayActionSheet_Clicked(object sender, EventArgs e)
    {
        string action = await DisplayActionSheet("Send to?", "Cancel", null,"Email", "Twitter", "Facebook");
    }

    private async void ButtonDisplayPrompt_Clicked(object sender, EventArgs e)
    {
        string result = await DisplayPromptAsync("Question 1", "What's your name",placeholder:"Enter name");

    }
}

