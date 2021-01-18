
using ErbiumCapstone.Contracts;
using ErbiumCapstone.Models;
using ErbiumCapstone.Services;
using ErbiumCapstone.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        public ActionResult Index()
        {
                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            Customer customer = _repo.Customer.GetCustomer(Convert.ToInt32(userId));
            var jobList = _repo.Job.GetAllJobs(customer.CustomerId);
            HomeViewModel homeViewModel = new HomeViewModel()
            {
                Customer = customer,
                Jobs = jobList,
            };
            return View(homeViewModel);
        }

        // GET: CustomersController/Details/5
        public ActionResult CustomerDetails(int id)
        {
            var customer = _repo.Customer.GetCustomer(id);
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
            string streetAddress =  customer.StreetAddress.Replace(' ', '+');
            string city = customer.City.Replace(' ', '+');
            string url = "https://maps.googleapis.com/maps/api/geocode/json?address=" + streetAddress + ",+" + city + ",+" + customer.State + "&key=" + ApiKeys.GetGeocodingKey();
            Geocoding response = await _geocodingService.GetGeocoded(url);
            customer.Latitude = response.results[0].geometry.location.lat;
            customer.Longitude = response.results[0].geometry.location.lng;

            try
            {
                _repo.Customer.CreateCustomer(customer);
                _repo.Save();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CustomersController/Edit/5
        public ActionResult EditJob(int jobId)
        {
            var jobToEdit = _repo.Job.GetJob(jobId);
            return View(jobToEdit);
        }

        // POST: CustomersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditJob(Job job)
        {
            try
            {
                _repo.Job.EditJob(job);
                _repo.Save();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CustomersController/Delete/5
        public ActionResult DeleteJob(int jobId)
        {
            var jobToDelete = _repo.Job.GetJob(jobId);
            return View(jobToDelete);
        }

        // POST: CustomersController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteJob(int id, Job job)
        {
            try
            {
                _repo.Job.DeleteJob(job);
                _repo.Save();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
