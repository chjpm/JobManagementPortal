using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using ENU.EJM.Web.Models;
using System.Configuration;

namespace ENU.EJM.Web.Controllers
{
    public class JobController : Controller
    {
        List<CreateJobModels> job = new List<CreateJobModels>();
        string BaseUri = ConfigurationManager.AppSettings["ApiUri"].ToString();
        public JobController()
        {
            job.Add(new CreateJobModels { RequestID=1001, CustomerName = "Jyoti Prakash", TelPhoneNumber = "9938650052", Address = "Pakshyot, Kendrapara", EmailAddress = "chjpm@outlook.com", Description = "Need to install new TV", JobItem = "TV", JobType = "Installation", PrefferedDateTime = DateTime.Now.ToString() });
            //job.Add(new CreateJobModels { RequestID = 1002, CustomerName = "Raja Goud", TelPhoneNumber = "9938650052", Address = "Hyderabad, Telengana", EmailAddress = "raja@outlook.com", Description = "Need to install new Broadband", JobItem = "Broadband", JobType = "Service", PrefferedDateTime = DateTime.Now.ToString() });
        }
        // GET: Job
        public ActionResult Index()
        {
            //Call api/Job/GetJobs method to get List of jobs

            IEnumerable<CreateJobModels> _job = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUri);
                var responseTask = client.GetAsync("GetJobs");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readJob = result.Content.ReadAsAsync<IList<CreateJobModels>>();
                    readJob.Wait();
                    _job = readJob.Result;
                }
                else 
                {
                    _job = Enumerable.Empty<CreateJobModels>();
                    ModelState.AddModelError(string.Empty, "Server error occurred. Please contact Admin!");
                }
            }
            return View(_job);
            //return View(job);
        }
        public ActionResult CreateJobRequest()
        {
            
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateJobRequest(CreateJobModels model)
        {
            ModelState.Remove("RequestID");
            if (ModelState.IsValid)
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(BaseUri);
                    var postTask = client.PostAsJsonAsync<CreateJobModels>("CreateJob", model);
                    postTask.Wait();

                    var result = postTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");
                    }
                }
            }
            ModelState.AddModelError(string.Empty, "Error in model");
            return View();
        }

        
        public ActionResult Edit(int id)
        {

            //Get the model from api/Job/GetJobs/_id= RequestID

            CreateJobModels _job = new CreateJobModels();
            IEnumerable<CreateJobModels> _jobs = null;
            
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.BaseAddress = new Uri(BaseUri);
                var responseTask = client.GetAsync("GetJobs/" + id);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readJob = result.Content.ReadAsAsync<IList<CreateJobModels>>();
                    readJob.Wait();
                    _jobs = readJob.Result;
                    _job = _jobs.Where(x => x.RequestID == id).FirstOrDefault();
                }
                else
                {
                    _jobs = Enumerable.Empty<CreateJobModels>();
                    ModelState.AddModelError(string.Empty, "Server error occurred. Please contact Admin!");
                }
            }
            return View(_job);
        }

        public ActionResult EditJob(CreateJobModels model)
        {
            //Post the model to api/Job/EditJob

            if (ModelState.IsValid)
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(BaseUri);
                    var postTask = client.PutAsJsonAsync<CreateJobModels>("EditJob", model);
                    postTask.Wait();

                    var result = postTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");
                    }
                }
            }
            ModelState.AddModelError(string.Empty, "Error in model");
            return View("Index");
        }

        //[HttpDelete]
        public ActionResult Delete(int id)
        {
            if (id > 0)
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.BaseAddress = new Uri(BaseUri);
                    //var postTask = client.PostAsJsonAsync<CreateJobModels>("CreateJob", model);
                    var check = "DeleteJob/" + id;
                    var delTask = client.DeleteAsync("DeleteJob/" + id);
                    delTask.Wait();

                    var result = delTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");
                    }
                }
            }
            ModelState.AddModelError(string.Empty, "Error in deleting. Contact Admin!");
            return RedirectToAction("Index");
        }
    }
}
