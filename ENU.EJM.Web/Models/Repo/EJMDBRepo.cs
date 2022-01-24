using ENU.EJM.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ENU.EJM.Web.Models.Repo
{
    public class EJMDBRepo
    {
        public IEnumerable<SelectListItem> GetEngineers()
        {
            using (var context = new EJMEFConnection())
            {
                //var test = from t in context.AspNetUsers where t.AspNetRoles = "Admin";
                List<SelectListItem> engineer = context.vwUserInRoles.AsNoTracking().Where(x => x.RoleID == "103")
                //List < SelectListItem > engineer = context.AspNetUsers.AsNoTracking().Where(x => x.AspNetRoles == new AspNetRole{ Name="Admin"} )
                                                                                     //.OrderBy(n => n.AspNetRoles == "")
                        .Select(n =>
                        new SelectListItem
                        {
                            Value = n.UserId.ToString(),
                            Text = n.UserName
                        }).ToList();
                var supervisorip = new SelectListItem()
                {
                    Value = null,
                    Text = "--- Select Engineeer ---"
                };
                engineer.Insert(0, supervisorip);
                return new SelectList(engineer, "Value", "Text");
            }
        }
        public IEnumerable<SelectListItem> GetEngineers(string text, string value)
        {
            using (var context = new EJMEFConnection())
            {
                //var test = from t in context.AspNetUsers where t.AspNetRoles = "Admin";
                List<SelectListItem> engineer = context.vwUserInRoles.AsNoTracking().Where(x => x.RoleID == "103")
                        //List < SelectListItem > engineer = context.AspNetUsers.AsNoTracking().Where(x => x.AspNetRoles == new AspNetRole{ Name="Admin"} )
                        //.OrderBy(n => n.AspNetRoles == "")
                        .Select(n =>
                        new SelectListItem
                        {
                            Value = n.UserId.ToString(),
                            Text = n.UserName
                        }).ToList();
                var supervisorip = new SelectListItem()
                {
                    Value = value,
                    Text = text
                };
                engineer.Insert(0, supervisorip);
                return new SelectList(engineer, "Value", "Text");
            }

        }
        public IEnumerable<SelectListItem> GetSupervisor()
        {
            using (var context = new EJMEFConnection())
            {
                List<SelectListItem> supervisor = context.vwUserInRoles.AsNoTracking().Where(x => x.RoleID == "102")
                        //List<SelectListItem> supervisor = context.AspNetUsers.AsNoTracking()//.Where(x => x.Id == new )
                        //.OrderBy(n => n.AspNetRoles == "")
                        .Select(n =>
                        new SelectListItem
                        {
                            Value = n.UserId.ToString(),
                            Text = n.UserName
                        }).ToList();
                var supervisorip = new SelectListItem()
                {
                    Value = null,
                    Text = "--- Select Supervisor ---"
                };
                supervisor.Insert(0, supervisorip);
                return new SelectList(supervisor, "Value", "Text");
            }
        }

        public  int MapSupervisorEngineer(MapSupervisorToEngineer model)
        {
            int ret = 0;
            using (var db = new EJMEFConnection())
            {
                db.spMapSupervisor(model.SupervisorID, model.EngineerID, model.Description);
                //db.tblEngineers.Add(new tblEngineer
                //{
                //    EngineerID = model.EngineerID,
                //    SupervisorID = model.SupervisorID,
                //    Description = model.Description
                //});
                db.SaveChanges();
                ret = 1;
            }
            return ret;
        }

        public string GetUserName(string UserId)
        {
            string _userName = null;
            if (!string.IsNullOrEmpty(UserId))
            {
                using (var db = new EJMEFConnection())
                {
                    _userName = (from _user in db.AspNetUsers where _user.Id == UserId select _user.UserName).FirstOrDefault().ToString();
                    //List<AspNetUser> user = (from _user in db.AspNetUsers select _user).ToList(); 
                    //_userName = user.Where(x => x.Id == UserId).Select
                }
            }
            return _userName;
        }
    }
}