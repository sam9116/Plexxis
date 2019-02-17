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
		public PopUpContainer(Employee input)
		{            
            Content = new EmployeeDetailView(input);
		}
	}
}