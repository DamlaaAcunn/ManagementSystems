
using EmployeeManagementSystem.ExLogger;
using System.Net.Http.Formatting;
using System.Web.Http;

using System.Web.Http.ExceptionHandling;

namespace EmployeeManagementSystem
{
    //public static class WebApiConfig
    //{
    //    public static void Register(HttpConfiguration config)
    //    {
    //        // Web API configuration and services

    //        // Web API routes
    //        config.MapHttpAttributeRoutes();

    //        config.Routes.MapHttpRoute(
    //            name: "DefaultApi",
    //            routeTemplate: "api/{controller}/{id}",
    //            defaults: new { id = RouteParameter.Optional }
    //        );
    //    }
    //}
    public static class WebApiConfig
    {
        

        public static void Register(HttpConfiguration config)
        {

            //Registering GlobalExceptionHandler
            //config.Services.Replace(typeof(IExceptionHandler), new GlobalExceptionHandler());

            //config.Services.Add(typeof(IExceptionLogger), new ExceptionManagerApi());

            //var cors = new EnableCorsAttribute("https://localhost:44385", "*", "*");
            //config.EnableCors(cors);
            // Web API configuration and services


            config.Formatters.Clear();
            config.Formatters.Add(new JsonMediaTypeFormatter());
            config.Services.Add(typeof(IExceptionLogger), new ExceptionManagerApi());

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );


        }
    }

    class EnableCorsAttribute
    {
        private string v1;
        private string v2;
        private string v3;

        public EnableCorsAttribute(string v1, string v2, string v3)
        {
            this.v1 = v1;
            this.v2 = v2;
            this.v3 = v3;
        }
    }
}
