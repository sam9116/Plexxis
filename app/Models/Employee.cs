using System;
using System.Collections.Generic;
using System.Text;

namespace app.Models
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
