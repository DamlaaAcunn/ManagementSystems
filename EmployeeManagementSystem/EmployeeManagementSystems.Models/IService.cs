using EmployeeManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagementSystem.Models
{
    public interface IService<T> where T:class
    {
        EntitiyResult<T> Insert(T entities);
        EntitiyResult<T> Update(T entities);
        EntitiyResult<T> GetById(T entities);
        EntitiyResult<T> GetList(T entities);
    }
}
