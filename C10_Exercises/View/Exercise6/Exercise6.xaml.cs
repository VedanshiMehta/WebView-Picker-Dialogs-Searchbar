using C10_Exercises.ViewModel;

namespace C10_Exercises.View.Exercise6;

public partial class Exercise6 : ContentPage
{
	private GetEmployeeViewModel _viewModel;
	public Exercise6()
	{
		InitializeComponent();
		_viewModel=(GetEmployeeViewModel)BindingContext;	
	}

	private async void SearchBarEmployees_TextChanged(object sender, TextChangedEventArgs e)
	{
		if (string.IsNullOrEmpty(e.NewTextValue) || string.IsNullOrEmpty(e.OldTextValue))
		{
			await _viewModel.GetEmployeeListAsync();
		}

	}
}