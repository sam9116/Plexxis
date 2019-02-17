using app.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace app.ViewModel
{
    public class EmployeeDetailPageViewModel:ViewModelBase
    {
        public Employee employee { get; set; }

        public bool disableedit { get; set; }
        public EmployeeDetailPageViewModel(Employee input,bool disableeditinput)
        {
            disableedit = disableeditinput;
            employee = input;
        }

    }
}
