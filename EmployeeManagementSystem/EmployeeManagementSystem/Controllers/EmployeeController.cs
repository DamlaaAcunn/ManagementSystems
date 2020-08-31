
using EmployeeManagementSystem.Helpers;
using EmployeeManagementSystem.Models;
using EmployeeManagementSystem.Services;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Results;
using Utilities;

namespace EmployeeManagementSystem.Controllers
{
    public class EmployeeController : ApiController
    {

        private readonly IEmployeeService _IEmployeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _IEmployeeService = employeeService;
        }


        [HttpPost]
        [JSONFilter(RootType = typeof(Department))]
        public void Insert([FromBody] Employee employee)
        {
            try
            {
                LogUtils.LogInfo(" Employee Insert start" + JsonConvert.SerializeObject(employee));
                _IEmployeeService.Insert(employee);
                LogUtils.LogInfo(" Employee Insert end");
            }
            catch (System.Exception ex)
            {
                LogUtils.LogError(ex);
            }

        }
        [HttpPost]
        [JSONFilter(RootType = typeof(Department))]
        public List<Employee> GetEmployees()
        {
            List<Employee> employees = new List<Employee>();
            try
            {
                LogUtils.LogInfo("GetEmployees start");

                employees = _IEmployeeService.GetList();
                LogUtils.LogInfo("GetEmployees end" + JsonConvert.SerializeObject(employees));
            }
            catch (System.Exception ex)
            {
                LogUtils.LogError(ex);
            }

            return employees;
        }
        [HttpPost]
        [JSONFilter(RootType = typeof(Department))]
        public void Update([FromBody] Employee employee)
        {
            try
            {
                LogUtils.LogInfo("Employee Update  start" + JsonConvert.SerializeObject(employee));
                _IEmployeeService.Update(employee);
                LogUtils.LogInfo("Employee Update  end");

            }
            catch (System.Exception ex)
            {

                LogUtils.LogError(ex);
            }

        }
    }
}