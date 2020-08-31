using System.Collections.Generic;

namespace EmployeeManagementSystem.Models
{
    public class EntitiyResult<T> where T : class
    {
        public bool Result { get; set; }
        public string  Error { get; set; }
        public T Object { get; set; }
        public  IList<T> Objects { get; set; }
    }
}