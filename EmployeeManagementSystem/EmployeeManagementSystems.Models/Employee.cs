using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagementSystem.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string EmployeeName { get; set; }
        public string SurName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime StarDateOfWork { get; set; }
        public decimal Salary { get; set; }
        public int DepartmetId { get; set; }
        public int TitleId { get; set; }
        public string Manager { get; set; }
    }
}
