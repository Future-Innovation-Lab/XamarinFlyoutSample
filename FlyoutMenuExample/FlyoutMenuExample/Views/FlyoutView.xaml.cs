using FlyoutMenuExample.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FlyoutMenuExample.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FlyoutView : FlyoutPage
    {
        public FlyoutView()
        {
            InitializeComponent();

            BindingContext = new FlyoutPageViewModel(Navigation);
        }
    }
}