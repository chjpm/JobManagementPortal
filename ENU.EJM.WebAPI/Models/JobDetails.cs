using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ENU.EJM.WebAPI.Models
{
    /// <summary>
    /// This is a Job Model
    /// </summary>
    public class JobDetails
    {
        /// <summary>
        /// This is used for Job ID
        /// </summary>
        [Display(Name = "Job ID")]
        public int RequestID { get; set; }

        /// <summary>
        /// This is used for Customer name
        /// </summary>
        [Display(Name = "Customer Name")]
        [Required(ErrorMessage = "Please enter Customer name.")]
        public string CustomerName { get; set; }

        /// <summary>
        /// This is used for Customer Address
        /// </summary>
        [Display(Name = "Address")]
        [Required(ErrorMessage = "Please enter customer's Address.")]
        [DataType(DataType.MultilineText)]
        public string Address { get; set; }

        /// <summary>
        /// This is used for customer email address
        /// </summary>
        [Display(Name = "Email Address")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Please provide a valid email address.")]
        public string EmailAddress { get; set; }

        /// <summary>
        /// This is used for customer phone number
        /// </summary>
        [Display(Name = "Phone Number")]
        [Required(ErrorMessage = "Please provide customer's contact number.")]
        [DataType(DataType.PhoneNumber, ErrorMessage = "Please provide a valid phone number.")]
        public string TelPhoneNumber { get; set; }

        /// <summary>
        /// This is used for Job Item
        /// </summary>
        [Display(Name = "Job Item")]
        [Required(ErrorMessage = "Please choose a Job Item.")]
        public string JobItem { get; set; }

        /// <summary>
        /// This is used for Job Type
        /// </summary>
        [Display(Name = "Job Type")]
        [Required(ErrorMessage = "Please choose a Job Type.")]
        public string JobType { get; set; }

        /// <summary>
        /// This is used for Preffered Time of contact
        /// </summary>
        [Display(Name = "Preffered Time of Contact")]
        [Required(ErrorMessage = "Please provide a preffered time of contact.")]
        //[DataType(DataType.DateTime, ErrorMessage ="Please provide a valid Date time")]
        //[DisplayFormat(ApplyFormatInEditMode =true, DataFormatString ="{0:dd/mm/yyyy HH:i:s}")]
        public string PrefferedDateTime { get; set; }

        /// <summary>
        /// This is used for Description
        /// </summary>
        [Display(Name = "Description")]
        public string Description { get; set; }
    }
}