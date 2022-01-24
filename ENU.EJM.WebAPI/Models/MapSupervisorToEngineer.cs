using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ENU.EJM.WebAPI.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class MapSupervisorToEngineer
    {
        //[Required]
        //[Display(Name = "State / Region")]
        //public string SelectedRegionCode { get; set; }
        //public IEnumerable<SelectListItem> Regions { get; set; }


        //[Required]
        //[Display(Name = "Country")]
        //public string SelectedCountryIso3 { get; set; }
        //public IEnumerable<SelectListItem> Countries { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Required]
        [Display(Name = "SupervisorID")]
        public string SupervisorID { get; set; }
        //public IEnumerable<SelectListItem> Supervisor { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Required]
        [Display(Name = "EngineerID")]
        public string EngineerID { get; set; }
        //public IEnumerable<SelectListItem> Engineer { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "Description")]
        public string Description { get; set; } = null;
    }
}