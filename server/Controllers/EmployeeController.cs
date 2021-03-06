﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;
using Microsoft.WindowsAzure.MobileServices.SQLiteStore;
using server.Models;
using Newtonsoft.Json.Linq;

namespace server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : Controller
    {
        [HttpGet]
        public async Task<JsonResult> Get()
        {
            //if we need to store data server side we will need a database, i'm lazy so i will use the same sqlite db i used in the app here as well
            MobileServiceSQLiteStore Store = new MobileServiceSQLiteStore("local.db");
            Store.DefineTable<Employee>();
            await Store.InitializeAsync();
            var result = await Store.ExecuteQueryAsync("Employee", "Select * From Employee", new Dictionary<string, object>());
            var converted_result = result.Select(x => JsonConvert.DeserializeObject<Employee>(x.ToString()));
            if(converted_result.Count()<1)
            {
                string path = Directory.GetCurrentDirectory() + "/data/employees.json";
                using (StreamReader sr = new StreamReader(path))
                {
                    var json = sr.ReadToEnd();
                    EmployeesList employees = JsonConvert.DeserializeObject<EmployeesList>(json);
                    await Store.UpsertAsync("Employee", employees.employees.Select(x => JObject.FromObject(x)), true);

                    result = await Store.ExecuteQueryAsync("Employee", "Select * From Employee", new Dictionary<string, object>());
                    converted_result = result.Select(x => JsonConvert.DeserializeObject<Employee>(x.ToString()));
                    return new JsonResult(result);
                }
            }
            else
            {
                return new JsonResult(result);
            }         

        }

        [Route("GetNextId")]
        [HttpGet]
        public async Task<JsonResult> GetNextId()
        {
            MobileServiceSQLiteStore Store = new MobileServiceSQLiteStore("local.db");
            Store.DefineTable<Employee>();
            await Store.InitializeAsync();
            var result = await Store.ExecuteQueryAsync("Employee", "SELECT MAX(Id) FROM Employee", new Dictionary<string, object>());
            int Id = int.Parse(result[0]["MAX(Id)"].ToString());
            Id++;
            return new JsonResult(Id);
        }
        [Route("UpsertEmployee")]
        [HttpGet]
        public async Task<JsonResult> UpsertEmployee(string targetEmployeeinput)
        {
            //setup the database
            var targetEmployee = JsonConvert.DeserializeObject<Employee>(targetEmployeeinput);
            MobileServiceSQLiteStore Store = new MobileServiceSQLiteStore("local.db");
            Store.DefineTable<Employee>();
            await Store.InitializeAsync();
            await Store.UpsertAsync("Employee", new List<JObject>() { JObject.FromObject(targetEmployee) }, true);
            return new JsonResult("200");
        }
        [Route("DeleteEmployee")]
        [HttpGet]
        public async Task<JsonResult> DeleteEmployee(int employeeId)
        {
            //setup the database
            MobileServiceSQLiteStore Store = new MobileServiceSQLiteStore("local.db");
            Store.DefineTable<Employee>();
            await Store.InitializeAsync();
            await Store.ExecuteQueryAsync("Employee", "Delete From Employee where Id = @Id", new Dictionary<string, object>() { { "@Id", employeeId } });

            return new JsonResult("200");
        }
    }
}