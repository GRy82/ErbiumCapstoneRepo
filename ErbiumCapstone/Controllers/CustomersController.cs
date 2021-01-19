
using ErbiumCapstone.Contracts;
using ErbiumCapstone.Models;
using ErbiumCapstone.Services;
using ErbiumCapstone.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ErbiumCapstone.Controllers
{
    public class CustomersController : Controller
    {
        private IRepositoryWrapper _repo;
        private GeocodingService _geocodingService;
        public CustomersController(IRepositoryWrapper repo, GeocodingService geocodingService)
        {
            _repo = repo;
            _geocodingService = geocodingService;
        }
        // pass in repository in our constructor
        // GET: CustomersController
        public async Task<ActionResult> Index()
        {
            

            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            Customer customer = await _repo.Customer.GetCustomerAsync(userId);
            if (customer == null)
            {
                return RedirectToAction("Create");
            }
            Type customerType = customer.GetType();
            List<Job> jobList = await _repo.Job.GetAllJobsAsync(customer.CustomerId, customerType);

            HomeViewModel homeViewModel = new HomeViewModel()
            {
                Customer = customer,
                Jobs = jobList,
            };
            return View(jobList);
        }

        public async Task<ActionResult> GetPastJobs()
        {
            List<Job> completedJobs = new List<Job>();

            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            Customer customer = await  _repo.Customer.GetCustomerAsync(userId);
            var foundJob = await _repo.Job.GetJobAsync(customer.CustomerId);

            DateTime Today = DateTime.Today;
            var CompletedJob = foundJob.JobCompletion;
            var result = DateTime.Compare((DateTime)CompletedJob, Today);

            if(result < 0)
            {
                completedJobs.Add(foundJob);
            }

            return View(completedJobs);
        }

        // GET: CustomersController/Details/5
        public async Task<ActionResult> CustomerDetails(int id)
        {
            var customer = await _repo.Customer.GetCustomerAsync(id);
            return View(customer);
        }

        // GET: CustomersController/Create
        public ActionResult Create()
        {
            ViewData["states"] =  new List<string> { "AL", "AK", "AZ", "AR", "CA", "CO", "CT", "DE", "DC", "FL", "GA", "HI", "ID", "IL", "IN", "IA", "KS",
                "KY", "LA", "ME", "MD", "MA", "MI","MN", "MS", "MO","MT", "NE", "NV","NH", "NJ", "NM","NY", "NC", "ND","OH", "OK", "OR","PA", "RI", "SC","SD",
                "TN", "TX","UT", "VT", "VA","WA", "WV", "WI","WY" };
            return View(new Customer()); 
        }

        // POST: CustomersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Customer customer)
        {
            string streetAddress = customer.StreetAddress.Replace(' ', '+');
            string city = customer.City.Replace(' ', '+');
            string url = "https://maps.googleapis.com/maps/api/geocode/json?address=" + streetAddress + ",+" + city + ",+" + customer.State + "&key=" + ApiKeys.GetGeocodingKey();
            Geocoding response = await _geocodingService.GetGeocoded(url);
            if (response.results.Length > 0)
            {
                customer.Latitude = response.results[0].geometry.location.lat;
                customer.Longitude = response.results[0].geometry.location.lng;
            }

            try
            {
                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                customer.IdentityUserId = userId;
                _repo.Customer.CreateCustomer(customer);
                await _repo.SaveAsync();
                return RedirectToAction(nameof(Index));
            }
            catch(Exception e)
            {
                //_logger.LogError($"Error: {e.Message}");
                return View(e);
            }
        }

        //GET
        public ActionResult CreateJob()
        {
            ViewData["jobTypes"] = new List<string> { "Electrical", "Plumbing" };
            return View(new Job());
        }

        // POST: CustomersController/CreateJob/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateJob(Job job)
        {
            try
            {
                _repo.Job.CreateJob(job);
                await _repo.SaveAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        // GET: CustomersController/Edit/5  

        //This can have it's name changed if needed! This will be used only in posted jobs. After a job is accepted by both parties, it is a current job, and many of
        //job properties shouldn't be edited... if any of them.
        public async Task<ActionResult> EditJob(int jobId)
        {
            var jobToEdit = await _repo.Job.GetJobAsync(jobId);
            return View(jobToEdit);
        }

        // POST: CustomersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditJob(Job job)
        {
            try
            {
                _repo.Job.EditJob(job);
                await  _repo.SaveAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        //Get
        public async Task<ActionResult> CurrentJobs()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            Customer customer = await _repo.Customer.GetCustomerAsync(userId);
            List<Job> currentJobs = await _repo.Job.GetAllJobsAsync(customer.CustomerId, customer.GetType());
            HomeViewModel homeViewModel = new HomeViewModel()
            {
                Customer = customer,
                Jobs = currentJobs,
            };
            return View(homeViewModel);
        }



        // GET: CustomersController/Delete/5
        public async Task<ActionResult> DeleteJob(int jobId)
        {
            var jobToDelete = _repo.Job.GetJobAsync(jobId);
            await _repo.SaveAsync();
            return View(jobToDelete);
        }

        // POST: CustomersController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteJob(int id, Job job)
        {
            try
            {
                _repo.Job.DeleteJob(job);
                await _repo.SaveAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
