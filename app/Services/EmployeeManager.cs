using app.Models;
using app.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.WindowsAzure.MobileServices.SQLiteStore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace app
{
    public partial class EmployeeManager
    {
        static EmployeeManager employeeManager = new EmployeeManager();
        static MobileServiceSQLiteStore Store;
        private EmployeeManager()
        {
            Store = new MobileServiceSQLiteStore(Constants.dbname);
            Store.DefineTable<Employee>();
            
        }

        public static EmployeeManager DefaultManager
        {
            get
            {
                return employeeManager;
            }
            private set
            {
                employeeManager = value;
            }
        }
        public async Task AddMultipleEmployees(IEnumerable<Employee> employees)
        {
            try
            {
                await Store.InitializeAsync();                
            }
            catch(Exception ex)
            {
              
            }
            await Store.UpsertAsync("Employee", employees.Select(x => JObject.FromObject(x)), true);

        }
        public async Task<ObservableCollection<Employee>> GetEmployeesAsync()
        {
            try
            {
                await Store.InitializeAsync();
            }
            catch
            {

            }
            var result = await Store.ExecuteQueryAsync("Employee", "Select * From Employee", new Dictionary<string, object>());
            ObservableCollection<Employee> Locallist = new ObservableCollection<Employee>();
            var converted_result = result.Select(x => JsonConvert.DeserializeObject<Employee>(x.ToString()));
            foreach(Employee employee in converted_result)
            {
                Locallist.Add(employee);
            }
            return Locallist;

        }
        public async Task<bool> SaveEmployeeAsync(Employee employee)
        {
            Dictionary<string, string> payload = new Dictionary<string, string>
            {
                { "targetEmployeeinput", JObject.FromObject(employee).ToString() }
            };
            try
            {
                var result = await HttpUtils.service.InvokeApiAsync("employee/UpsertEmployee", HttpMethod.Get, payload);
                
            }
            catch (Exception ex)
            {
                return false;
            }

            try
            {
                await Store.InitializeAsync();
            }
            catch (Exception ex)
            {

            }
            await Store.UpsertAsync("Employee", new List<JObject>() { JObject.FromObject(employee) }, true);
            return true;

            
        }
        public async Task<bool> DeleteEmployeeAsync(String Id)
        {
            Dictionary<string, string> payload = new Dictionary<string, string>
            {
                { "employeeId", Id }
            };
            try
            {
                var result = await HttpUtils.service.InvokeApiAsync("employee/DeleteEmployee", HttpMethod.Get, payload);

            }
            catch (Exception ex)
            {
                return false;
            }




            Dictionary<string, object> Ids = new Dictionary<string, object>
            {
                { "@Id", Id }
            };

            try
            {
                await Store.InitializeAsync();              
            }
            catch (Exception ex)
            {

            }
            await Store.ExecuteQueryAsync("Employee", "Delete From Employee Where Id = @Id", Ids);

            return true;
        }


    }
}
