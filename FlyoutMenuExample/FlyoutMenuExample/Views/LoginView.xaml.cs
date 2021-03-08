using FlyoutMenuExample.ViewModels;
using Xamarin.Forms;

namespace FlyoutMenuExample.Views
{
    public partial class LoginView : ContentPage
    {
        public LoginView()
        {
            InitializeComponent();
            BindingContext = new LoginViewViewModel(Navigation);
        }
    }
}
