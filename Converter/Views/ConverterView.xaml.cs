using Converter.ViewModels;

namespace Converter.Views;

public partial class ConverterView : ContentPage
{
	public ConverterView(string quantityName)
	{
		InitializeComponent();
		BindingContext = new ConverterViewModel(quantityName);
	}

    private void Picker_SelectedIndexChanged(object sender, EventArgs e)
    {
		var viewModel = (ConverterViewModel)BindingContext;

		if (viewModel != null)
		{
            viewModel.Convert();
		}
    }
}