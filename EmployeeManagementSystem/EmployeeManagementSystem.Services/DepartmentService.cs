using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EmployeeManagementSystem.Models;
using Utilities;

namespace EmployeeManagementSystem.Services
{
    public class DepartmentService :  IDepartmentService
    {
        private readonly DbContext _DbContext=new DbContext();

        public DepartmentService()
        {
            _DbContext = new DbContext();
        }
        public Department GetById(Department department)
        {
            throw new NotImplementedException();
        }

        public List<Department> GetList()
        {
            List<Department> departments = new List<Department>();
            try
            {
                departments=_DbContext.GetDepartments();
            }
            catch (Exception ex)
            {
                LogUtils.LogError(ex);
            }
            return departments;
        }

        public void Insert(Department department)
        {
            try
            {
                _DbContext.Insert(department);
            }
            catch (Exception ex)
            {

                LogUtils.LogError(ex);
            }
           
        }
        public List<EmployeesofManagers> GetEmployeesofManagers()
        {
            var result = _DbContext.GetEmployeesofManagers();
            return result;
        }  
        public List<AverageSalaryofDepartments> AverageSalaryofDepartments()
        {
            var result = _DbContext.AverageSalaryofDepartments();
            return result;
        }
        public Department Update(Department department)
        {
            throw new NotImplementedException();
        }
    }
}
