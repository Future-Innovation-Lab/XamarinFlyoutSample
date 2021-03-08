using FlyoutMenuExample.Models.Security;
using System;
using System.Collections.Generic;
using System.Text;

namespace FlyoutMenuExample.Services.Interfaces
{
    public interface ISecurityService
    {
        IList<MenuItem> GetAllowedAccessItems();
        bool LogIn(string userName, string password);
        void LogOut();
    }
}
