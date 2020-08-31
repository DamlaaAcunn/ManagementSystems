using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagementSystem.Models
{
    public class Title
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime TitleName { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
    }
}
