using EmployeeManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagementSystem.Services
{
   public interface IDepartmentService
    {
        void Insert(Department department);
        Department Update(Department department);
        Department GetById(Department department);
        List<Department> GetList();
        List<EmployeesofManagers> GetEmployeesofManagers();
        List<AverageSalaryofDepartments> AverageSalaryofDepartments();
    }
}
