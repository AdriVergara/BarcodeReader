using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace BarcodeReader.ViewModels
{
    public class BarcodeReaderViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private INavigation NavigationService;

        private string _barcodeReaded { get; set; }
        public string BarcodeReaded
        {
            get
            {
                return _barcodeReaded;
            }
            set
            {
                _barcodeReaded = value;
                OnPropertyChanged("BarcodeReaded");

                //ExecuteLabelChanged();
            }
        }

        public ICommand ScanBarcode { get; set; }

        public BarcodeReaderViewModel(INavigation _navigationService)
        {
            NavigationService = _navigationService;
            _barcodeReaded = "";

            ScanBarcode = new Command(async () => await ExecuteScanBarcode());
        }

        //private async Task ExecuteLabelChanged()
        //{
        //    var notificator = DependencyService.Get<IToastNotificator>();

        //    var options = new NotificationOptions()
        //    {
        //        AllowTapInNotificationCenter = false,
        //        Title = "The value Scanned is: " + BarcodeReaded,
        //        //Description = "Go go go!",
        //        IsClickable = false,
        //    };

        //    var result = await notificator.Notify(options);
        //}

        private async Task ExecuteScanBarcode()
        {
            #if __ANDROID__
	            // Initialize the scanner first so it can track the current context
	            MobileBarcodeScanner.Initialize (Application);
            #endif

            var scanner = new ZXing.Mobile.MobileBarcodeScanner();

            var result = await scanner.Scan();

            if (result != null)
                //Console.WriteLine("Scanned Barcode: " + result.Text);
                BarcodeReaded = result.Text;
        }
    }
}
