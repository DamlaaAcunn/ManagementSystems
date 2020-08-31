using EmployeeManagementSystem.Models;
using EmployeeManagementSystem.Resolver;
using System.ComponentModel.Composition;
namespace EmployeeManagementSystem.Services
{
    [Export(typeof(IComponent))]
    public class DependencyResolver : IComponent
    {
        public void SetUp(IRegisterComponent registerComponent)
        {
            registerComponent.RegisterType<IDepartmentService, DepartmentService>();
            registerComponent.RegisterType<IEmployeeService, EmployeeService>();
        }
    }
}

