using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EmployeeManagementSystem.Models;
using Utilities;

namespace EmployeeManagementSystem.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly DbContext _DbContext = new DbContext();

        public EmployeeService()
        {
            _DbContext = new DbContext();
        }
        public List<Employee> GetList()
        {
            List<Employee> employees = new List<Employee>();
            try
            {
                employees = _DbContext.GetEmployee();

            }
            catch (Exception ex)
            {
                LogUtils.LogError(ex);
            }
            return employees;
        }

        public Employee GetById(Employee employee)
        {
            throw new NotImplementedException();
        }


        public void Insert(Employee employee)
        {
            try
            {
                _DbContext.Insert(employee);
            }
            catch (Exception ex)
            {
                LogUtils.LogError(ex);
            }
        }

        public void Update(Employee employee)
        {
            try
            {
                _DbContext.Update(employee);
            }
            catch (Exception ex)
            {
                LogUtils.LogError(ex);
            }
        }
    }
}
