using Converter.ViewModels;

namespace Converter.Views;

public partial class MenuView : ContentPage
{
	public MenuView()
	{
		InitializeComponent();

		BindingContext = new MenuViewModel();
	}
}