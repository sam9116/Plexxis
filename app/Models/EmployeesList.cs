using System.Collections.ObjectModel;
using System.ComponentModel;

namespace app.Models
{
    public class EmployeesList
    {
        public ObservableCollection<Employee> employees { get; set; }

        public int count { get; set; }

        public EmployeesList()
        {
            employees = new ObservableCollection<Employee>();
            count = new int();
        }
    }
}
