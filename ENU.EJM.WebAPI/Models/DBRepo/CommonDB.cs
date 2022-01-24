using ENU.EJM.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ENU.EJM.WebAPI.Models.DBRepo
{
    public class CommonDB
    {
        public static void AssignEngineer(string SupID, List<string> EngIDs, string description)
        {
            try
            {
                foreach (var _emp in EngIDs)
                {
                    using (var db = new EJMEFConnection())
                    {
                        db.spMapSupervisor(SupID, _emp, description);
                        db.SaveChanges();
                    }
                }
                
            }
            catch(Exception ex) 
            {
                throw ex;
            }
            
        }
    }
}