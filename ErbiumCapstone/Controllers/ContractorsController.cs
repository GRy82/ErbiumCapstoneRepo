using ErbiumCapstone.Contracts;
using ErbiumCapstone.Data;
using ErbiumCapstone.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ErbiumCapstone.Controllers
{
    public class ContractorsController : Controller
    {
        private IRepositoryWrapper _repo;
        public ContractorsController(IRepositoryWrapper repo)
        {
            _repo = repo;
        }

        // GET: ContractorController
        public ActionResult Index()
        {
            return View();
        }

        // GET: ContractorController/Details/5
        public ActionResult Details(int jobId)
        {
            var jobDetails = _repo.Job.GetJob(jobId);
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

        // POST: ContractorController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(JobTask jobTask)
        {
            try
            {
                _repo.JobTask.Create(jobTask);
                _repo.Save();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ContractorController/Edit/5
        public ActionResult Edit(int jobTaskId)
        {
            JobTask taskToEdit = _repo.JobTask.GetJobTask(jobTaskId);
            return View(taskToEdit);
        }

        // POST: ContractorController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(JobTask jobTask)
        {
            try
            {
                _repo.JobTask.EditJobTask(jobTask);
                _repo.Save();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ContractorController/Delete/5
        public ActionResult Delete(int taskId)
        {
            JobTask jobToDelete = _repo.JobTask.GetJobTask(taskId);
            return View(jobToDelete);
        }

        // POST: ContractorController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, JobTask jobToDelete)
        {
            try
            {
                // JobTask jobToDelete = _repo.JobTask.GetJobTask(id);   --if id is provided from view.
                _repo.JobTask.DeleteJobTask(jobToDelete); //if model object provided from view.
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
