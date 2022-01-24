using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ENU.EJM.WebAPI.Models
{
    /// <summary>
    /// Details about a person
    /// </summary>
    public class DemoPeople
    {
        /// <summary>
        /// ID From SQL
        /// </summary>
        public int id { get; set; } = 0;
        /// <summary>
        /// First name of people.
        /// </summary>
        public string firstName { get; set; } = "";
        /// <summary>
        /// Last name of people.
        /// </summary>
        public string lastName { get; set; } = "";
    }
}