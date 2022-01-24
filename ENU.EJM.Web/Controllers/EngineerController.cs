using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ENU.EJM.DAL;
using ENU.EJM.Web.Models;
using ENU.EJM.Web.Models.Repo;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace ENU.EJM.Web.Controllers
{
    public class EngineerController : Controller
    {
        EJMEFConnection db = new EJMEFConnection();
        EJMDBRepo dbRepo = new EJMDBRepo();
        [Authorize(Roles = "Engineer")]
        // GET: Engineer
        public ActionResult Index()
        {
            if (Request.IsAuthenticated)
            {
                var _userID = User.Identity.GetUserId();

                List<JobActivityVM> ja = new List<JobActivityVM>();
                using (var ctx = new EJMEFConnection())
                {
                    List<vwJobActivityList> read = ctx.vwJobActivityLists.Where(y=>y.EngineerID == _userID).Select(job => job).ToList();
                    foreach (var p in read)
                    {
                        ja.Add(new JobActivityVM
                        {
                            JobRequestID = p.RequestID,
                            CustomerName = p.CustomerName,
                            Address = p.Address,
                            JobStatus = p.JobStatus,

                            Description = p.Description,
                            //Engineer = p.EngineerID == "0" ? dbRepo.GetEngineers() : dbRepo.GetEngineers(dbRepo.GetUserName(p.EngineerID), p.EngineerID)
                            //Engineer = dbRepo.GetEngineers()

                        });
                    }
                }

                return View(ja);
            }

            return RedirectToAction("LogIn","Account");
        }

        public ActionResult Accept(int ID)
        {
            string _userID = User.Identity.GetUserId();
            using (var ctx = new EJMEFConnection())
            {
                ctx.spAcceptJobRequest(ID, _userID);
                ctx.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public ActionResult Reject(int ID,string description)
        {
            string _userID = User.Identity.GetUserId();
            using (var ctx = new EJMEFConnection())
            {
                ctx.spRejectJobRequest(ID, _userID, description);
                ctx.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}