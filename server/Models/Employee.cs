using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server.Models
{
    public class Employee
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Profession { get; set; }
        public string Color { get; set; }
        public string City { get; set; }
        public string Branch { get; set; }
        public bool Assigned { get; set; }
    }
}
