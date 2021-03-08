using FlyoutMenuExample.Enums.Security;
using FlyoutMenuExample.Messages.Security;
using FlyoutMenuExample.Models.Security;
using FlyoutMenuExample.Services;
using FlyoutMenuExample.Services.Interfaces;
using FlyoutMenuExample.Views;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace FlyoutMenuExample.Services
{
    public class FakeSecurityService : ISecurityService
    {
        public IList<Models.Security.MenuItem> _allMenuItems;

        public bool LoggedIn { get; set; }

        public FakeSecurityService()
        {
            CreateMenuItems();
        }

        public IList<Models.Security.MenuItem> GetAllowedAccessItems()
        {
            if (LoggedIn)
            {
                var accessItems = new List<Models.Security.MenuItem>();

                foreach (var item in _allMenuItems)
                {
                    if (item.MenuType == MenuTypeEnum.Secured || item.MenuType == MenuTypeEnum.UnSecured || item.MenuType == MenuTypeEnum.LogOut)
                    {
                        accessItems.Add(item);
                    }
                }

                return accessItems.OrderBy(x => x.MenuOrder).ToList();
            }
            else
            {
                var accessItems = new List<Models.Security.MenuItem>();

                foreach (var item in _allMenuItems)
                {
                    if (item.MenuType == MenuTypeEnum.UnSecured || item.MenuType == MenuTypeEnum.Login)
                    {
                        accessItems.Add(item);
                    }
                }

                return accessItems.OrderBy(x => x.MenuOrder).ToList();
            }
        }

        public bool LogIn(string userName, string password)
        {
            // Do Your Stuff to Check if Legit (ie API Calls)

            LoggedIn = true;

            return true;
        }

        public void LogOut()
        {
            LoggedIn = false;
            MessagingCenter.Send<LogOutMessage>(new LogOutMessage(), "Logout");
        }



        private void CreateMenuItems()
        {
            _allMenuItems = new List<Models.Security.MenuItem>();

            var menuItem = new Models.Security.MenuItem();
            menuItem.MenuItemId = 1;
            menuItem.MenuItemName = "Login";
            menuItem.TargetType = typeof(LoginView);
            menuItem.MenuType = MenuTypeEnum.Login;
            menuItem.MenuOrder = 1;
            menuItem.ImageName = "login.png";

            _allMenuItems.Add(menuItem);

            menuItem = new Models.Security.MenuItem();
            menuItem.MenuItemId = 2;
            menuItem.MenuItemName = "Logout";
            menuItem.NavigationPath = "";
            menuItem.MenuOrder = 99;
            menuItem.MenuType = MenuTypeEnum.LogOut;
            menuItem.ImageName = "logout.png";

            _allMenuItems.Add(menuItem);

            menuItem = new Models.Security.MenuItem();
            menuItem.MenuItemId = 3;
            menuItem.MenuItemName = "Secured Content Demo";
            menuItem.TargetType = typeof(SecuredContentDemo);
            menuItem.MenuOrder = 3;
            menuItem.MenuType = MenuTypeEnum.Secured;
            menuItem.ImageName = "map.png";

            _allMenuItems.Add(menuItem);

            menuItem = new Models.Security.MenuItem();
            menuItem.MenuItemId = 4;
            menuItem.MenuItemName = "Home";
            menuItem.TargetType = typeof(MainView);
            menuItem.MenuOrder = 4;
            menuItem.MenuType = MenuTypeEnum.UnSecured;
            menuItem.ImageName = "other.png";

            _allMenuItems.Add(menuItem);
        }
    }
}
