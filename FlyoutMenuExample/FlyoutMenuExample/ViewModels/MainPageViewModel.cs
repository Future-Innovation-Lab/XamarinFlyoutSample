using FlyoutMenuExample.Services.Interfaces;
using FlyoutMenuExample.Views;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace FlyoutMenuExample.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        public ICommand Page1Command { get; set; }
        public ICommand Page2Command { get; set; }
        public ICommand Page3Command { get; set; }

        public MainPageViewModel(INavigation navigation) : base(navigation)
        {

            Page1Command = new Command(Page1);
            Page2Command = new Command(Page2);
            Page3Command = new Command(Page3);
        }

        private void Page1(object obj)
        {
            Navigation.PushAsync(new LoginView());
        }

        private void Page2(object obj)
        {
            Navigation.PushAsync(new Page2View());
        }

        private void Page3(object obj)
        {
            Navigation.PushAsync(new SecuredContentDemo());
        }
    }
}
