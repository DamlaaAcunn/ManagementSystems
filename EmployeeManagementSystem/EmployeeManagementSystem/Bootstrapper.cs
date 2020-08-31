

using EmployeeManagementSystem.Resolver;
using Microsoft.Practices.Unity;
using System.Web.Http;
using Unity.Mvc3;

namespace EmployeeManagementSystem
{
    public static class Bootstrapper
    {
        public static void Initialise()
        {
            var container = BuildUnityContainer();
            System.Web.Mvc.DependencyResolver.SetResolver(new UnityDependencyResolver(container));
            //System.Web.Mvc.DependencyResolver.SetResolver(new UnityDependencyResolver((Unity.IUnityContainer)container));

            // GlobalConfiguration.Configuration.DependencyResolver = new Unity.WebApi.UnityDependencyResolver((Unity.IUnityContainer)container);
            GlobalConfiguration.Configuration.DependencyResolver = new Unity.WebApi.UnityDependencyResolver(container);
        }
        private static IUnityContainer BuildUnityContainer()
        {
            // var container = new UnityContainer();
            var container = new UnityContainer();
            RegisterTypes(container);
            return container;
        }

        public static void RegisterTypes(IUnityContainer container)
        {
            //Component initialization via MEF
            ComponentLoader.LoadContainer(container, ".\\bin", "EmployeeManagementSystem.dll");
            ComponentLoader.LoadContainer(container, ".\\bin", "EmployeeManagementSystem.Services.dll");

        }

    }

}