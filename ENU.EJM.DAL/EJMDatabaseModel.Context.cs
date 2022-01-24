﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ENU.EJM.DAL
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class EJMEFConnection : DbContext
    {
        public EJMEFConnection()
            : base("name=EJMEFConnection")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<tblEngineer> tblEngineers { get; set; }
        public virtual DbSet<tblJobActivity> tblJobActivities { get; set; }
        public virtual DbSet<tblJobRequest> tblJobRequests { get; set; }
        public virtual DbSet<vwUserInRole> vwUserInRoles { get; set; }
        public virtual DbSet<vwJobActivityList> vwJobActivityLists { get; set; }
    
        public virtual int spCreateJobRequest(string customerName, string address, string emailAddress, string phoneNumber, string jobItem, string jobType, string description, Nullable<System.DateTime> prefferedTime)
        {
            var customerNameParameter = customerName != null ?
                new ObjectParameter("CustomerName", customerName) :
                new ObjectParameter("CustomerName", typeof(string));
    
            var addressParameter = address != null ?
                new ObjectParameter("Address", address) :
                new ObjectParameter("Address", typeof(string));
    
            var emailAddressParameter = emailAddress != null ?
                new ObjectParameter("EmailAddress", emailAddress) :
                new ObjectParameter("EmailAddress", typeof(string));
    
            var phoneNumberParameter = phoneNumber != null ?
                new ObjectParameter("PhoneNumber", phoneNumber) :
                new ObjectParameter("PhoneNumber", typeof(string));
    
            var jobItemParameter = jobItem != null ?
                new ObjectParameter("JobItem", jobItem) :
                new ObjectParameter("JobItem", typeof(string));
    
            var jobTypeParameter = jobType != null ?
                new ObjectParameter("JobType", jobType) :
                new ObjectParameter("JobType", typeof(string));
    
            var descriptionParameter = description != null ?
                new ObjectParameter("Description", description) :
                new ObjectParameter("Description", typeof(string));
    
            var prefferedTimeParameter = prefferedTime.HasValue ?
                new ObjectParameter("PrefferedTime", prefferedTime) :
                new ObjectParameter("PrefferedTime", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("spCreateJobRequest", customerNameParameter, addressParameter, emailAddressParameter, phoneNumberParameter, jobItemParameter, jobTypeParameter, descriptionParameter, prefferedTimeParameter);
        }
    
        public virtual int spDeleteJobRequest(Nullable<int> requestID)
        {
            var requestIDParameter = requestID.HasValue ?
                new ObjectParameter("RequestID", requestID) :
                new ObjectParameter("RequestID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("spDeleteJobRequest", requestIDParameter);
        }
    
        public virtual int spEditJobRequest(Nullable<int> requestID, string customerName, string address, string emailAddress, string phoneNumber, string jobItem, string jobType, string description, Nullable<System.DateTime> prefferedTime)
        {
            var requestIDParameter = requestID.HasValue ?
                new ObjectParameter("RequestID", requestID) :
                new ObjectParameter("RequestID", typeof(int));
    
            var customerNameParameter = customerName != null ?
                new ObjectParameter("CustomerName", customerName) :
                new ObjectParameter("CustomerName", typeof(string));
    
            var addressParameter = address != null ?
                new ObjectParameter("Address", address) :
                new ObjectParameter("Address", typeof(string));
    
            var emailAddressParameter = emailAddress != null ?
                new ObjectParameter("EmailAddress", emailAddress) :
                new ObjectParameter("EmailAddress", typeof(string));
    
            var phoneNumberParameter = phoneNumber != null ?
                new ObjectParameter("PhoneNumber", phoneNumber) :
                new ObjectParameter("PhoneNumber", typeof(string));
    
            var jobItemParameter = jobItem != null ?
                new ObjectParameter("JobItem", jobItem) :
                new ObjectParameter("JobItem", typeof(string));
    
            var jobTypeParameter = jobType != null ?
                new ObjectParameter("JobType", jobType) :
                new ObjectParameter("JobType", typeof(string));
    
            var descriptionParameter = description != null ?
                new ObjectParameter("Description", description) :
                new ObjectParameter("Description", typeof(string));
    
            var prefferedTimeParameter = prefferedTime.HasValue ?
                new ObjectParameter("PrefferedTime", prefferedTime) :
                new ObjectParameter("PrefferedTime", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("spEditJobRequest", requestIDParameter, customerNameParameter, addressParameter, emailAddressParameter, phoneNumberParameter, jobItemParameter, jobTypeParameter, descriptionParameter, prefferedTimeParameter);
        }
    
        public virtual int spMapSupervisor(string supID, string engId, string description)
        {
            var supIDParameter = supID != null ?
                new ObjectParameter("SupID", supID) :
                new ObjectParameter("SupID", typeof(string));
    
            var engIdParameter = engId != null ?
                new ObjectParameter("EngId", engId) :
                new ObjectParameter("EngId", typeof(string));
    
            var descriptionParameter = description != null ?
                new ObjectParameter("Description", description) :
                new ObjectParameter("Description", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("spMapSupervisor", supIDParameter, engIdParameter, descriptionParameter);
        }
    
        public virtual int spAcceptJobRequest(Nullable<int> jobRequestID, string engineerID)
        {
            var jobRequestIDParameter = jobRequestID.HasValue ?
                new ObjectParameter("JobRequestID", jobRequestID) :
                new ObjectParameter("JobRequestID", typeof(int));
    
            var engineerIDParameter = engineerID != null ?
                new ObjectParameter("EngineerID", engineerID) :
                new ObjectParameter("EngineerID", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("spAcceptJobRequest", jobRequestIDParameter, engineerIDParameter);
        }
    
        public virtual int spRejectJobRequest(Nullable<int> jobRequestID, string engineerID, string description)
        {
            var jobRequestIDParameter = jobRequestID.HasValue ?
                new ObjectParameter("JobRequestID", jobRequestID) :
                new ObjectParameter("JobRequestID", typeof(int));
    
            var engineerIDParameter = engineerID != null ?
                new ObjectParameter("EngineerID", engineerID) :
                new ObjectParameter("EngineerID", typeof(string));
    
            var descriptionParameter = description != null ?
                new ObjectParameter("Description", description) :
                new ObjectParameter("Description", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("spRejectJobRequest", jobRequestIDParameter, engineerIDParameter, descriptionParameter);
        }
    }
}
