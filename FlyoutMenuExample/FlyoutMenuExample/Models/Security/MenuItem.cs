using FlyoutMenuExample.Enums.Security;
using System;
using System.Collections.Generic;
using System.Text;

namespace FlyoutMenuExample.Models.Security
{
    public class MenuItem
    {
        public int MenuItemId { get; set; }
        public int MenuOrder { get; set; }
        public string ImageName { get; set; }
        public string MenuItemName { get; set; }
        public string NavigationPath { get; set; }
        public Type TargetType { get; set; }
        public MenuTypeEnum MenuType { get; set; }
    }
}
