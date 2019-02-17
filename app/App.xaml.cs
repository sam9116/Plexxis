using app.Models;
using Microsoft.WindowsAzure.MobileServices.SQLiteStore;
using Plugin.Connectivity;
using System;
using System.Diagnostics;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace app
{
    public partial class App : Application
    {
        public bool DoIHaveInternet()
        {
            if (!CrossConnectivity.IsSupported)
                return true;

            //Do this only if you need to and aren't listening to any other events as they will not fire.
            var connectivity = CrossConnectivity.Current;

            try
            {
                return connectivity.IsConnected;
            }
            finally
            {
                CrossConnectivity.Dispose();
            }
        }
        

    public App()
        {
            InitializeComponent();      

            
            MainPage = new NavigationPage(new MainPage());
        }

        protected override async void OnStart()
        {
            // Handle when your app starts
            CrossConnectivity.Current.ConnectivityChanged += async (sender, args) =>
            {
                Debug.WriteLine($"Connectivity changed to {args.IsConnected}");
            };
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
