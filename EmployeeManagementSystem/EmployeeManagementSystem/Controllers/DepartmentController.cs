
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
    public class DepartmentController : ApiController
    {
        // GET: Department
        #region Private variable.

        private readonly IDepartmentService _IDepartmentService;

        #endregion
        public DepartmentController(IDepartmentService departmentService)
        {
            LogUtils.LogInfo("DepartmentController Start ");
            _IDepartmentService = departmentService;
        }

        [HttpPost]
        [JSONFilter(RootType = typeof(Department))]
        public void Insert([FromBody] Department department)
        {
            try
            {
                LogUtils.LogInfo("Department Insert Start" + JsonConvert.SerializeObject(department));
                _IDepartmentService.Insert(department);
                LogUtils.LogInfo("Department Insert end");
            }
            catch (System.Exception ex)
            {

                LogUtils.LogError(ex);
            }

        }
        [HttpPost]
        [JSONFilter(RootType = typeof(Department))]
        public List<Department> GetDepartments()
        {
            List<Department> departments = new List<Department>();
            try
            {
                LogUtils.LogInfo("GetDepartments  start");
                departments = _IDepartmentService.GetList();
                LogUtils.LogInfo("GetDepartments  end" + JsonConvert.SerializeObject(departments));
            }
            catch (System.Exception ex)
            {
                LogUtils.LogError(ex);
            }

            return departments;
        }
        [HttpPost]
        [JSONFilter(RootType = typeof(Department))]
        public List<EmployeesofManagers> GetEmployeesofManagers()
        {
            List<EmployeesofManagers> employeesofManagers = new List<EmployeesofManagers>();
            try
            {
                LogUtils.LogInfo("GetEmployeesofManagers  start");
                employeesofManagers = _IDepartmentService.GetEmployeesofManagers();
                LogUtils.LogInfo("GetEmployeesofManagers  end" + JsonConvert.SerializeObject(employeesofManagers));
            }
            catch (System.Exception ex)
            {

                LogUtils.LogError(ex);
            }

            return employeesofManagers;
        }
        [HttpPost]
        [JSONFilter(RootType = typeof(Department))]
        public List<AverageSalaryofDepartments> AverageSalaryofDepartments()
        {
            List<AverageSalaryofDepartments> averageSalaryofDepartments = new List<AverageSalaryofDepartments>();
            try
            {
                LogUtils.LogInfo("AverageSalaryofDepartments  start");
                averageSalaryofDepartments = _IDepartmentService.AverageSalaryofDepartments();
                LogUtils.LogInfo("AverageSalaryofDepartments  end" + JsonConvert.SerializeObject(averageSalaryofDepartments));
            }
            catch (System.Exception ex)
            {

                LogUtils.LogError(ex);
            }

            return averageSalaryofDepartments;
        }

    }
}