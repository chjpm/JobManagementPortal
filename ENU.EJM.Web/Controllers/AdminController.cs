using ENU.EJM.DAL;
using ENU.EJM.Web.Models;
using ENU.EJM.Web.Models.Repo;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace ENU.EJM.Web.Controllers
{
   // [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        // GET: Admin
        string BaseUri = ConfigurationManager.AppSettings["ApiUri"].ToString();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult MapEngineer()
        {
            //Call API api/GetSupervisors
            var db = new EJMDBRepo();
            //Call API api/GetEngineers
            var _model = new MapSupervisorToEngineer()
            {
                Engineer = db.GetEngineers(),
                Supervisor = db.GetSupervisor()
            };
            return View(_model);
        }
        public ActionResult MapEngineerModel(MapSupervisorToEngineer map)
        {
            if (ModelState.IsValid)
            {
                //Direct DB Connectivity
                //EJMDBRepo db = new EJMDBRepo();
                //db.MapSupervisorEngineer(map);
                //return RedirectToAction("EngineerMapping");

                //API Call api/MapSupervisorToEngineer
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(BaseUri);
                    var postTask = client.PostAsJsonAsync<MapSupervisorToEngineer>("MapSupervisorToEngineer", map);
                    postTask.Wait();

                    var result = postTask.Result;  
                    if (result.IsSuccessStatusCode)
                    {
                        return RedirectToAction("EngineerMapping");
                    }
                }
            }
            ModelState.AddModelError(string.Empty, "Error in model");
            return RedirectToAction("MapEngineer", map);
        }
        public ActionResult EngineerMapping()
        {
            List<MapSupervisorToEngineer> mp = new List<MapSupervisorToEngineer>();
            using (var db = new EJMEFConnection())
            {
                //MapSupervisorToEngineer mp = new MapSupervisorToEngineer();
                List<tblEngineer> tblEng = (from eng in db.tblEngineers select eng).ToList();
                var obj = new EJMDBRepo();
                foreach (var p in tblEng)
                {
                    mp.Add(new MapSupervisorToEngineer
                    {
                        EngineerID = obj.GetUserName(p.EngineerID),
                        SupervisorID = obj.GetUserName(p.SupervisorID),
                        Description = p.Description
                    });
                }

            }
            return View(mp);
        }



    }
}