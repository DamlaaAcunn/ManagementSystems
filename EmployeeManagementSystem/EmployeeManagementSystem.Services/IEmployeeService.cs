using EmployeeManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagementSystem.Services
{
    public interface IEmployeeService
    {
        void Insert(Employee employee);
        void Update(Employee employee);
        Employee GetById(Employee employee);
        List<Employee> GetList();
    }
}
