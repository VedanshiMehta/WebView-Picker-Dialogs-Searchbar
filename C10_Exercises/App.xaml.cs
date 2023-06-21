using C10_Exercises.View;
using C10_Exercises.View.Exercise1;
using C10_Exercises.View.Exercise2;
using C10_Exercises.View.Exercise3;
using C10_Exercises.View.Exercise4;
using C10_Exercises.View.Exercise5;
using C10_Exercises.View.Exercise6;
using C10_Exercises.View.Exercise7;

namespace C10_Exercises;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new NavigationPage(new Exercise4())
		{
			BarBackgroundColor = Colors.CadetBlue,
			BarTextColor = Colors.White,
		};
	}
}
