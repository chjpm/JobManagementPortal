using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ENU.EJM.Web.Models
{
    public class JobActivityVM
    {
        [Display(Name = "Job ID")]
        public int JobRequestID { get; set; }

        [Display(Name = "Customer Name")]
        public string CustomerName { get; set; }

        [Display(Name = "Address")]
        [Required(ErrorMessage = "Please enter customer's Address.")]
        public string Address { get; set; }

        [Display(Name ="Job Status")]
        public string JobStatus { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        [Display(Name = "Engineer")]
        public string EngineerID { get; set; }
        public IEnumerable<SelectListItem> Engineer { get; set; }


    }
}