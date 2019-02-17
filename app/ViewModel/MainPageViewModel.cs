using app.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using app.Services;
using System.Net.Http;
using System.Collections.Generic;

namespace app.ViewModel
{
    public class MainPageViewModel : ViewModelBase
    {
        public string url = Constants.apiuri+"api/employee";
        public EmployeeManager employeeManager;

        public EmployeesList plexxisEmployees;

        public ObservableCollection<Employee> employees
        {
            get
            {
                return plexxisEmployees.employees;
            }
            set
            {
                plexxisEmployees.employees = value;
                OnPropertyChanged(nameof(employees));
            }
        }

        public MainPageViewModel()
        {
            employeeManager = EmployeeManager.DefaultManager;
            plexxisEmployees = new EmployeesList();
        }
        public async Task fetchEmployeeData_Offline()
        {
            IsBusy = true;
            employees = await employeeManager.GetEmployeesAsync();
            plexxisEmployees.count = plexxisEmployees.employees.Count;
            IsBusy = false;
        }
        public async Task fetchEmployeeData()
        {
            IsBusy = true;
            try
            {
                /*var request = WebRequest.Create(url);
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
                    employees = plexxisEmployees.employees;
                }*/
                var result = await HttpUtils.service.InvokeApiAsync("employee", HttpMethod.Get, new Dictionary<string, string>());
                plexxisEmployees = JsonConvert.DeserializeObject<EmployeesList>(result.ToString());
                var newemployeedata = plexxisEmployees.employees.Select(x => JObject.FromObject(x)).ToList();
                await employeeManager.AddMultipleEmployees(plexxisEmployees.employees);
                employees = plexxisEmployees.employees;
            }
            catch (Exception ex)
            {



            }
            IsBusy = false;
        }

    }
}
