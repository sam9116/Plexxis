﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.IO;
using System.Net;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using Newtonsoft.Json.Linq;
using app.Models;
using app.ViewModel;
using Rg.Plugins.Popup.Services;
using Plugin.Connectivity;
using System.Diagnostics;
using app.Services;
using System.Net.Http;

namespace app
{
    public partial class MainPage : ContentPage
    {
        public MainPageViewModel mainPageViewModel;
        Random r = new Random();
        public ToolbarItem Add = new ToolbarItem()
        {
            Text = "Add ➕"
        };
       
        public MainPage()
        {
            InitializeComponent();
            BindingContext = mainPageViewModel = new MainPageViewModel();
            Add.Clicked += Add_Clicked;
            EmployeeView.ItemTapped += EmployeeView_ItemTapped;
        }

        private async void EmployeeView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if(PopupNavigation.Instance.PopupStack.Count<1)
            {
                await PopupNavigation.Instance.PushAsync(new PopUpContainer((Employee)e.Item));
            }
            
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            if(mainPageViewModel.Online)
            {
                ToolbarItems.Add(Add);
            }
            mainPageViewModel.fetchEmployeeData_Offline();
            mainPageViewModel.fetchEmployeeData();
        }

        private async void EmployeeView_Refreshing(object sender, EventArgs e)
        {
            mainPageViewModel.fetchEmployeeData_Offline();
            mainPageViewModel.fetchEmployeeData();
        }

        private async void Add_Clicked(object sender, EventArgs e)
        {
            var result = await HttpUtils.service.InvokeApiAsync("employee/GetNextId", HttpMethod.Get, new Dictionary<string, string>());
            int IdFromServer = int.Parse(result.ToString());
            await PopupNavigation.Instance.PushAsync(new PopUpContainer(new Employee() { Id = IdFromServer, Name ="",Assigned = false,Branch="",City="",Code="",Color= "", Profession="" }));
        }

        private void Delete_Clicked(object sender, EventArgs e)
        {

        }
    }
}
