using Converter.Views;
using System.Windows.Input;

namespace Converter.ViewModels
{
    public class MenuViewModel
    {
        #region Commands
        public ICommand NavigateToConverterCommand => new Command<string>(NavigateToConverter); 
        #endregion

        #region Functions
        private void NavigateToConverter(string quantityname)
        {
            App.Current.MainPage.Navigation.PushAsync(new ConverterView(quantityname));
        }
        #endregion
    }
}
