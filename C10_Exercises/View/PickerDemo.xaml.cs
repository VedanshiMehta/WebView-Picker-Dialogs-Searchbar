namespace C10_Exercises.View;

public partial class PickerDemo : ContentPage
{
	public PickerDemo()
	{
		InitializeComponent();
	}

    private void Picker_SelectedIndexChanged(object sender, EventArgs e)
    {
        var picker = (Picker)sender;
        int selectedIndex = picker.SelectedIndex;
        if (selectedIndex != -1)
        {
            var name = picker.Items[selectedIndex];
        }
    }

}