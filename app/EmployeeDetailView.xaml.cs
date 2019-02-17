using app.Models;
using app.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace app
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class EmployeeDetailView : ContentView
	{
        public EmployeeDetailPageViewModel employeeDetailPageViewModel;
        public EmployeeDetailView (Employee Input, bool disableedit)
		{
			InitializeComponent ();
            BindingContext = employeeDetailPageViewModel = new EmployeeDetailPageViewModel(Input,disableedit);
        }
	}
}