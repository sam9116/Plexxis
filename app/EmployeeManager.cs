﻿using app.Models;
using Microsoft.WindowsAzure.MobileServices.SQLiteStore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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
                await Store.UpsertAsync("Employee", employees.Select(x => JObject.FromObject(x)), true);
            }
            catch(Exception ex)
            {
                await Store.InitializeAsync();
                await Store.UpsertAsync("Employee", employees.Select(x => JObject.FromObject(x)), true);
            }
            
        }
        public async Task<ObservableCollection<Employee>> GetEmployeesAsync()
        {
            await Store.InitializeAsync();
            var result = await Store.ExecuteQueryAsync("Employee", "Select * From Employee", new Dictionary<string, object>());
            ObservableCollection<Employee> Locallist = new ObservableCollection<Employee>();
            var converted_result = result.Select(x => JsonConvert.DeserializeObject<Employee>(x.ToString()));
            foreach(Employee employee in converted_result)
            {
                Locallist.Add(employee);
            }
            return Locallist;

        }
        public async Task SaveEmployeeAsync(Employee employee)
        {
            try
            {
                await Store.UpsertAsync("Employee", new List<JObject>() { JObject.FromObject(employee) }, true);
            }
            catch (Exception ex)
            {
                await Store.InitializeAsync();
                await Store.UpsertAsync("Employee", new List<JObject>() { JObject.FromObject(employee) }, true);
            }
            
        }
        public async Task DeleteEmployeeAsync(String Id)
        {
            Dictionary<string, object> Ids = new Dictionary<string, object>();
            Ids.Add("@Id", Id);

            try
            {
                await Store.ExecuteQueryAsync("Employee", "Delete From Employee Where Id = @Id", Ids);
            }
            catch (Exception ex)
            {
                await Store.InitializeAsync();
                await Store.ExecuteQueryAsync("Employee", "Delete From Employee Where Id = @Id", Ids);
            }

        }


    }
}
