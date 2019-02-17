using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace server.Models
{
    public class EmployeesList
    {
        public ObservableCollection<Employee> employees { get; set; }

        public int count { get; set; }        
    }
}
