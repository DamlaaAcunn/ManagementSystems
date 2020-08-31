using EmployeeManagementSystem.Models;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace EmployeeManagementSystem.Models
{
    public class DbContext
    {
        public DbContext()
        {

        }
        private NpgsqlConnection connection = new NpgsqlConnection("Server=localhost;Port=5432;Database=EmployeeManagement;User Id=postgres;password=Dam1234+;");
        protected NpgsqlConnection ConnectionOpen()
        {
            if (connection.State == ConnectionState.Closed)
                connection.Open();
            return connection;
        }
        protected NpgsqlConnection ConnectionClosed()
        {
            if (connection.State == ConnectionState.Open)
                connection.Close();
            return connection;
        }

        public List<Department> GetDepartments()
        {
            List<Department> departments = new List<Department>();
            try
            {
                var str = '"' + "department" + '"';
                var query = "SELECT * FROM public." + str.ToString() + "";
                NpgsqlCommand command = new NpgsqlCommand(query, ConnectionOpen());
                NpgsqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var department = new Department();
                    department.Id = reader.GetInt32(0);
                    department.DepartmentName = reader.GetString(1);
                    department.Manager = reader.GetString(2);
                    department.LocationId = reader.GetInt32(3);

                    departments.Add(department);
                }
                ConnectionClosed();
            }
            catch (Exception ex)
            {

            }

            return departments;
        }
        /// <summary>
        /// Departmanların maaş ortalaması
        /// </summary>
        /// <returns></returns>
        public List<AverageSalaryofDepartments> AverageSalaryofDepartments()
        {
            List<AverageSalaryofDepartments> averageSalaryofDepartments = new List<AverageSalaryofDepartments>();
            var departments = GetDepartments();
            var employee = GetEmployee();
            if (employee.Count > 0)
            {
                var rates = employee
                          .GroupBy(g => g.DepartmetId, r => r.Salary)
                          .Select(g => new
                          {
                              DepartmetId = g.Key,
                              Salary = g.Average()
                          }).ToList();
                foreach (var item in rates)
                {
                    AverageSalaryofDepartments average = new AverageSalaryofDepartments();
                    average.Department = departments.Where(x => x.Id == item.DepartmetId).FirstOrDefault();
                    average.AverageSalary = item.Salary;
                    averageSalaryofDepartments.Add(average);
                }
            }


            return averageSalaryofDepartments;

        }
        /// <summary>
        /// Yöneticilerin çalışanlarının listelenmesi
        /// </summary>
        /// <returns></returns>
        public List<EmployeesofManagers> GetEmployeesofManagers()
        {
            List<EmployeesofManagers> employeesofManagers = new List<EmployeesofManagers>();
            try
            {
                var str = '"' + "department" + '"';
                var str2 = '"' + "employee" + '"';
                var query = "SELECT e.manager,d.departmentname,e.employeename FROM public." + str.ToString() + " d inner join public." + str2.ToString() + " e on e.manager=d.manager  group by e.manager, d.departmentname, e.employeename  order by e.manager ";
                NpgsqlCommand command = new NpgsqlCommand(query, ConnectionOpen());
                NpgsqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var employeesofManager = new EmployeesofManagers();
                    employeesofManager.Manager = reader.GetString(0);
                    employeesofManager.DepartmentName = reader.GetString(1);
                    employeesofManager.EmployeeName = reader.GetString(2);
                    employeesofManagers.Add(employeesofManager);
                }
                ConnectionClosed();
            }
            catch (Exception ex)
            {

            }

            return employeesofManagers;
        }

        public void Insert(Department department)
        {
            try
            {

                var str = '"' + "department" + '"';
                var column1 = '"' + "manager" + '"';
                var column2 = '"' + "locationid" + '"';
                var column3 = '"' + "departmentname" + '"';
                var query = "insert into public." + str.ToString() + "(" + column1 + "," + column2 + "," + column3 + ")VALUES (@manager,@locationid,@departmentname)";

                NpgsqlCommand command = new NpgsqlCommand(query, ConnectionOpen());

                command.Parameters.AddWithValue("@manager", department.Manager);
                command.Parameters.AddWithValue("@locationid", department.LocationId);
                command.Parameters.AddWithValue("@departmentname", department.DepartmentName);
                command.ExecuteNonQuery();
                ConnectionClosed();
            }
            catch (Exception ex)
            {

                throw;
            }

        }
        public List<Employee> GetEmployee()
        {
            List<Employee> employees = new List<Employee>();
            try
            {
                var str = '"' + "employee" + '"';
                var query = "SELECT * FROM public." + str.ToString() + "";
                NpgsqlCommand command = new NpgsqlCommand(query, ConnectionOpen());
                NpgsqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var employee = new Employee();
                    employee.Id = reader.GetInt32(0);
                    employee.EmployeeName = reader.GetString(1);
                    employee.SurName = reader.GetString(2);
                    employee.Email = reader.GetString(3);
                    employee.Phone = reader.GetString(4);
                    employee.StarDateOfWork = reader.GetDateTime(5);
                    employee.Salary = reader.GetDecimal(6);
                    employee.DepartmetId = reader.GetInt32(7);
                    employee.TitleId = reader.GetInt32(8);
                    employee.Manager = reader.GetString(9);

                    employees.Add(employee);
                }
                ConnectionClosed();
            }
            catch (Exception ex)
            {

            }

            return employees;
        }
        public void Insert(Employee employee)
        {
            try
            {

                var str = '"' + "employee" + '"';
                var column1 = '"' + "employeename" + '"';
                var column2 = '"' + "surname" + '"';
                var column3 = '"' + "email" + '"';
                var column4 = '"' + "phone" + '"';
                var column5 = '"' + "startdateofwork" + '"';
                var column6 = '"' + "salary" + '"';
                var column7 = '"' + "departmentid" + '"';
                var column8 = '"' + "titleid" + '"';
                var column9 = '"' + "manager" + '"';

                var query = "insert into public." + str.ToString() + "(" + column1 + "," + column2 + "," + column3 + "," + column4 + "," + column5 + ","
                    + column6 + "," + column7 + "," + column8 + "," + column9 + ")VALUES (@employeename,@surname,@email,@phone,@startdateofwork,@salary,@departmentid,@titleid,@manager)";

                NpgsqlCommand command = new NpgsqlCommand(query, ConnectionOpen());

                command.Parameters.AddWithValue("@employeename", employee.EmployeeName);
                command.Parameters.AddWithValue("@surname", employee.SurName);
                command.Parameters.AddWithValue("@email", employee.Email);
                command.Parameters.AddWithValue("@phone", employee.Phone);
                command.Parameters.AddWithValue("@startdateofwork", employee.StarDateOfWork);
                command.Parameters.AddWithValue("@salary", employee.Salary);
                command.Parameters.AddWithValue("@departmentid", employee.DepartmetId);
                command.Parameters.AddWithValue("@titleid", employee.TitleId);
                command.Parameters.AddWithValue("@manager", employee.Manager);
                command.ExecuteNonQuery();
                ConnectionClosed();
            }
            catch (Exception ex)
            {

            }

        }
        public void Update(Employee employee)
        {
            try
            {
                var str = '"' + "employee" + '"';
                var query = "update public." + str.ToString() + " set employeename=@employeename ,surname=@surname" +
                    " , email=@email , phone=@phone , startdateofwork=@startdateofwork , salary=@salary , departmentid=@departmentid ,titleid=@titleid,manager=@manager   WHERE Id=@Id";

                NpgsqlCommand command = new NpgsqlCommand(query, ConnectionOpen());

                command.Parameters.AddWithValue("@Id", employee.Id);
                command.Parameters.AddWithValue("@employeename", employee.EmployeeName);
                command.Parameters.AddWithValue("@surname", employee.SurName);
                command.Parameters.AddWithValue("@email", employee.Email);
                command.Parameters.AddWithValue("@phone", employee.Phone);
                command.Parameters.AddWithValue("@startdateofwork", employee.StarDateOfWork);
                command.Parameters.AddWithValue("@salary", employee.Salary);
                command.Parameters.AddWithValue("@departmentid", employee.DepartmetId);
                command.Parameters.AddWithValue("@titleid", employee.TitleId);
                command.Parameters.AddWithValue("@manager", employee.Manager);
                command.ExecuteNonQuery();
                ConnectionClosed();
            }
            catch (Exception ex)
            {

            }
        }

    }
}

