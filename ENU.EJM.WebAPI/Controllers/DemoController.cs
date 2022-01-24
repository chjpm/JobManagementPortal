using ENU.EJM.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ENU.EJM.WebAPI.Controllers
{
    /// <summary>
    /// This is where a Demo API details can be found.
    /// </summary>
    public class DemoController : ApiController
    {
        List<DemoPeople> people = new List<DemoPeople>();
        /// <summary>
        /// This is Demo constructor.
        /// </summary>
        public DemoController() 
        {
            people.Add(new DemoPeople { id=1, firstName="Jyoti Prakash", lastName="Mohanty"});
            people.Add(new DemoPeople { id = 2, firstName = "Raja", lastName = "Goud" });
            people.Add(new DemoPeople { id = 3, firstName = "Vinod", lastName = "Gunda" });
        }
        /// <summary>
        /// This will provide all First names.
        /// </summary>
        [Route("api/People/GetFirstNames")]
        [HttpGet]
        public List<string> GetFirstNames()
        {
            List<string> FirstName = new List<string>();
            foreach (var p in people)
            {
                FirstName.Add(p.firstName);
            }
            return FirstName;
        }
        /// <summary>
        /// This will provide all Last names.
        /// </summary>
        /// <returns>A list of Last Names</returns>
        [Route("api/People/GetFirstNames/{UserId:int}/{Age:int}")]
        [HttpGet]
        public List<string> GetLastNames()
        {
            List<string> LastName = new List<string>();
            foreach (var p in people)
            {
                LastName.Add(p.firstName);
            }
            return LastName;
        }

        // GET: api/Demo
        public List<DemoPeople> Get()
        {
            return people;
        }

        // GET: api/Demo/5
        public DemoPeople Get(int id)
        {
            return people.Where(x => x.id == id).FirstOrDefault();
        } 

        // POST: api/Demo
        public void Post(DemoPeople _people)
        {
            people.Add(_people);
        }

        // PUT: api/Demo/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Demo/5
        public void Delete(int id)
        {
        }
    }
}
