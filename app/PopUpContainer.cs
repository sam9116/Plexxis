using app.Models;
using Rg.Plugins.Popup.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace app.ViewModel
{
	public class PopUpContainer : PopupPage
    {
        Employee oldcopy { get; set; }
        
		public PopUpContainer(Employee input)
		{
           
            Content = new EmployeeDetailView(input);
		}
        protected override async void OnDisappearing()
        {
            base.OnDisappearing();
            EmployeeDetailView dyingview = (EmployeeDetailView)Content;
            bool success = await EmployeeManager.DefaultManager.SaveEmployeeAsync(dyingview.employeeDetailPageViewModel.employee);
            NavigationPage np = (NavigationPage)App.Current.MainPage;
            MainPage mp = (MainPage)np.CurrentPage;

            await mp.mainPageViewModel.fetchEmployeeData_Offline();


        }
    }
}