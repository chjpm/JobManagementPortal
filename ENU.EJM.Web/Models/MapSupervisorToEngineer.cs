using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ENU.EJM.Web.Models
{
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

        [Required]
        [Display(Name = "Supervisor")]
        public string SupervisorID { get; set; }
        public IEnumerable<SelectListItem> Supervisor { get; set; }

        [Required]
        [Display(Name = "Engineer")]
        public string EngineerID { get; set; }
        public IEnumerable<SelectListItem> Engineer { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; } = null;
    }
}