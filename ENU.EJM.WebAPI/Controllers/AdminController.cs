using ENU.EJM.DAL;
using ENU.EJM.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ENU.EJM.WebAPI.Models.DBRepo;

namespace ENU.EJM.WebAPI.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class AdminController : ApiController
    {
        /// <summary>
        /// This methos used to Map an Employee to a Supervisor
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Route("api/MapSupervisorToEngineer")]
        [HttpPost]
        public IHttpActionResult PostCreateJob(MapSupervisorToEngineer model)
        {
            if (ModelState.IsValid)
            {
                using (var db = new EJMEFConnection())
                {
                    db.spMapSupervisor(model.SupervisorID, model.EngineerID, model.Description);
                    db.SaveChanges();
                }
                return Ok();
            }
            else
                return BadRequest("Invalid input! Please contact administrator.");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="SupID"></param>
        /// <param name="EmpIDs"></param>
        /// <param name="Des"></param>
        /// <returns></returns>
        [Route("api/MapSupervisor")]
        [HttpPost]
        public IHttpActionResult MapSupervisor(string SupID, List<string> EmpIDs, string Des)
        {
            if (ModelState.IsValid)
            {
                CommonDB.AssignEngineer(SupID, EmpIDs, Des);

                return Ok("Successfully assigned.");
            }
            else
                return BadRequest("Invalid input! Please contact administrator.");
        }
    }
}
