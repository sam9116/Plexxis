using System;
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

namespace app
{
    public partial class MainPage : ContentPage
    {
        public MainPageViewModel mainPageViewModel;
        Random r = new Random();
        public MainPage()
        {
            InitializeComponent();
            BindingContext = mainPageViewModel = new MainPageViewModel();

            
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            mainPageViewModel.fetchEmployeeData_Offline();
            mainPageViewModel.fetchEmployeeData();
        }

        private async void EmployeeView_Refreshing(object sender, EventArgs e)
        {
            await mainPageViewModel.fetchEmployeeData();
        }

        private async void Add_Clicked(object sender, EventArgs e)
        {            
            await PopupNavigation.Instance.PushAsync(new PopUpContainer(new Employee() { Id = r.Next(),Name ="",Assigned = false,Branch="",City="",Code="",Color="",Profession="" }));
        }
    }
}
