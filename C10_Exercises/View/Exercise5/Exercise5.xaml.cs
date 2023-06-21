namespace C10_Exercises.View.Exercise5;

public partial class Exercise5 : ContentPage
{
	public Exercise5()
	{
		InitializeComponent();
        webView.Navigating += WebView_Navigating;
        webView.Navigated += WebView_Navigated;
        
	}

    private void WebView_Navigated(object sender, WebNavigatedEventArgs e)
    {
        indicator.IsRunning = false;
    }

    private void WebView_Navigating(object sender, WebNavigatingEventArgs e)
    {
        indicator.IsRunning = true;
    }

    private void GoBackTapped_Tapped(object sender, TappedEventArgs e)
    {
        if(webView.CanGoBack)
        {
            webView.GoBack();
        }
    }

    private void GoNextTapped_Tapped(object sender, TappedEventArgs e)
    {
        if(webView.CanGoForward)
        {
            webView.GoForward();
        }
    }

    private async void ButtonLaunch_Clicked(object sender, EventArgs e)
    {
        await Launcher.OpenAsync("https://www.1rivet.com/contact-us");
    }
}