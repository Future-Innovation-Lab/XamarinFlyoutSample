using FlyoutMenuExample.Services;
using FlyoutMenuExample.Services.Interfaces;
using FlyoutMenuExample.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FlyoutMenuExample
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            var service = new FakeSecurityService();
            DependencyService.RegisterSingleton<ISecurityService>(service);

            MainPage = new FlyoutView();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
