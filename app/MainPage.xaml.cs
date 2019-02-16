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

namespace app
{

    public partial class MainPage : ContentPage
    {

        EmployeeManager employeeManager;
        string url = "http://10.0.2.2:8000/api/employee";
        EmployeesList plexxisEmployees;

        public class EmployeesList
        {
            public ObservableCollection<Employee> employees { get; set; }

            public int count { get; set; }
        }
        public MainPage()
        {
            InitializeComponent();
            employeeManager = EmployeeManager.DefaultManager;

            fetchEmployeeData(url);
        }

        public async void fetchEmployeeData(string url)
        {
            try
            {
                var request = WebRequest.Create(url);
                request.ContentType = "application/json; charset=utf-8";
                request.Method = "GET";

                string text;
                var response = (HttpWebResponse)request.GetResponse();

                using (var sr = new StreamReader(response.GetResponseStream()))
                {
                    text = sr.ReadToEnd();
                    System.Diagnostics.Debug.WriteLine(text);
                    plexxisEmployees = JsonConvert.DeserializeObject<EmployeesList>(text);
                    var newemployeedata = plexxisEmployees.employees.Select(x => JObject.FromObject(x)).ToList();
                    await employeeManager.AddMultipleEmployees(plexxisEmployees.employees);
                    EmployeeView.ItemsSource = plexxisEmployees.employees;
                }
            }
            catch(Exception ex)
            {
                plexxisEmployees = new EmployeesList();
                plexxisEmployees.employees = await employeeManager.GetEmployeesAsync();
                plexxisEmployees.count = plexxisEmployees.employees.Count;
                EmployeeView.ItemsSource = plexxisEmployees.employees;
            }
            
        }
    }
}
