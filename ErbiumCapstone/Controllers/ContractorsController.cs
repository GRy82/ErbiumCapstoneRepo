using ErbiumCapstone.Contracts;
using ErbiumCapstone.Data;
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
    public class ContractorsController : Controller
    {
        private IRepositoryWrapper _repo;
        private GeocodingService _geocodingService;
        public ContractorsController(IRepositoryWrapper repo, GeocodingService geocodingService)
        {
            _repo = repo;
            _geocodingService = geocodingService;
        }

        // GET: ContractorController
        public async Task<ActionResult> Index()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            Contractor contractor = await _repo.Contractor.GetContractorAsync(userId);
            if (contractor == null)
            {
                return RedirectToAction("Create");
            }
            
            return RedirectToAction("SearchForJob");
        }

        public async Task<ActionResult> SearchForJob()
        {
            HomeViewModel homeViewModel = await GetAllJobsByState();

            if (homeViewModel.PostedJobs == null)
            {
                return RedirectToAction(nameof(SearchForJobNull));
            }

            return View(homeViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> SearchForJob(Job job)
        {
            int id = job.JobId;
            job = await _repo.Job.GetJobAsync(id);
            job.ContractorAcceptedJob = true;
            _repo.Job.Update(job);
            await _repo.SaveAsync();

            HomeViewModel homeViewModel = await GetAllJobsByState();

            if (homeViewModel.PostedJobs == null)
            {
                return RedirectToAction(nameof(SearchForJobNull));
            }

            return View(homeViewModel);
        }




        public ActionResult SearchForJobNull()
        {
            return View();
        }

        // GET: ContractorController/Details/5
        public async Task<ActionResult> JobDetails(int jobId)
        {
            var jobDetails = await _repo.Job.GetJobAsync(jobId);
            return View(jobDetails);
        }

        // GET: ContractorController/Create
        public ActionResult Create()
        {
            ViewData["states"] = new List<string> { "AL", "AK", "AZ", "AR", "CA", "CO", "CT", "DE", "DC", "FL", "GA", "HI", "ID", "IL", "IN", "IA", "KS",
                "KY", "LA", "ME", "MD", "MA", "MI","MN", "MS", "MO","MT", "NE", "NV","NH", "NJ", "NM","NY", "NC", "ND","OH", "OK", "OR","PA", "RI", "SC","SD",
                "TN", "TX","UT", "VT", "VA","WA", "WV", "WI","WY" };
            return View(new Contractor());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Contractor contractor)
        {
            string streetAddress = contractor.StreetAddress.Replace(' ', '+');
            string city = contractor.City.Replace(' ', '+');
            string url = "https://maps.googleapis.com/maps/api/geocode/json?address=" + streetAddress + ",+" + city + ",+" + contractor.State + "&key=" + ApiKeys.GetGeocodingKey();
            Geocoding response = await _geocodingService.GetGeocoded(url);
            if (response.results.Length > 0)
            {
                contractor.Latitude = response.results[0].geometry.location.lat;
                contractor.Longitude = response.results[0].geometry.location.lng;
            }

            try
            {
                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                contractor.IdentityUserId = userId;
                _repo.Contractor.CreateContractor(contractor);
                await _repo.SaveAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                //_logger.LogError($"Error: {e.Message}");
                return View(e);
            }
        }

        // POST: ContractorController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> NewJobTask(JobTask jobTask)
        {
            try
            {
                _repo.JobTask.CreateJobTask(jobTask);
                await _repo.SaveAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ContractorController/Edit/5
        public async Task<ActionResult> EditJobTask(int jobTaskId)
        {
            JobTask taskToEdit = await _repo.JobTask.GetJobTaskAsync(jobTaskId);
            return View(taskToEdit);
        }

        // POST: ContractorController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditJobTask(JobTask jobTask)
        {
            try
            {
                _repo.JobTask.EditJobTask(jobTask);
                await _repo.SaveAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ContractorController/Delete/5
        public async Task<ActionResult> Delete(int taskId)
        {
            JobTask jobToDelete = await _repo.JobTask.GetJobTaskAsync(taskId);
            return View(jobToDelete);
        }

        // POST: ContractorController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, JobTask jobToDelete)
        {
            try
            {
                // JobTask jobToDelete = _repo.JobTask.GetJobTask(id);   --if id is provided from view.
                _repo.JobTask.DeleteJobTask(jobToDelete); //if model object provided from view.
                await _repo.SaveAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        


        public async Task<HomeViewModel> GetAllJobsByState()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            Contractor contractor = await _repo.Contractor.GetContractorAsync(userId);
            List<Job> currentJobsList = await _repo.Job.GetAllCurrentJobsAsync(contractor.ContractorId, contractor.GetType());
            List<Job> postedJobsList = await _repo.Job.GetAllPostedJobsAsync(contractor.ContractorId, contractor.GetType());
            List<Job> PastJobsList = await _repo.Job.GetAllPastJobsAsync(contractor.ContractorId, contractor.GetType());

            HomeViewModel homeViewModel = new HomeViewModel()
            {
                Contractor = contractor,
                CurrentJobs = currentJobsList,
                PostedJobs = postedJobsList,
                PastJobs = PastJobsList
            };
            return homeViewModel;
        }
    }
}
