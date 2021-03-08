using FlyoutMenuExample.Messages.Security;
using FlyoutMenuExample.Services.Interfaces;
using System.Windows.Input;
using Xamarin.Forms;

namespace FlyoutMenuExample.ViewModels
{
    public class LoginViewViewModel : BaseViewModel
    {
        private ISecurityService _securityService;

        public ICommand LoginCommand { get; set; }

        public LoginViewViewModel(INavigation navigation) : base(navigation)
        {
            _securityService = DependencyService.Get<ISecurityService>();

            LoginCommand = new Command(ExecuteLoginCommand);
        }

        void ExecuteLoginCommand()
        {
            // DO YOUR OWN LOGIN LOGIC AND VALIDATION
            var loginResult = _securityService.LogIn("Test User", "Password");

            // I may have gotten a user profile somewhere..  Use whatever your app does
            //var userProfile = new UserProfile();

            if (loginResult)
            {
                MessagingCenter.Send<LoginMessage>(new LoginMessage(), "Login");
            }
        }

    }
}
