using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ENU.EJM.DAL;
using ENU.EJM.Web.Models;
using ENU.EJM.Web.Models.Repo;

namespace ENU.EJM.Web.Controllers
{
    public class SupervisorController : Controller
    {
        EJMDBRepo dbRepo = new EJMDBRepo();
        // GET: Supervisor
        public ActionResult JobsActivity()
        {
            
            List<JobActivityVM> ja = new List<JobActivityVM>();
            using (var ctx = new EJMEFConnection())
            {
                List<vwJobActivityList> read = ctx.vwJobActivityLists.ToList();
                foreach (var p in read)
                {
                    ja.Add(new JobActivityVM
                    {
                        JobRequestID = p.RequestID,
                        CustomerName = p.CustomerName,
                        Address = p.Address,
                        JobStatus = p.JobStatus,

                        Description = p.Description,
                        Engineer = p.EngineerID == "0" ? dbRepo.GetEngineers() : dbRepo.GetEngineers(dbRepo.GetUserName(p.EngineerID), p.EngineerID)
                        //Engineer = dbRepo.GetEngineers()

                    });
                }
            }

            return View(ja);
        }

        public ActionResult CreateJobsActivity(JobActivityVM model)
        {
            //post a single row in mvc 5
            //https://stackoverflow.com/questions/41126676/mvc-updating-individual-row-of-table-data-post
            if (ModelState.IsValid)
            {
                using (var ctx = new EJMEFConnection())
                {
                    ctx.tblJobActivities.Add(new tblJobActivity
                    {
                        JobRequestID = model.JobRequestID,
                        JobStatus = "Queued",
                        Description = "Waiting for Engineer Acceptance.",
                        EngineerID = model.EngineerID,
                        LastUpdated = DateTime.Now
                    });
                    ctx.SaveChanges();
                }
            }
            else
            {
                ModelState.AddModelError("", "Error in Model");
            }
            return RedirectToAction("JobsActivity");
        }

        [HttpGet]
        public ActionResult AssignEngineer(int id)
        {
            JobActivityVM jvm = new JobActivityVM();

            using (var ctx = new EJMEFConnection())
            {
                List<vwJobActivityList> lst = (from jobActivity in ctx.vwJobActivityLists where jobActivity.RequestID==id select jobActivity).ToList();
                if (lst.Count() > 1 & id!=0)
                {
                    ModelError.Equals(string.Empty, "There are some error while fetching data for this Job.");
                }
                else 
                {
                    var data = lst.FirstOrDefault();
                    jvm.JobRequestID = data.RequestID;
                    jvm.CustomerName = data.CustomerName;
                    jvm.Address = data.Address;
                    jvm.JobStatus = data.JobStatus;
                    jvm.Description = data.Description;
                    //jvm.EngineerID = data.EngineerID;
                    jvm.Engineer = dbRepo.GetEngineers();
                }
            }
            return PartialView(jvm);
        }



    }
}