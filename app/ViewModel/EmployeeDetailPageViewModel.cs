using app.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace app.ViewModel
{
    public class EmployeeDetailPageViewModel:ViewModelBase
    {
        Employee employee { get; set; }

        public EmployeeDetailPageViewModel(Employee input)
        {
            employee = input;
        }

    }
}
