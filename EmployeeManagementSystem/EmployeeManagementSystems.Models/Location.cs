using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagementSystem.Models
{
    public class Location
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }
        public string PostCode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
}
