using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ENU.EJM.Web.Models
{
    public class CreateJobModels
    {
        [Display(Name ="Job ID")]
        public int RequestID { get; set; }

        [Display(Name = "Customer Name")]
        [Required(ErrorMessage = "Please enter Customer name.")]
        public string CustomerName { get; set; }

        [Display(Name = "Address")]
        [Required(ErrorMessage = "Please enter customer's Address.")]
        [DataType(DataType.MultilineText)]
        public string Address { get; set; }

        [Display(Name = "Email Address")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Please provide a valid email address.")]
        public string EmailAddress { get; set; }

        [Display(Name = "Phone Number")]
        [Required(ErrorMessage = "Please provide customer's contact number.")]
        [DataType(DataType.PhoneNumber, ErrorMessage = "Please provide a valid phone number.")]
        public string TelPhoneNumber { get; set; }

        [Display(Name = "Job Item")]
        [Required(ErrorMessage = "Please choose a Job Item.")]
        public string JobItem { get; set; }

        [Display(Name ="Job Type")]
        [Required(ErrorMessage ="Please choose a Job Type.")]
        public string JobType { get; set; }

        [Display(Name ="Preffered Time of Contact")]
        [Required(ErrorMessage ="Please provide a preffered time of contact.")]
        //[DataType(DataType.DateTime, ErrorMessage ="Please provide a valid Date time")]
        //[DisplayFormat(ApplyFormatInEditMode =true, DataFormatString ="{0:dd/mm/yyyy HH:i:s}")]
        public string PrefferedDateTime { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }
    }

    public enum JobItem
    {
        Broadband,
        TV
    }
    public enum JobType
    {
        Installation,
        Service
    }
}