using FlyoutMenuExample.Services.Interfaces;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using System.Windows.Input;
using System;
using FlyoutMenuExample.Enums.Security;
using FlyoutMenuExample.Messages.Security;
using FlyoutMenuExample.Views;

namespace FlyoutMenuExample.ViewModels
{
    public class FlyoutPageViewModel : BaseViewModel
    {
        private ISecurityService _securityService;

        public ICommand NavigateCommand { get; private set; }

        private ObservableCollection<Models.Security.MenuItem> _menuItems;
        public ObservableCollection<Models.Security.MenuItem> MenuItems
        {
            get { return _menuItems; }
            set {
                _menuItems = value; 
                OnPropertyChanged(); }
        }

        public FlyoutPageViewModel(INavigation navigation) : base(navigation)
        {
            _securityService = DependencyService.Get<ISecurityService>();

            NavigateCommand = new Command<Models.Security.MenuItem>(ExecuteNavigateCommand);

            var items = _securityService.GetAllowedAccessItems();
            MenuItems = new ObservableCollection<Models.Security.MenuItem>(items);
            
            MessagingCenter.Subscribe<LoginMessage>(this, "Login", LoginEvent);
            MessagingCenter.Subscribe<LogOutMessage>(this, "Logout", LogOutEvent);
        }

        private void LoginEvent(LoginMessage message)
        {
            MenuItems = new ObservableCollection<Models.Security.MenuItem>(_securityService.GetAllowedAccessItems());

            var mainPage = App.Current.MainPage as FlyoutPage;
            if (mainPage != null)
            {
                mainPage.Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(SecuredContentDemo)));
                mainPage.IsPresented = false;
            }
        }

        public void LogOutEvent(LogOutMessage message)
        {
            MenuItems = new ObservableCollection<Models.Security.MenuItem>(_securityService.GetAllowedAccessItems());

            var mainPage = App.Current.MainPage as FlyoutPage;
            if (mainPage != null)
            {
                mainPage.Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(LoginView)));
                mainPage.IsPresented = false;
            }
        }

        private void ExecuteNavigateCommand(Models.Security.MenuItem menuItem)
        {
            if (menuItem.MenuType == MenuTypeEnum.LogOut)
                _securityService.LogOut();
            else
            {
                var mainPage = App.Current.MainPage as FlyoutPage;
                if (mainPage != null)
                {
                    mainPage.Detail = new NavigationPage((Page)Activator.CreateInstance(menuItem.TargetType));
                    mainPage.IsPresented = false;
                }
            }
        }
    }
}
