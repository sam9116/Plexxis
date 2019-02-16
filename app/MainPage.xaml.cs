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

namespace app
{
    public partial class MainPage : ContentPage
    {
        public MainPageViewModel mainPageViewModel;
      
        public MainPage()
        {
            InitializeComponent();
            BindingContext = mainPageViewModel = new MainPageViewModel();

            
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await mainPageViewModel.fetchEmployeeData_Offline();
            mainPageViewModel.fetchEmployeeData();
        }

        private async void EmployeeView_Refreshing(object sender, EventArgs e)
        {
            await mainPageViewModel.fetchEmployeeData();
        }

        private void Add_Clicked(object sender, EventArgs e)
        {

        }
    }
}
