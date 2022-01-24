using ENU.EJM.WebAPI.Models;
using ENU.EJM.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;




namespace ENU.EJM.WebAPI.Controllers
{
    /// <summary>
    /// This is a Job Controller
    /// </summary>
    public class JobController : ApiController
    {
        EJMEFConnection db = new EJMEFConnection();
        
        /// <summary>
        /// This is a JobController constructor.
        /// </summary>
        public JobController()
        {
            //jobs.Add(new JobDetails { RequestID=1000, CustomerName = "Jyoti Prakash", TelPhoneNumber = "9938650052", Address = "Pakshyot, Kendrapara", EmailAddress = "chjpm@outlook.com", Description = "Need to install new TV", JobItem = "TV", JobType = "Installation", PrefferedDateTime = DateTime.Now.ToString() });
            //jobs.Add(new JobDetails { RequestID=1001, CustomerName = "Raja Goud", TelPhoneNumber = "9938650052", Address = "Hyderabad, Telengana", EmailAddress = "raja@outlook.com", Description = "Need to install new Broadband", JobItem = "Broadband", JobType = "Service", PrefferedDateTime = DateTime.Now.ToString() });
        }

        /// <summary>
        /// Get Jobs helps to fetch total list of jobs
        /// </summary>
        /// <returns></returns>
        [Route("api/GetJobs")]
        [HttpGet]
        public List<JobDetails> GetJobs()
        {
            List<JobDetails> jobs = new List<JobDetails>();
            //Method base syntax entity framework syntax
            List<tblJobRequest> _jobs = db.tblJobRequests.Select(job => job).ToList();
            foreach (var p in _jobs)
            {
                jobs.Add(new JobDetails 
                { 
                    RequestID = p.RequestID, CustomerName=p.CustomerName, Address=p.Address, TelPhoneNumber=p.PhoneNumber, Description=p.Description
                    ,EmailAddress = p.EmailAddress, JobItem=p.JobItem, JobType= p.JobType, PrefferedDateTime=p.PrefferedTime.ToString("MM/dd/yyyy h:mm tt")
                });
            }
            return jobs;
        }
        /// <summary>
        /// Get Job list by using ID
        /// </summary>
        // <param name="id">Take the ID as input int type.</param>
        // <returns></returns>
        [Route("api/GetJobs/{id:int}")]
        [HttpGet]
        public List<JobDetails> GetJobs(int id)
        {
            List<JobDetails> jobs = new List<JobDetails>();
            //Query base syntax entity framework syntax
            List<tblJobRequest> _jobs = (from job in db.tblJobRequests where job.RequestID == id select job).ToList();
            foreach (var p in _jobs)
            {
                jobs.Add(new JobDetails
                {
                    RequestID = p.RequestID,
                    CustomerName = p.CustomerName,
                    Address = p.Address,
                    TelPhoneNumber = p.PhoneNumber,
                    Description = p.Description,
                    EmailAddress = p.EmailAddress,
                    JobItem = p.JobItem,
                    JobType = p.JobType,
                    PrefferedDateTime = p.PrefferedTime.ToString("MM/dd/yyyy h:mm tt")
                });
            }
            return jobs;
        }

        /// <summary>
        /// Get a first or default Job by using ID
        /// </summary>
        // <param name="id">Take the ID as input int type.</param>
        // <returns></returns>
        [Route("api/GetJob/{id:int}")]
        [HttpGet]
        public JobDetails GetJob(int id)
        {
            JobDetails job = new JobDetails();
            //Query base syntax entity framework syntax
            //List<tblJobRequest> _jobs = from _job in db.tblJobRequests where _job.RequestID == id select _job.Fis;
            List<tblJobRequest> _jobs = (from _job in db.tblJobRequests where _job.RequestID == id select _job).ToList();
            var jr = _jobs.Where(x => x.RequestID == id).FirstOrDefault();
            job.RequestID = jr.RequestID;
            job.CustomerName = jr.CustomerName;
            job.Address = jr.Address;
            job.TelPhoneNumber = jr.PhoneNumber;
            job.EmailAddress = jr.EmailAddress;
            job.JobItem = jr.JobItem;
            job.JobType = jr.JobType;
            job.Description = jr.Description;
            job.PrefferedDateTime = jr.PrefferedTime.ToString("MM/dd/yyyy h:mm tt");
            return job;
        }

        /// <summary>
        /// This method used to create job
        /// </summary>
        /// <param name="model"></param>
        [Route("api/CreateJob")]
        [HttpPost]
        public IHttpActionResult PostCreateJob(JobDetails model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (var ctx = new EJMEFConnection())
                    {
                        ctx.tblJobRequests.Add(new tblJobRequest
                        {
                            CustomerName = model.CustomerName,
                            Address = model.Address,
                            EmailAddress = model.EmailAddress,
                            PhoneNumber = model.TelPhoneNumber,
                            JobItem = model.JobItem,
                            JobType = model.JobType,
                            Description = model.Description,
                            PrefferedTime = Convert.ToDateTime(model.PrefferedDateTime),
                            LastUpdated = DateTime.Now
                        });
                        ctx.SaveChanges();
                    }
                    return Ok();
                }
                else
                    return BadRequest("Invalid Data.");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// This Method is used for edit job request
        /// </summary>
        /// <param name="model">JobDetails model</param>
        /// <returns></returns>
        [Route("api/EditJob")]
        [HttpPut]
        public IHttpActionResult PostEditJobRequest(JobDetails model)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid Request");
            else 
            {
                using (var ctx = new EJMEFConnection())
                {
                    //Stored Procedure Method
                    //ctx.spEditJobRequest(model.RequestID,model.CustomerName, model.Address, model.EmailAddress,model.TelPhoneNumber,model.JobItem,model.JobType,model.Description, Convert.ToDateTime(model.PrefferedDateTime));
                    tblJobRequest data = ctx.tblJobRequests.Find(model.RequestID);
                    data.CustomerName = model.CustomerName;
                    data.EmailAddress = model.EmailAddress;
                    data.Address = model.Address;
                    data.PhoneNumber = model.TelPhoneNumber;
                    data.JobItem = model.JobItem;
                    data.JobType = model.JobType;
                    data.Description = model.Description;
                    data.PrefferedTime = Convert.ToDateTime(model.PrefferedDateTime);
                    data.LastUpdated = DateTime.Now;
                    ctx.SaveChanges();
                }

                return Ok();
            }
        }

        /// <summary>
        /// This is a Delete Job request method
        /// </summary>
        /// <param name="_RequestId">Enter job request ID</param>
        /// <returns></returns>
        [Route("api/DeleteJob/{_RequestId:int}")]
        [HttpDelete]
        public IHttpActionResult DeleteJobRequest(int _RequestId)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid Input!!!");
            using (var ctx = new EJMEFConnection())
            {
                ctx.spDeleteJobRequest(_RequestId);
                ctx.SaveChanges();
            }
            return Ok();
        }
    }
}
