using FlyoutMenuExample.Services.Interfaces;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace FlyoutMenuExample.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        public MainPageViewModel(INavigation navigation) : base(navigation)
        {
        }
    }
}
