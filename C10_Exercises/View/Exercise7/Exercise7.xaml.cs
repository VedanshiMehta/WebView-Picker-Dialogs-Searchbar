using C10_Exercises.ViewModel;
using System.Xml.Linq;

namespace C10_Exercises.View.Exercise7;

public partial class Exercise7 : ContentPage
{
    private GetProductViewModel _viewModel;
    private string _name;

    public Exercise7()
    {
        InitializeComponent();
        _viewModel = (GetProductViewModel)BindingContext;
        
    }

    private void PickerCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        var picker = (Picker)sender;
        int selectedIndex = picker.SelectedIndex;
        if (selectedIndex != -1)
        {
            _name = picker.Items[selectedIndex];
            _viewModel.Product = _name;
        }

        GetSelectedProductListAsync();
    }

    private async void GetSelectedProductListAsync()
    {
        await _viewModel.GetProductListAsync();
    }
}