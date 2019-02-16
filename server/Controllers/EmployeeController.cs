using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;

namespace server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : Controller
    {
        [HttpGet]
        public ContentResult Get()
        {
            string path = Directory.GetCurrentDirectory() + "/data/employees.json";

            using (StreamReader sr = new StreamReader(path))
            {
                var json = sr.ReadToEnd();

                return new ContentResult { Content = json, ContentType = "application/json" };

            }
        }
    }
}