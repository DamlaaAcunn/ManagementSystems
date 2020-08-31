using System.Collections.Generic;
using System.Web.Http;

namespace EmployeeManagementSystem.Controllers
{
    public class ValuesController : ApiController
    {
        //PGDbContext pGDbContext;
        //public ValuesController ()
        //{
        //    pGDbContext = new  PGDbContext();
        //}
        // GET api/values
        public IEnumerable<string> Get()
        {


            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
         
            return "value";
        }

        // POST api/values
        public void Post([FromBody] string value)
        {
            //using (var context = new PGDbContext())
            //{
            //    var cars = context.Departments.ToArray();
            //    Console.WriteLine($"We have {cars.Length} car(s).");
            //}
            //var data = pGDbContext.Departments.Tolist();
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
