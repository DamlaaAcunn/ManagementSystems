using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EmployeeManagementSystem;
using EmployeeManagementSystem.Controllers;
using EmployeeManagementSystem.Models;
using EmployeeManagementSystem.Services;

namespace EmployeeManagementSystem.Tests.Controllers
{
    [TestClass]
    public class EmployeeControllerTest
    {
        private readonly IEmployeeService _IEmployeeService;

        public EmployeeControllerTest(IEmployeeService employeeService)
        {
            _IEmployeeService = employeeService;
        }
        [TestMethod]
        public void Get()
        {
            // Arrange
            EmployeeController controller = new EmployeeController(_IEmployeeService);

            // Act
            var result = controller.GetEmployees();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count());
            Assert.AreEqual("value1", result.ElementAt(0));
            Assert.AreEqual("value2", result.ElementAt(1));
        }


        [TestMethod]
        public void Post()
        {
            // Arrange
            EmployeeController controller = new EmployeeController();
            Employee employee = new Employee();
            employee.EmployeeName = "";
            employee.SurName = "";
            employee.Manager = "";
            employee.Phone = "";
            employee.Email = "";
            employee.DepartmetId = 1;
            employee.TitleId = 1;
            employee.Salary = 70000;
            // Act
            controller.Insert(employee);

            // Assert
        }

        [TestMethod]
        public void Put()
        {
            // Arrange
            EmployeeController controller = new EmployeeController();
            Employee employee = new Employee();
            employee.EmployeeName = "";
            employee.SurName = "";
            employee.Manager = "";
            employee.Phone = "";
            employee.Email = "";
            employee.DepartmetId = 1;
            employee.TitleId = 1;
            employee.Salary = 70000;
            // Act
            controller.Update(employee);

            // Assert
        }
    }
}
