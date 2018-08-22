using BarcodeReader.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BarcodeReader.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class BarcodeReaderView : ContentPage
	{
		public BarcodeReaderView ()
		{
            BindingContext = new BarcodeReaderViewModel(Navigation);

			InitializeComponent ();
		}
    }
}