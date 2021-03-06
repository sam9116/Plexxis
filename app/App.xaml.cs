﻿using app.Models;
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
       
        

    public App()
        {
            InitializeComponent();      

            
            MainPage = new NavigationPage(new MainPage());
        }

        protected override async void OnStart()
        {
            // Handle when your app starts
          
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
