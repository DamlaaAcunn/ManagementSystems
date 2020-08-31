
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace EmployeeManagementSystem.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string DepartmentName { get; set; }
        public string Manager { get; set; }
        public int LocationId { get; set; }
    }
    public class EmployeesofManagers
    {
        public string Manager { get; set; }
        public string DepartmentName { get; set; }
        public string EmployeeName { get; set; }
    } 
    public class AverageSalaryofDepartments
    {
        public Department  Department { get; set; }
        public decimal AverageSalary { get; set; }
    }
}
